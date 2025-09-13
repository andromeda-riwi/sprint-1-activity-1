using System;
using System.Collections.Generic;

//  INICIO DEL PROGRAMA 

Console.WriteLine(" BIENVENIDO A LA CALCULADORA DE PRECIOS DEL CINE ");
Console.WriteLine("Por favor, ingrese los siguientes datos.\n");

// PEDIR DATOS AL USUARIO

//  Pedir Edad 
int edad;
Console.Write("Ingrese su edad: ");
while (!int.TryParse(Console.ReadLine(), out edad) || edad < 0)
{
    Console.WriteLine("Error: Debe ingresar un número entero válido y positivo.");
    Console.Write("Ingrese su edad: ");
}

//  Pedir Tipo de Película 
string tipo_pelicula;
Console.WriteLine("Ingrese el tipo de película (Opciones: estreno, clasico, 3D, maraton, funcion_especial):");
while (true)
{
    Console.Write("> ");
    tipo_pelicula = Console.ReadLine().ToLower();
    if (tipo_pelicula == "estreno" || tipo_pelicula == "clasico" || tipo_pelicula == "3d" || tipo_pelicula == "maraton" || tipo_pelicula == "funcion_especial")
    {
        break; 
    }
    else
    {
        Console.WriteLine("Error: Opción no válida. Por favor, elija una de la lista.");
    }
}

//  Pedir Día de la Semana 
string dia;
Console.WriteLine("Ingrese el día de la semana (Opciones: lunes, martes, miercoles, jueves, viernes, sabado, domingo):");
while (true)
{
    Console.Write("> ");
    dia = Console.ReadLine().ToLower();
    if (dia == "lunes" || dia == "martes" || dia == "miercoles" || dia == "jueves" || dia == "viernes" || dia == "sabado" || dia == "domingo")
    {
        break;
    }
    else
    {
        Console.WriteLine("Error: Opción no válida. Por favor, elija una de la lista.");
    }
}

//  Pedir Hora de la Función 
string hora;
Console.WriteLine("Ingrese la hora de la función (Opciones: mañana, tarde, noche):");
while (true)
{
    Console.Write("> ");
    hora = Console.ReadLine().ToLower();
    if (hora == "mañana" || hora == "tarde" || hora == "noche")
    {
        break;
    }
    else
    {
        Console.WriteLine("Error: Opción no válida. Por favor, elija una de la lista.");
    }
}

//  Pedir Membresía 
string membresia;
Console.WriteLine("Ingrese su tipo de membresía (Opciones: ninguna, silver, gold, platino):");
while (true)
{
    Console.Write("> ");
    membresia = Console.ReadLine().ToLower();
    if (membresia == "ninguna" || membresia == "silver" || membresia == "gold" || membresia == "platino")
    {
        break;
    }
    else
    {
        Console.WriteLine("Error: Opción no válida. Por favor, elija una de la lista.");
    }
}

//  Pedir si es Estudiante 
bool estudiante;
Console.Write("¿Es estudiante? (s/n): ");
while (true)
{
    string respuestaEstudiante = Console.ReadLine().ToLower();
    if (respuestaEstudiante == "s")
    {
        estudiante = true;
        break;
    }
    else if (respuestaEstudiante == "n")
    {
        estudiante = false;
        break;
    }
    else
    {
        Console.WriteLine("Error: Por favor, responda solo con 's' (sí) o 'n' (no).");
        Console.Write("¿Es estudiante? (s/n): ");
    }
}

//  Pedir si es Pareja 
bool pareja;
Console.Write("¿Compran como pareja (2 boletos)? (s/n): ");
while (true)
{
    string respuestaPareja = Console.ReadLine().ToLower();
    if (respuestaPareja == "s")
    {
        pareja = true;
        break;
    }
    else if (respuestaPareja == "n")
    {
        pareja = false;
        break;
    }
    else
    {
        Console.WriteLine("Error: Por favor, responda solo con 's' (sí) o 'n' (no).");
        Console.Write("¿Compran como pareja (2 boletos)? (s/n): ");
    }
}

//  Pedir si hay Promo Activa 
bool promo_activa;
Console.Write("¿Hay alguna promoción general activa? (s/n): ");
while (true)
{
    string respuestaPromo = Console.ReadLine().ToLower();
    if (respuestaPromo == "s")
    {
        promo_activa = true;
        break;
    }
    else if (respuestaPromo == "n")
    {
        promo_activa = false;
        break;
    }
    else
    {
        Console.WriteLine("Error: Por favor, responda solo con 's' (sí) o 'n' (no).");
        Console.Write("¿Hay alguna promoción general activa? (s/n): ");
    }
}

//  2. VARIABLES Y LÓGICA DE CÁLCULO 
double precio_base = 10000; 
// ===================================
double precioFinal = precio_base;
double porcentajeDescuentoTotal = 0.0;
List<string> descuentosAplicados = new List<string>();

bool esNocheDeFinDeSemana = (dia == "viernes" || dia == "sabado") && hora == "noche";

Console.WriteLine("\n Calculando precio... \n");

//  3. CASOS ESPECIALES 
if (edad < 12 && tipo_pelicula == "funcion_especial")
{
    Console.WriteLine("Resultado: Menores de 12 no pueden ingresar a funciones especiales.");
    return;
}

if (tipo_pelicula == "funcion_especial")
{
    if (edad < 18)
    {
        Console.WriteLine("Resultado: Solo mayores de 18 años pueden ingresar a funciones especiales.");
        return;
    }
    Console.WriteLine($"Precio Base: ${precio_base:N0}");
    Console.WriteLine("Descuentos Aplicados: Ninguno (Función Especial)");
    Console.WriteLine($"Precio Final a Pagar: ${precioFinal:N0}");
    return;
}

if (tipo_pelicula == "maraton")
{
    porcentajeDescuentoTotal = (edad >= 60) ? 0.50 : 0.20;
    descuentosAplicados.Add("Descuento Maratón");
    precioFinal = precio_base * (1 - porcentajeDescuentoTotal);

    Console.WriteLine($"Precio Base: ${precio_base:N0}");
    Console.WriteLine($"Descuentos Aplicados: {string.Join(", ", descuentosAplicados)}");
    Console.WriteLine($"Precio Final a Pagar: ${precioFinal:N0}");
    return;
}

//  4. LÓGICA PRINCIPAL DE DESCUENTOS 

// Por Edad
if (edad < 12)
{
    if (tipo_pelicula == "clasico" && (dia == "lunes" || dia == "miercoles"))
    {
        precioFinal = 0;
        descuentosAplicados.Add("Gratis niño");
    }
    else if (tipo_pelicula == "3d" && hora != "noche")
    {
        porcentajeDescuentoTotal += 0.70;
        descuentosAplicados.Add("Descuento Niño en 3D");
    }
}
else if (edad >= 12 && edad <= 17)
{
    if (tipo_pelicula == "clasico" && dia == "miercoles")
    {
        porcentajeDescuentoTotal += 0.50;
        descuentosAplicados.Add("50% Adolescente");
    }
}
else if (edad >= 60)
{
    porcentajeDescuentoTotal += (dia == "domingo" && promo_activa) ? 0.70 : 0.40;
    descuentosAplicados.Add("Descuento Senior");
}

// Por Día
if (dia == "miercoles")
{
    porcentajeDescuentoTotal += 0.20;
    descuentosAplicados.Add("20% Miércoles");
}

// Por Película
if (tipo_pelicula == "estreno" && estudiante)
{
    porcentajeDescuentoTotal += 0.15;
    descuentosAplicados.Add("15% Estudiante en Estreno");
}

// Por Membresía
if (!esNocheDeFinDeSemana)
{
    if (membresia == "silver" && tipo_pelicula == "3d" && dia != "domingo")
    {
        porcentajeDescuentoTotal += 0.20;
        descuentosAplicados.Add("20% Silver");
    }
    else if (membresia == "gold")
    {
        if (tipo_pelicula == "clasico")
        {
            porcentajeDescuentoTotal += 0.25;
            descuentosAplicados.Add("25% Gold");
        }
        else if (tipo_pelicula == "3d" && dia != "domingo")
        {
            porcentajeDescuentoTotal += 0.15;
            descuentosAplicados.Add("15% Gold");
        }
    }
    else if (membresia == "platino")
    {
        if (!(tipo_pelicula == "estreno" && dia == "sabado" && hora == "noche"))
        {
            porcentajeDescuentoTotal += 0.35;
            descuentosAplicados.Add("35% Platino");
        }
    }
}
else if (membresia != "ninguna")
{
    descuentosAplicados.Add("Membresía no aplica");
}

// Extras Acumulativos
if (estudiante && (dia == "lunes" || dia == "miercoles"))
{
    porcentajeDescuentoTotal += 0.10;
    descuentosAplicados.Add("10% Extra Estudiante");
}
if (pareja && dia != "domingo")
{
    porcentajeDescuentoTotal += 0.25;
    descuentosAplicados.Add("Promo Pareja");
}
if (promo_activa)
{
    if (dia == "domingo")
    {
        porcentajeDescuentoTotal += 0.10;
        descuentosAplicados.Add("10% Extra Promo Domingo");
    }
    else if (membresia != "ninguna")
    {
        porcentajeDescuentoTotal += 0.05;
        descuentosAplicados.Add("5% Extra Promo con Membresía");
    }
}

//  5. CÁLCULO FINAL Y RESULTADO 
if (precioFinal != 0)
{
    if (porcentajeDescuentoTotal > 1.0) porcentajeDescuentoTotal = 1.0;
    precioFinal = precio_base * (1 - porcentajeDescuentoTotal);
}

// Recargo 3D
if (tipo_pelicula == "3d")
{
    precioFinal *= 1.10;
    descuentosAplicados.Add("Recargo 10% 3D");
}

// Muestra el resultado
Console.WriteLine($"Precio Base: ${precio_base:N0}");
if (descuentosAplicados.Count == 0) descuentosAplicados.Add("Ninguno");
Console.WriteLine($"Descuentos Aplicados: {string.Join(" + ", descuentosAplicados)}");
Console.WriteLine($"Precio Final a Pagar: ${precioFinal:N0}");
