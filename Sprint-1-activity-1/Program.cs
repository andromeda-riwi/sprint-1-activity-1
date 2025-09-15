Console.WriteLine("Bienvenido el cine intergaláctico");

Console.WriteLine("Por favor introduce tu edad");

bool goOn = false;

int ageInp = 1;

while (!goOn)
{
    try
    {
        ageInp = int.Parse(Console.ReadLine());
        if (ageInp is >= 1 and <= 120) goOn = true;
        else Console.WriteLine($"{ageInp} no es una edad válida, por favor intente de nuevo");
    }
    catch (FormatException)
    {
        Console.WriteLine("Ingresaste una edad no válida, por favor intente de nuevo");
    }
}

int ageDiv = 1;

if (ageInp is >= 12 and < 18) 
{   
    ageDiv = 2;
}
if (ageInp is >= 18 and < 60)
{ 
    ageDiv = 3;
}
if (ageInp >= 60)
{
    ageDiv = 4;
}

goOn = false;

Console.WriteLine("Elige el tipo de película que deseas ver:\n1. Estreno\n2. Clásico\n3. 3D\n4. Maratón\n5. Función especial");

int movieType = 0;

while (!goOn)
{
    try
    {
        movieType = int.Parse(Console.ReadLine());
        if (movieType is >= 1 and <= 5) goOn = true;
        else Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
    catch (FormatException)
    {
        Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
}
goOn = false;

Console.WriteLine("Elige el día que deseas ver la película:\n1. Lunes\n2. Martes\n3. Miércoles\n4. Jueves\n5. Viernes\n6. Sábado\n7. Domingo");

int day = 0;

while (!goOn)
{
    try
    {
        day = int.Parse(Console.ReadLine());
        if (day is >= 1 and <= 7) goOn = true;
        else Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
    catch (FormatException)
    {
        Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
}
goOn = false;

Console.WriteLine("Elige la hora que deseas ver la película:\n1. Mañana (9am - 11:59am)\n2. Tarde (12m - 5:59pm)\n3. Noche (6pm - 12am)");

int time = 0;

while (!goOn)
{
    try
    {
        time = int.Parse(Console.ReadLine());
        if (time is >= 1 and <= 3) goOn = true;
        else Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
    catch (FormatException)
    {
        Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
}
goOn = false;

Console.WriteLine("¿Tienes algún tipo de membresía?:\n1. Ninguna\n2. Silver\n3. Gold\n4. Platinum");

int membership = 0;

while (!goOn)
{
    try
    {
        membership = int.Parse(Console.ReadLine());
        if (membership is >= 1 and <= 4) goOn = true;
        else Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
    catch (FormatException)
    {
        Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
}
goOn = false;

bool activeSale = false;

Console.WriteLine("¿Cuéntas con Promo Activa? s/n");

char activeSaleInp =  'n';

while (!goOn)
{
    try
    {
        activeSaleInp = char.Parse(Console.ReadLine());
        switch (activeSaleInp)
        {
            case 's' or 'S':
                activeSale = true;
                goOn = true;
                break;
            case 'n' or 'N':
                goOn = true;
                break;
            default:
                Console.WriteLine("Opción no válida, por favor intente de nuevo");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
}
goOn = false;

bool isStuent = false;

Console.WriteLine("¿Eres estudiante? s/n");

char isStudentInp = 'n';

while (!goOn)
{
    try
    {
        isStudentInp = char.Parse(Console.ReadLine());
        switch (isStudentInp)
        {
            case 's' or 'S':
                isStuent = true;
                goOn = true;
                break;
            case 'n' or 'N':
                goOn = true;
                break;
            default:
                Console.WriteLine("Opción no válida, por favor intente de nuevo");
                break;
        }
    }
    catch (FormatException)
    {
        Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
}
goOn = false;

Console.WriteLine("Precio de la entrada:");

double basePrice = 0;

while (!goOn)
{
    try
    {
        basePrice = double.Parse(Console.ReadLine());
        if (basePrice is > 0) goOn = true;
        else Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
    catch (FormatException)
    {
        Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
}
goOn = false;

bool isPair =  false;

Console.WriteLine("Tipo de entrada:\n1. Sencilla\n2. Doble");

int isPairInp = 0;

while (!goOn)
{
    try
    {
        isPairInp = int.Parse(Console.ReadLine());
        if (isPairInp is >= 1 and <= 2) goOn = true;
        else Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
    catch (FormatException)
    {
        Console.WriteLine("Opción no válida, por favor intente de nuevo");
    }
}

double discounts = 1.00;

double discountsOnNetPrice = 1.00;

string infoDiscounts ="Descuentos: ";

string infoDiscountsOnNetPrice = "Descuentos sobre el precio neto: ";

if (ageDiv == 1)
{
    if ((movieType == 2 && day == 1) || (movieType == 2 && day == 3))
    {
        Console.WriteLine("¡Es día de clásicos gratis para niños, disfruta!");
        System.Environment.Exit(0);
    }
    
    if (movieType == 3 && time != 3)
    {
        discountsOnNetPrice -= 0.70;
        
        if (infoDiscountsOnNetPrice != "Descuentos sobre el precio neto: ")
        {
            infoDiscountsOnNetPrice += ", ";
        }

        infoDiscountsOnNetPrice += "Paga solo 30% del precio neto";
    }

    if (movieType == 5)
    {
        Console.WriteLine("No puedes ingresar a este tipo de función");
        System.Environment.Exit(0);
    }
    
    if (movieType == 1 && isStuent)
    {
        discounts -= 0.20;
        
        if (infoDiscounts != "Descuentos: ")
        {
            infoDiscounts += ", ";
        }

        infoDiscounts += "15% para estudiantes en estrenos";
    }
}
else if (ageDiv == 2)
{
    if (movieType == 1)
    {
        infoDiscounts = "No se puede obtener descuentos en estrenos";
    }
    
    if (movieType == 2)
    {
        discountsOnNetPrice -= 0.50;
        
        if (infoDiscountsOnNetPrice != "Descuentos sobre el precio neto: ")
        {
            infoDiscountsOnNetPrice += ", ";
        }

        infoDiscountsOnNetPrice += "Paga solo 50% del precio neto";
    }
    
    if (membership == 2 && movieType == 3 && day != 7 && !((day is 5 or 6) && time == 3))
    {
        discounts -= 0.20;
        
        if (infoDiscounts != "Descuentos: ")
        {
            infoDiscounts += ", ";
        }

        infoDiscounts += "20% membresía silver en películas 3D";
    }
    
    if (movieType == 5)
    {
        Console.WriteLine("No puedes ingresar a este tipo de función");
        System.Environment.Exit(0);
    }
}
else if (ageDiv == 3)
{
    if (movieType == 1)
    {
        infoDiscounts = "No se puede obtener descuentos en estrenos";
    }
    if (movieType == 5)
    {
        infoDiscounts = "No se puede obtener descuentos en funciones especiales";
    }

    if (membership == 3 && movieType == 2 && !((day is 5 or 6) && time == 3))
    {
        discounts -= 0.25;
        
        if (infoDiscounts != "Descuentos: ")
        {
            infoDiscounts += ", ";
        }

        infoDiscounts += "25% membresía gold en películas clásicas";
    }
    
    if (membership == 3 && movieType == 3 && day != 7 && !((day is 5 or 6) && time == 3))
    {
        discounts -= 0.15;
        
        if (infoDiscounts != "Descuentos: ")
        {
            infoDiscounts += ", ";
        }

        infoDiscounts += "15% membresía gold en películas 3D";
    }
    
    if (membership == 4 && movieType != 1 && !((day is 5 or 6) && time == 3))
    {
        discounts -= 0.35;
        
        if (infoDiscounts != "Descuentos: ")
        {
            infoDiscounts += ", ";
        }

        infoDiscounts += "35% membresía platinum";
    }
}
else if (ageDiv == 4)
{
    discounts -= 0.40;
        
    if (infoDiscounts != "Descuentos: ")
    {
        infoDiscounts += ", ";
    }

    infoDiscounts += "40% descuento senior";

    if (day == 7 && activeSale == true)
    {
        discounts -= 0.30;
        
        if (infoDiscounts != "Descuentos: ")
        {
            infoDiscounts += ", ";
        }

        infoDiscounts += "30% domingo de promo activa";
    }
    
    if (movieType == 4)
    {
        discountsOnNetPrice -= 0.50;
        
        if (infoDiscountsOnNetPrice != "Descuentos sobre el precio neto: ")
        {
            infoDiscountsOnNetPrice += ", ";
        }

        infoDiscountsOnNetPrice += "Paga solo 50% del precio neto en maratones";
    }
    
    if (movieType == 1 && isStuent)
    {
        discounts -= 0.20;
        
        if (infoDiscounts != "Descuentos: ")
        {
            infoDiscounts += ", ";
        }

        infoDiscounts += "15% para estudiantes en estrenos";
    }
}

if (day == 3)
{
    discountsOnNetPrice -= 0.20;
        
    if (infoDiscountsOnNetPrice != "Descuentos sobre el precio neto: ")
    {
        infoDiscountsOnNetPrice += ", ";
    }

    infoDiscountsOnNetPrice += "20% !Es miércoles de descuento¡";
}

if (movieType == 3)
{
    discountsOnNetPrice += 0.10;
        
    if (infoDiscountsOnNetPrice != "Descuentos sobre el precio neto: ")
    {
        infoDiscountsOnNetPrice += ", ";
    }

    infoDiscountsOnNetPrice += "10% recargo extra en 3D";
}
else if (movieType == 4 && ageDiv != 4)
{
    discountsOnNetPrice -= 0.20;
        
    if (infoDiscountsOnNetPrice != "Descuentos sobre el precio neto: ")
    {
        infoDiscountsOnNetPrice += ", ";
    }

    infoDiscountsOnNetPrice += "Paga solo 20% del precio neto en maratones";
}

if (isStuent && day is 1 or 3 && !((ageDiv == 2 && movieType == 1) || (ageDiv == 3 && movieType is 1 or 5)))
{
    discounts -= 0.10;
        
    if (infoDiscounts != "Descuentos: ")
    {
        infoDiscounts += ", ";
    }

    infoDiscounts += "10% extra para estudiantes";
}

if (activeSale && membership == 1 && !((ageDiv == 2 && movieType == 1) || (ageDiv == 3 && movieType is 1 or 5)))
{
    discounts -= 0.10;
        
    if (infoDiscounts != "Descuentos: ")
    {
        infoDiscounts += ", ";
    }

    infoDiscounts += "10% promo activa básica";
}

if (activeSale && membership > 1 && !((ageDiv == 2 && movieType == 1) || (ageDiv == 3 && movieType is 1 or 5)))
{
    discounts -= 0.15;
        
    if (infoDiscounts != "Descuentos: ")
    {
        infoDiscounts += ", ";
    }

    infoDiscounts += "15% promo activa miembros";
}

if (isPair && day != 7)
{
    discounts *= 1.50;
        
    if (infoDiscounts != "Descuentos: ")
    {
        infoDiscounts += ", ";
    }

    infoDiscounts += "Entrada doble 50% menos en la segunda entrada";
}
    

double netPrice =  basePrice * discounts;

double finalPrice = netPrice * discountsOnNetPrice;

Console.WriteLine($"Precio bruto: {basePrice:F2}");

if (infoDiscounts != "Descuentos: ")
{
    Console.WriteLine(infoDiscounts + ".");
}

Console.WriteLine($"Precio neto: {netPrice:F2}");

if(infoDiscountsOnNetPrice != "Descuentos sobre el precio neto: ")
{
    Console.WriteLine(infoDiscountsOnNetPrice + ".");
}

Console.WriteLine($"El precio a pagar es: {finalPrice:F2}");

