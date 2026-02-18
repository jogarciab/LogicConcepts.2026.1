using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Cuantos números desea: ");
    int sum = 0;
    for (int i = 1; i <= n; i++)
    {
        Console.Write($"{i}\t");
        sum += i;
    }
    var average = sum / n;
    Console.WriteLine();
    Console.WriteLine($"La suma es....: {sum,20:N0}");
    Console.WriteLine($"El promedio es: {average,2:N2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");
