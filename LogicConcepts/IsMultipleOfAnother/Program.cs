using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetInt("Ingrese primer número :");
    var b = ConsoleExtension.GetInt("Ingrese segundo número:");

    if (a % b == 0)
    {
        Console.WriteLine($"El número: {a}, es múltiplo de: {b}");
    }
    else
    {
        Console.WriteLine($"El número: {a}, no es múltiplo de: {b}");
    }

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

