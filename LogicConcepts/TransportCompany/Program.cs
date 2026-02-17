using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    Console.WriteLine("*** DATOS DE ENTRADDA ***");
    var routeOptions = new List<string> { "1", "2", "3", "4" };
    var route = string.Empty;
    do
    {
        route = ConsoleExtension.GetValidOptions("Ruta [1] [2] [3] [4]...............................:", routeOptions); 
    } while (!routeOptions.Any(x => x.Equals(route, StringComparison.CurrentCultureIgnoreCase))); 

    var trips = ConsoleExtension.GetInt("Número de viajes................................:");
    var passengers = ConsoleExtension.GetInt("Número de pasajeros total.......................:");
    var parcels1 =  ConsoleExtension.GetInt("Número de encomiendas de menos de 10Kg..........:");
    var parcels2 = ConsoleExtension.GetInt("Número de encomiendas entre 10Kg y menos de 20Kg:"); 
    var parcels3 = ConsoleExtension.GetInt("Número de encomiendas de más de 20Kg.............:");
    var totalParcels = parcels1 + parcels2 + parcels3;

    var passenger = GetPassengerPayment(route, passengers, trips);
    var weightPassengers = 60 * passengers;
    var parcelsPayment = GetParcelsPayment(route, totalParcels, parcels1, parcels2);
    var driverIncome = passenger + parcelsPayment;
    var assitant = GetAssistantPayment(driverIncome);
    var sure = GetSurePayment(driverIncome);
    var fuel = GetFuelPayment(route, weightPassengers);
    var deductions = GetDeductions(assitant, sure, fuel);
    var total = passenger + parcelsPayment - deductions;

    Console.WriteLine("*** CALCULOS ***");
    Console.WriteLine($"Ingresos por Pasajeros.........................: {passenger:C2}");
    Console.WriteLine($"Ingresos por Encomiendas.......................: {parcelsPayment:C2}");
    Console.WriteLine("                                               :__________");
    Console.WriteLine($"TOTAL INGRESOS.................................: {driverIncome:C2}");
    Console.WriteLine($"Pago Ayudante..................................: {assitant:C2}");
    Console.WriteLine($"Pago Seguro....................................: {sure:C2}");
    Console.WriteLine($"Pago Combustible...............................: {fuel:C2}");
    Console.WriteLine("                                               :__________");
    Console.WriteLine($"TOTAL DEDUCCIONES..............................: {deductions:C2}");
    Console.WriteLine("                                               :__________");
    Console.WriteLine($"TOTAL A LIQUIDAR...............................: {total:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]i, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));

} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over");

decimal GetDeductions(decimal assitant, decimal sure, decimal fuel)
{
    return (assitant + sure + fuel);
}

decimal GetParcelsPayment(string? route, int totalParcels, int parcels1, int parcels2)
{
    if (route == "1" || route == "2")
    {
        if (totalParcels < 50)
        {
            if (totalParcels == parcels1)
            {
                return 100m;
            }
            else
            {
                return 120m;
            }
        }
        else if (totalParcels > 50 && totalParcels < 100)
        {
            if (totalParcels == parcels1)
            {
                return 120m;
            }
            else
            {
                return 140m;
            }
        }
        else if (totalParcels > 100 && totalParcels < 130)
        {
            if (totalParcels == parcels1)
            {
                return 150m;
            }
            else
            {
                return 160m;
            }
        }
        else
        {
            if (totalParcels > 130)
            {
                return 160m;
            }
            else
            {
                return 180m;
            }
        }
    }
    else
    {
        if (totalParcels < 50)
        {
            if (totalParcels == parcels1)
            {
                return 130m;
            }
            else if (totalParcels == parcels2)
            {
                return 140m;
            }
            else
            {
                return 170m;
            }
        }
        else if (totalParcels > 50 && totalParcels < 100)
        {
            if (totalParcels == parcels1)
            {
                return 160m;
            }
            else if (totalParcels == parcels2)
            {
                return 180m;
            }
            else
            {
                return 210m;
            }
        }
        else if (totalParcels > 100 && totalParcels < 130)
        {
            if (totalParcels == parcels1)
            {
                return 175m;
            }
            else if (totalParcels == parcels2)
            {
                return 200m;
            }
            else
            {
                return 250m;
            }
        }
        else
        {
            if (totalParcels > 130)
            {
                return 200m;
            }
            else if (totalParcels == parcels2)
            {
                return 250m;
            }

            else
            {
                return 300m;
            }
        }
    }
}

decimal GetFuelPayment(string? route, int weightPassengers)
{
    if (route == "1")
    {
        if (weightPassengers < 5000)
        {
            return (int)(150 / 39) * 8860; 
        }
        else if (weightPassengers > 5000 && weightPassengers <= 10000)
        {
            return ((int)(150 / 39) * 8860) + (((int)(150 / 39) * 8860) * 0.1m);
        }
        else
        {
            return ((int)(150 / 39) * 8860) + (((int)(150 / 39) * 8860) * 0.25m);
        }
    }
    else if (route == "2")
    {
        if (weightPassengers < 5000)
        {
            return (int)(167 / 39) * 8860;
        }
        else if (weightPassengers > 5000 && weightPassengers <= 10000)
        {
            return ((int)(167 / 39) * 8860) + (((int)(150 / 39) * 8860) * 0.1m);
        }
        else
        {
            return ((int)(167 / 39) * 8860) + (((int)(150 / 39) * 8860) * 0.25m);
        }
    }
    else if (route == "3")
    {
        if (weightPassengers < 5000)
        {
            return (int)(184 / 39) * 8860;
        }
        else if (weightPassengers > 5000 && weightPassengers <= 10000)
        {
            return ((int)(184 / 39) * 8860) + (((int)(150 / 39) * 8860) * 0.1m);
        }
        else
        {
            return ((int)(184 / 39) * 8860) + (((int)(150 / 39) * 8860) * 0.25m);
        }
    }
    else
    {
        if (weightPassengers < 5000)
        {
            return (int)(203 / 39) * 8860;
        }
        else if (weightPassengers > 5000 && weightPassengers <= 10000)
        {
            return ((int)(203 / 39) * 8860) + (((int)(150 / 39) * 8860) * 0.1m);
        }
        else
        {
            return ((int)(203 / 39) * 8860) + (((int)(150 / 39) * 8860) * 0.25m);
        }
    }
}

decimal GetSurePayment(decimal driverIncome)
{
    if (driverIncome < 1000000)
    {
        return driverIncome * 0.03m;
    }
    else if (driverIncome > 1000000 && driverIncome < 2000000)
    {
        return driverIncome * 0.04m;
    }
    else if (driverIncome > 2000000 && driverIncome < 4000000)
    {
        return driverIncome * 0.06m;
    }
    else
    {
        return driverIncome * 0.09m;
    }
}

decimal GetAssistantPayment(decimal driverIncome)
{
    if (driverIncome < 1000000)
    {
        return driverIncome * 0.05m;
    }
    else if (driverIncome > 1000000 && driverIncome < 2000000)
    {
        return driverIncome * 0.08m;
    }
    else if (driverIncome > 2000000 && driverIncome < 4000000)
    {
        return driverIncome * 0.1m;
    }
    else
    {
        return driverIncome * 0.13m;
    }
}

decimal GetPassengerPayment(string? route, decimal passengers, int trips)
{
    if (!route.Equals("1", StringComparison.CurrentCultureIgnoreCase))
    {
        if (passengers < 50)
        {
            return trips * 500000 * 1.0m;
        }
        else if (passengers > 50 && passengers <= 100)
        {
            return trips * 500000 * 1.05m;
        }
        else if (passengers > 100 && passengers <= 150)
        {
            return trips * 500000 * 1.06m;
        }
        else if (passengers > 150 && passengers <= 200)
        {
            return trips * 500000 * 1.07m;
        }
        else
        {
            return ((passengers - 200) * 50) + (decimal)trips * 500000 * 1.07m;
        }
    }
    if (route.Equals("2", StringComparison.CurrentCultureIgnoreCase))
    {
        if (passengers < 50)
        {
            return trips * 600000 * 1.0m;
        }
        else if (passengers > 50 && passengers <= 100)
        {
            return trips * 600000 * 1.07m;
        }
        else if (passengers > 100 && passengers <= 150)
        {
            return trips * 600000 * 1.08m;
        } 
        else if (passengers > 150 && passengers <= 200)
        {
            return trips * 600000 * 1.09m;
        }
        else
        {
            return ((passengers - 200) * 60) + (decimal)trips * 600000 * 1.09m;
        }
    }
    if (route.Equals("3", StringComparison.CurrentCultureIgnoreCase))
    {
        if (passengers < 50)
        {
            return trips * 800000 * 1.0m;
        }
        else if (passengers > 50 && passengers <= 100)
        {
            return trips * 800000 * 1.1m;
        }
        else if (passengers > 100 && passengers <= 150)
        {
            return trips * 800000 * 1.13m;
        }
        else if (passengers > 150 && passengers <= 200)
        {
            return trips * 800000 * 1.15m;
        }
        else
        {
            return ((passengers - 200) * 100) + (decimal)trips * 800000 * 1.15m;
        }
    }
    else
    {
        if (passengers < 50)
        {
            return trips * 1000000 * 1.0m;
        }
        else if (passengers > 50 && passengers <= 100)
        {
            return trips * 1000000 * 1.125m;
        }
        else if (passengers > 100 && passengers <= 150)
        {
            return trips * 1000000 * 1.15m;
        }
        else if (passengers > 150 && passengers <= 200)
        {
            return trips * 1000000 * 1.17m;
        }
        else
        {
            return ((passengers - 200) * 150) + (decimal)trips * 1000000 * 1.17m;
        }
    }
}