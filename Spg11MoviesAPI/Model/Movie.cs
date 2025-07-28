namespace Spg11MoviesAPI.Model
{
    public class Movie
    {
        public int id { get; set; }
        public string title { get; set; } = "No title";
        public int year { get; set; }
        public List<string> genres { get; set; } = new();

    }
}
