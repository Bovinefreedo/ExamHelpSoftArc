using Spg11MoviesAPI.Model;
using System.Reflection.Metadata.Ecma335;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

List<Movie> movies = new();
movies.Add(new Movie
{
    id = 0,
    title = "Ghost Busters",
    year = 1987,
    genres = new List<string> { "Action", "Comedy", "Si-Fi" }
});

app.MapGet("/api/movies", () => movies);
app.MapGet("/api/movies/{id}", (int id) => movies.FirstOrDefault(m => id == m.id));
app.MapPost("/api/movies", (MovieData newMovie) =>{
    Movie m = new Movie
    {
        id = movies[movies.Count - 1].id + 1,
        title = newMovie.title,
        year = newMovie.year,
        genres = newMovie.genres
    };
    movies.Add(m);
    return Results.Ok();
});
app.MapPut("/api/movies/{id}", (int id, MovieData updatedData) => {
    Movie? m = movies.FirstOrDefault(x => x.id == id);
    if (m == null)
    {
        return Results.BadRequest();
    }
    else {
        m.title = updatedData.title;
        m.year = updatedData.year;
        m.genres = updatedData.genres;
        return Results.Ok();
    }
});
app.MapDelete("/api/movies/{id}", (int id) => movies.RemoveAll(m => m.id == id));
app.MapGet("/api/movies/genres/{genre}", (string genre) => {
    List<Movie> m = movies.Where(m => m.genres.Contains(genre)).ToList();
    return Results.Ok(m);
});


app.Run();

public record MovieData(string title, int year, List<string> genres);