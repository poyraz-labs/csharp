Console.Write("What is your name? ");
string? name = Console.ReadLine();

Console.Write($"Where do you live, {name}? ");
string? city = Console.ReadLine();

Console.Write($"Why are you learning C#, {name}? ");
string? reason = Console.ReadLine();

Console.WriteLine();
Console.WriteLine(
    $"Hello {name}, you live in {city} and you are learning C# because {reason}."
);