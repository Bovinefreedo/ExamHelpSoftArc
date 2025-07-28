var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

List<Pet> pets = new();

app.MapGet("/api/pets",()=> pets);
app.MapGet("/api/pets/{id}", (int id) => pets.FirstOrDefault(p => p.id == id));
app.MapPost("/api/pets", (Pet p) => pets.Add(p));
app.MapPut("/api/pets", (Pet p) =>
{
    Pet pet = pets.FirstOrDefault(x => p.id == x.id);
    if (pet == null)
    {
        return Results.BadRequest();
    }
    else {
        pets.RemoveAll(x => x.id == p.id);
        pets.Add(p);
        return Results.Ok();
    }
});
app.MapDelete("/api/pets/{id}", (int id) => pets.RemoveAll(p => p.id == id));
app.MapGet("/api/pets/species/{species}", (string species) => 
    pets.Where(p => p.species == species).ToList());

app.Run();

public record Pet(int id, string petName, string ownerName, string species );

