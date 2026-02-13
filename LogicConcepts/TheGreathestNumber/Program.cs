using Shared;

var answer = string.Empty;
var options = new List<string> { "s" , "n" };

do 
{
    Console.WriteLine("Ingrese 3 numeros diferentes");
    var a = ConsoleExtension.GetInt("Ingrese primer numero :");
    var b = ConsoleExtension.GetInt("Ingrese segundo numero:");
    var c = ConsoleExtension.GetInt("Ingrese tercer numero :");

    if (a > b && a > c)
    {
        Console.WriteLine($"El numero mayor es: {a}");
    }
    else if (b > a && b > c)
    {
        Console.WriteLine($"El numero mayor es: {b}");
    }
    else
    {
        Console.WriteLine($"El numero mayor es: {c}");
    }

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