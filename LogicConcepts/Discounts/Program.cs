using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var desks = ConsoleExtension.GetInt("Número de escritorios: ");
    var pay = (decimal)desks * 650000;

    if (desks < 5)
    {
        var discount = (float)pay * 0.10;
        var total = pay - (decimal)discount;
        Console.WriteLine(total);
    }
    else if(desks >= 5 && desks < 10)
    {
        var discount = (float)pay * 0.20;
        var total = pay - (decimal)discount;
        Console.WriteLine(total);
    }
    else if (desks >= 10)
    {
        var discount = (float)pay * 0.40;
        var total = pay - (decimal)discount;
        Console.WriteLine(total);
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");
