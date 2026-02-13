using Shared;

do
{
    var year = ConsoleExtension.GetInt("Ingrese año: ");

    if (year > 0)
    {
        if ((year % 4 == 0 && year % 100 != 0) || (year % 400 == 0))
        {
            Console.WriteLine($"El año: {year}, SI es bisiesto");
        }
        else
        {
            Console.WriteLine($"El año: {year}, NO es bisiesto");
        }
    }
    else
    {
        Console.WriteLine("Ingrese un año válido, este es un año imposible de ejecutar");
    }
}
while (true);