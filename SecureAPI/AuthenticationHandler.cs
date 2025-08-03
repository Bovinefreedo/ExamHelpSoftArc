using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace SecureAPI
{
    public class AuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        public static Dictionary<string, User> users = new();


        public AuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock
            ) : base(options, logger, encoder, clock)
        {
        }

        public static IResult CreateUser(NewUser newUser) {
            if (users.ContainsKey(newUser.user))
            {
                return Results.Forbid();
            }
            else {
                string salt = PasswordHasher.salt();
                string hashedPassword = PasswordHasher.hashPassword(newUser.password, salt);
                User u = new User {
                    HashedPassword = hashedPassword,
                    Salt = salt,
                    Role = newUser.roles.ToList()
                };
                users[newUser.user] = u;
                return Results.Ok();
            }
        }

        public static IResult GrantRole(string newRole, string userName)
        {
            if (!users.ContainsKey(userName))
            {
                return Results.Forbid();
            }
            else
            {
                users[userName].Role.Add(newRole);
                return Results.Ok();
            }
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            // Vi undersøge lige om anonym adgang er tilladt
            var endpoint = Context.GetEndpoint();
            if (endpoint?.Metadata?.GetMetadata<IAllowAnonymous>() != null)
            {
                // Hvis anonym adgang er tilladt, skal vi ikke lave authentication
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            // Vi fisker en header ud hvor key er "Authorization"
            var authHeader = Request.Headers["Authorization"].ToString();

            // Vi tjekker efterfølgende på om "Authorization" findes, og på om dens value starte med "Password".
            if (authHeader != null && authHeader.StartsWith("Password ", StringComparison.OrdinalIgnoreCase))
            {
                var json = authHeader.Substring("Password ".Length).Trim();

                try
                {
                    var credentials = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

                    if (credentials != null &&
                        credentials.TryGetValue("user", out var username) &&
                        credentials.TryGetValue("password", out var password))
                    {
                        if (users.ContainsKey(username) && users[username].HashedPassword == PasswordHasher.hashPassword(password, users[username].Salt))
                        {
                            List<Claim> claims = new();
                            foreach (string role in users[username].Role) {
                                claims.Add(new Claim("role", role));
                            }
                            var identity = new ClaimsIdentity(claims, "DummyAuthentication");
                            var principal = new ClaimsPrincipal(identity);

                            return Task.FromResult(AuthenticateResult.Success(
                                new AuthenticationTicket(principal, "DummyAuthentication")));
                        }
                        else
                        {
                            return Task.FromResult(AuthenticateResult.Fail("Invalid username or password"));
                        }
                    }
                }
                catch (JsonException)
                {
                    return Task.FromResult(AuthenticateResult.Fail("Invalid JSON format in auth header"));
                }
            }
            return Task.FromResult(AuthenticateResult.NoResult());

        }
    }

    public record User
    {
        public string Salt { get; set; }
        public string HashedPassword { get; set; }
        public List<string> Role { get; set; }
    }
}