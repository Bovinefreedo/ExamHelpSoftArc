using Spg9BibliotekEF.Model;


using (var db = new BookContext()) {
    Author a0 =new Author
    {
        name = "Terry Pratchet",
        age = 67
    };
    Author a1 = new Author
    {
        name = "Andy Weir",
        age = 53
    };
    Author a2 = new Author
    {
        name = "Alison Wier",
        age = 74
    };



    db.Authors.RemoveRange(db.Authors);

    db.Authors.Add(a0);
    db.Authors.Add(a1);
    db.Authors.Add(a2);

    db.SaveChanges();

    foreach (var auth in db.Authors) {
        Console.WriteLine(auth.name);
    }

}