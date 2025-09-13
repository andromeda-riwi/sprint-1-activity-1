using System;

decimal BasePrice = 10000m;

Console.WriteLine("Ingresa tu edad:");
int Age = int.Parse(Console.ReadLine() ?? "0");

string MovieType = "";
bool IsValidMovieType = false;
while (!IsValidMovieType)
{
    Console.WriteLine("Tipo de película (estreno, clasico, 3d, maraton, funcion_especial):");
    MovieType = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
    if (MovieType == "estreno") IsValidMovieType = true;
    else if (MovieType == "clasico") IsValidMovieType = true;
    else if (MovieType == "3d") IsValidMovieType = true;
    else if (MovieType == "maraton") IsValidMovieType = true;
    else if (MovieType == "funcion_especial") IsValidMovieType = true;
    else Console.WriteLine("Opción inválida.");
}

string Day = "";
bool IsValidDay = false;
while (!IsValidDay)
{
    Console.WriteLine("Día de la semana (lunes a domingo):");
    Day = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
    if (Day == "lunes") IsValidDay = true;
    else if (Day == "martes") IsValidDay = true;
    else if (Day == "miercoles") IsValidDay = true;
    else if (Day == "miércoles") IsValidDay = true;
    else if (Day == "jueves") IsValidDay = true;
    else if (Day == "viernes") IsValidDay = true;
    else if (Day == "sabado") IsValidDay = true;
    else if (Day == "sábado") IsValidDay = true;
    else if (Day == "domingo") IsValidDay = true;
    else Console.WriteLine("Día inválido.");
}

string TimeOfDay = "";
bool IsValidTime = false;
while (!IsValidTime)
{
    Console.WriteLine("Hora (mañana, tarde, noche):");
    TimeOfDay = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
    if (TimeOfDay == "mañana") IsValidTime = true;
    else if (TimeOfDay == "tarde") IsValidTime = true;
    else if (TimeOfDay == "noche") IsValidTime = true;
    else Console.WriteLine("Hora inválida.");
}

string Membership = "";
bool IsValidMembership = false;
while (!IsValidMembership)
{
    Console.WriteLine("Membresía (ninguna, silver, gold, platino):");
    Membership = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
    if (Membership == "ninguna") IsValidMembership = true;
    else if (Membership == "silver") IsValidMembership = true;
    else if (Membership == "gold") IsValidMembership = true;
    else if (Membership == "platino") IsValidMembership = true;
    else Console.WriteLine("Membresía inválida.");
}

bool PromoActive = false;
bool PromoAnswered = false;
while (!PromoAnswered)
{
    Console.WriteLine("Promo activa? (si/no):");
    string s = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
    if (s == "si") { PromoActive = true; PromoAnswered = true; }
    else if (s == "no") { PromoActive = false; PromoAnswered = true; }
    else Console.WriteLine("Responde con si/no.");
}

bool Student = false;
bool StudentAnswered = false;
while (!StudentAnswered)
{
    Console.WriteLine("Eres estudiante? (si/no):");
    string s = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
    if (s == "si") { Student = true; StudentAnswered = true; }
    else if (s == "no") { Student = false; StudentAnswered = true; }
    else Console.WriteLine("Responde con si/no.");
}

bool Couple = false;
bool CoupleAnswered = false;
while (!CoupleAnswered)
{
    Console.WriteLine("Vienes en pareja? (si/no):");
    string s = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();
    if (s == "si") { Couple = true; CoupleAnswered = true; }
    else if (s == "no") { Couple = false; CoupleAnswered = true; }
    else Console.WriteLine("Responde con si/no.");
}

decimal FinalPrice = BasePrice;
string DiscountsApplied = "";
string Sep = "";

bool IsWednesday = false;
if (Day == "miercoles") IsWednesday = true; else if (Day == "miércoles") IsWednesday = true;

bool IsFriday = false;
if (Day == "viernes") IsFriday = true;

bool IsSaturday = false;
if (Day == "sabado") IsSaturday = true; else if (Day == "sábado") IsSaturday = true;

bool IsSunday = false;
if (Day == "domingo") IsSunday = true;

bool IsMonday = false;
if (Day == "lunes") IsMonday = true;

bool IsNight = false;
if (TimeOfDay == "noche") IsNight = true;

bool IsFridayOrSaturday = false;
if (IsFriday) IsFridayOrSaturday = true; else if (IsSaturday) IsFridayOrSaturday = true;

bool MembershipBlocked = false;
if (IsFridayOrSaturday)
{
    if (IsNight) MembershipBlocked = true;
}

if (Age < 12)
{
    if (MovieType == "funcion_especial")
    {
        Console.WriteLine("Prohibido: niños no pueden entrar a función especial");
        return;
    }

    if (MovieType == "clasico")
    {
        if (IsMonday) { FinalPrice = 0m; DiscountsApplied += Sep + "Niño gratis clásico (lunes/miércoles)"; Sep = " + "; }
        else if (IsWednesday) { FinalPrice = 0m; DiscountsApplied += Sep + "Niño gratis clásico (lunes/miércoles)"; Sep = " + "; }
    }
    else if (MovieType == "3d")
    {
        if (!IsNight)
        {
            FinalPrice = Math.Round(BasePrice * 0.30m, 2, MidpointRounding.AwayFromZero);
            DiscountsApplied += Sep + "Niño 30% en 3D antes de 6pm"; Sep = " + ";
        }
    }
}
else if (Age <= 17)
{
    if (MovieType == "estreno")
    {
        FinalPrice = BasePrice;
        DiscountsApplied += Sep + "Adolescente: estreno paga base"; Sep = " + ";
    }
    else
    {
        if (MovieType == "clasico")
        {
            if (IsWednesday)
            {
                FinalPrice = Math.Round(BasePrice * 0.50m, 2, MidpointRounding.AwayFromZero);
                DiscountsApplied += Sep + "Adolescente 50% clásico (miércoles)"; Sep = " + ";
            }
        }
        else
        {
            if (MovieType == "3d")
            {
                if (Membership == "silver")
                {
                    if (!IsSunday)
                    {
                        FinalPrice = Math.Round(BasePrice * 0.80m, 2, MidpointRounding.AwayFromZero);
                        DiscountsApplied += Sep + "Adolescente + Silver 20% 3D (no domingo)"; Sep = " + ";
                    }
                }
            }
        }
    }
}
else if (Age <= 59)
{
    if (MovieType == "estreno") { FinalPrice = BasePrice; DiscountsApplied += Sep + "Adulto: estreno paga base"; Sep = " + "; }
    else if (MovieType == "funcion_especial") { FinalPrice = BasePrice; DiscountsApplied += Sep + "Adulto: especial paga base"; Sep = " + "; }
}
else
{
    if (MovieType == "maraton")
    {
        FinalPrice = Math.Round(BasePrice * 0.50m, 2, MidpointRounding.AwayFromZero);
        DiscountsApplied += Sep + "Senior 50% maratón"; Sep = " + ";
    }
    else
    {
        if (IsSunday)
        {
            if (PromoActive)
            {
                FinalPrice = Math.Round(BasePrice * 0.30m, 2, MidpointRounding.AwayFromZero);
                DiscountsApplied += Sep + "Senior 70% (domingo + promo)"; Sep = " + ";
            }
            else
            {
                FinalPrice = Math.Round(BasePrice * 0.60m, 2, MidpointRounding.AwayFromZero);
                DiscountsApplied += Sep + "Senior 40%"; Sep = " + ";
            }
        }
        else
        {
            FinalPrice = Math.Round(BasePrice * 0.60m, 2, MidpointRounding.AwayFromZero);
            DiscountsApplied += Sep + "Senior 40%"; Sep = " + ";
        }
    }
}

if (IsWednesday)
{
    if (MovieType != "funcion_especial")
    {
        FinalPrice = Math.Round(FinalPrice * 0.80m, 2, MidpointRounding.AwayFromZero);
        DiscountsApplied += Sep + "Miércoles 20% global"; Sep = " + ";
    }
}

if (MovieType == "estreno")
{
    if (Student)
    {
        FinalPrice = Math.Round(FinalPrice * 0.85m, 2, MidpointRounding.AwayFromZero);
        DiscountsApplied += Sep + "Estudiante 15% estreno"; Sep = " + ";
    }
}
else
{
    if (MovieType == "maraton")
    {
        if (Age < 60)
        {
            FinalPrice = Math.Round(FinalPrice * 0.80m, 2, MidpointRounding.AwayFromZero);
            DiscountsApplied += Sep + "Maratón 20% (no-senior)"; Sep = " + ";
        }
    }
    else
    {
        if (MovieType == "funcion_especial")
        {
            DiscountsApplied += Sep + "Función especial sin descuentos"; Sep = " + ";
        }
    }
}

if (!MembershipBlocked)
{
    if (MovieType != "funcion_especial")
    {
        if (Membership == "gold")
        {
            if (MovieType == "clasico")
            {
                if (!IsFriday)
                {
                    if (!IsSaturday || !IsNight)
                    {
                        if (!IsNight)
                        {
                            FinalPrice = Math.Round(FinalPrice * 0.75m, 2, MidpointRounding.AwayFromZero);
                            DiscountsApplied += Sep + "Gold 25% clásico (no vie/sáb noche)"; Sep = " + ";
                        }
                        else
                        {
                            if (!IsSaturday)
                            {
                                FinalPrice = Math.Round(FinalPrice * 0.75m, 2, MidpointRounding.AwayFromZero);
                                DiscountsApplied += Sep + "Gold 25% clásico (no vie/sáb noche)"; Sep = " + ";
                            }
                        }
                    }
                }
            }
            if (MovieType == "3d")
            {
                if (!IsSunday)
                {
                    FinalPrice = Math.Round(FinalPrice * 0.85m, 2, MidpointRounding.AwayFromZero);
                    DiscountsApplied += Sep + "Gold 15% 3D (no domingo)"; Sep = " + ";
                }
            }
        }
        else if (Membership == "platino")
        {
            bool IsEstrenoSabadoNoche = false;
            if (MovieType == "estreno")
            {
                if (IsSaturday)
                {
                    if (IsNight) IsEstrenoSabadoNoche = true;
                }
            }
            if (!IsEstrenoSabadoNoche)
            {
                FinalPrice = Math.Round(FinalPrice * 0.65m, 2, MidpointRounding.AwayFromZero);
                DiscountsApplied += Sep + "Platino 35%"; Sep = " + ";
            }
        }
    }
}
else
{
    DiscountsApplied += Sep + "Bloqueo membresía (vie/sáb noche)"; Sep = " + ";
}

if (Student)
{
    if (MovieType != "funcion_especial")
    {
        if (IsMonday || IsWednesday)
        {
            FinalPrice = Math.Round(FinalPrice * 0.90m, 2, MidpointRounding.AwayFromZero);
            DiscountsApplied += Sep + "Estudiante extra 10% (lunes/miércoles)"; Sep = " + ";
        }
    }
}

if (PromoActive)
{
    if (IsSunday)
    {
        if (MovieType != "funcion_especial")
        {
            FinalPrice = Math.Round(FinalPrice * 0.90m, 2, MidpointRounding.AwayFromZero);
            DiscountsApplied += Sep + "Promo domingo 10%"; Sep = " + ";
        }
    }
    else
    {
        if (Membership != "ninguna")
        {
            FinalPrice = Math.Round(FinalPrice * 0.95m, 2, MidpointRounding.AwayFromZero);
            DiscountsApplied += Sep + "Promo +5% (Silver+)"; Sep = " + ";
        }
    }
}

if (MovieType == "3d")
{
    FinalPrice = Math.Round(FinalPrice * 1.10m, 2, MidpointRounding.AwayFromZero);
    DiscountsApplied += Sep + "Recargo 3D +10%"; Sep = " + ";
}

if (Couple)
{
    if (!IsSunday)
    {
        FinalPrice = Math.Round(FinalPrice + (FinalPrice * 0.50m), 2, MidpointRounding.AwayFromZero);
        DiscountsApplied += Sep + "Pareja: 2° boleto 50% (no domingo)"; Sep = " + ";
    }
}

Console.WriteLine("Precio base: " + BasePrice);
if (DiscountsApplied == "") Console.WriteLine("Descuentos aplicados: Ninguno");
else Console.WriteLine("Descuentos aplicados: " + DiscountsApplied);
Console.WriteLine("Total a pagar: " + FinalPrice);
