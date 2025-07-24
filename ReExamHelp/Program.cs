using ReExamHelp._5CountryArray;

Spg5CountryArray spg5 = new Spg5CountryArray(7);

Console.WriteLine(spg5.printArray());
spg5.insertCountry(3, "Tyskland");
Console.WriteLine(spg5.printArray());
Console.WriteLine(spg5.count);
spg5.insertCountry(6, "Norge"); 
spg5.insertCountry(6, "Sverige");
Console.WriteLine(spg5.printArray());
Console.WriteLine(spg5.count);
Console.WriteLine($"Tyskland er i arrayet: {spg5.contains("Tyskland")}");
spg5.deleteCountry("Tyskland");
Console.WriteLine(spg5.printArray());
Console.WriteLine(spg5.count);
Console.WriteLine($"Tyskland er i arrayet: {spg5.contains("Tyskland")}");