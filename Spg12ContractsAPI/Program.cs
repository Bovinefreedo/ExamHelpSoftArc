var builder = WebApplication.CreateBuilder(args);


var app = builder.Build();


app.UseHttpsRedirection();

List<Contract> contracts = new();

contracts.Add(new Contract(0, "Henning", 22033, "fuldtid"));
contracts.Add(new Contract(1, "Anna", 27000, "fuldtid"));
contracts.Add(new Contract(2, "Lene", 18000, "deltid"));
contracts.Add(new Contract(3, "Poul", 18400, "deltid"));
contracts.Add(new Contract(4, "Peter", 20200, "senior"));

app.MapGet("/api/contracts", () => contracts );
app.MapGet("/api/contracts/{id}", (int id) => contracts.FirstOrDefault(c => c.id == id));
app.MapPost("/api/contracts", (ContractData data) => contracts.Add(
    new Contract((contracts[contracts.Count-1].id+1), data.employeeName, data.salary, data.type)
    ));
app.MapPut("/api/contracts/{id}", (int id, ContractData data) => {
    Contract c = contracts.FirstOrDefault(c => c.id == id);
    if (c == null)
    {
        return Results.BadRequest();
    }
    else {
        c.employeeName = data.employeeName;
        c.salary = data.salary;
        c.type = data.type;
        return Results.Ok();
    }
});
app.MapDelete("/api/contracts/{id}", (int id) => {
    Contract c = contracts.FirstOrDefault(c => c.id == id);
    if (c != null)
    {
        return Results.BadRequest();
    }
    else {
        contracts.RemoveAll(c => c.id == id);
        return Results.Ok();
    }
});
app.MapGet("/api/contracts/type/{type}", (string type) => contracts.Where(c => c.type == type));


app.Run();

public class Contract { 
    public int id { get; set; }
    public string employeeName { get; set; }
    public int salary { get; set; }
    public string type { get; set; }

    public Contract(int id, string employeeName, int salary, string type)
    {
        this.id = id;
        this.employeeName = employeeName;
        this.salary = salary;
        this.type = type;
    }
} 
public record ContractData(string employeeName, int salary, string type);