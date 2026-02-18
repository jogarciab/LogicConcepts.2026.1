using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var fact = ConsoleExtension.GetInt("Ingrese un número: ");
    var factorial = MyMath.Factorial(fact);
    Console.WriteLine($"{fact}! = {factorial:N0}");


    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");