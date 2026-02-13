using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var credits = ConsoleExtension.GetInt("Número de créditos: ");
    var creditsValue = ConsoleExtension.GetDecimal("Valor crédito: "); ;
    var stratum = ConsoleExtension.GetInt("Estrato del estudiante: ");

    var subsidy = CalculateSubsidy(stratum);

    if (credits <= 20)
    {
        var tuitionCost = credits * creditsValue;
        if (stratum == 1)
        {
            var tuitionCostWithdiscount = tuitionCost - (tuitionCost * 0.8m);
            Console.WriteLine($"El costo de la matrícula es: {tuitionCostWithdiscount:C0}");
        }
        else if (stratum == 2)
        {
            var tuitionCostWithdiscount = tuitionCost - (tuitionCost * 0.5m);
            Console.WriteLine($"El costo de la matrícula es: {tuitionCostWithdiscount:C0}");
        }
        else if (stratum == 3)
        {
            var tuitionCostWithdiscount = tuitionCost - (tuitionCost * 0.3m);
            Console.WriteLine($"El costo de la matrícula es: {tuitionCostWithdiscount:C0}");
        }
    }
    else if (credits > 20)
    {
        var tuitionCost = (20 * creditsValue + ((credits - 20) * (creditsValue * 2)));
        if (stratum == 1)
        {
            var tuitionCostWithdiscount = tuitionCost - (tuitionCost * 0.8m);
            Console.WriteLine($"El costo de la matrícula es: {tuitionCostWithdiscount:C0}");
        }
        else if (stratum == 2)
        {
            var tuitionCostWithdiscount = tuitionCost - (tuitionCost * 0.5m);
            Console.WriteLine($"El costo de la matrícula es: {tuitionCostWithdiscount:C0}");
        }
        else if (stratum == 3)
        {
            var tuitionCostWithdiscount = tuitionCost - (tuitionCost * 0.3m);
            Console.WriteLine($"El costo de la matrícula es: {tuitionCostWithdiscount:C0}");
        }
    }

    Console.WriteLine($"Valor del subsidio: {subsidy}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");

decimal CalculateSubsidy(int stratum)
{
    if (stratum == 1)
    {
        return 200000m;
    }
    if (stratum == 2)
    {
        return 100000m;
    }
    return 0;
}

