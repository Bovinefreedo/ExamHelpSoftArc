using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

List<BorgerForslag> borgerForslag = new();

app.MapGet("/api/forslag", () => {
    List<Forslag> forslag = new();
    foreach (var b in borgerForslag) {
        forslag.Add(new Forslag(b.id, b.title, b.tekst)); 
    }
    return Results.Ok(forslag);
});

app.MapGet("/api/forslag2", () => borgerForslag.Select(b => new Forslag(b.id, b.title, b.tekst)));

app.MapGet("/api/forslag/gokendte", () => {
    List<Forslag> forslag = new();
    foreach (var b in borgerForslag)
    {
        if (b.underskrifter.Count > 499)
        {
            forslag.Add(new Forslag(b.id, b.title, b.tekst));
        }
    }
    return Results.Ok(forslag);
});

app.MapGet("/api/forslag/godkendte2", () => borgerForslag
                                            .Where(b => b.underskrifter.Count>499)
                                            .Select(b => new Forslag(b.id, b.title, b.tekst)));

app.MapGet("/api/forslag/{id}", (int id) => {
    BorgerForslag b = borgerForslag.FirstOrDefault(x => id == x.id);
    return b == null ? Results.NoContent() : Results.Ok(new ForslagMedAntal(b.id, b.title, b.tekst, b.underskrifter, b.underskrifter.Count)); 
});

app.MapPut("/api/forslag/{id}/underskrifter", (int id, Underskrift underskrift) => {
    BorgerForslag b = borgerForslag.FirstOrDefault(x => x.id == id);
    if (b != null) {
        b.underskrifter.Add(underskrift);
    }
});

app.MapPost("/api/forslag/", (Forslag f) => borgerForslag.Add(new BorgerForslag(f.id, f.title, f.tekst)));



app.Run();

public record Underskrift(int id, string name);

public record Forslag(int id, string title, string tekst);

public record ForslagMedAntal(int id, string title, string tekst, List<Underskrift> underskrifter, int antalUnderskrifter);
public class BorgerForslag {
    public int id { get; set; }
    public string title { get; set; }
    public string tekst { get; set; }
    public List<Underskrift> underskrifter { get; set; } = new();

    public BorgerForslag(int id, string title, string tekst) {
        this.id = id;
        this.title = title;
        this.tekst = tekst; 
    }

}