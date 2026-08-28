// KodestandardTjekliste.cs
//
// ØVELSESFIL — Modul 3, Lektion 5.
// Denne fil "virker" (den kompilerer og giver korrekte resultater), men
// overtræder Microsofts C#-kodestandard på en lang række punkter.
//
// DIN OPGAVE: Find og noter, hvilke KATEGORIER af fejl du kan se i filen
// (ikke bare hvert enkelt sted — men hvilken type problem det er), og ret
// derefter filen, så den fuldt ud overholder kodestandarden fra materiale.md.
//
// Underviserens facitliste findes i KodestandardTjekliste-FACIT.md i denne
// mappe — kig IKKE i den, før du selv har lavet øvelsen færdig.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 
Fejl:
1. Errorhandling ved string til int og double
2. Class navngivning er camelCase og lowercase
3. Const er camelCase
4. Public stringer er lowercase
5. Metode er snakecase+camelCase
6. var bliver brugt når typen den kopiere værdien fra vides
7. Magic numbers ved 0.15
8. Hungarian navngivning ved variabler
*/
class ProductCalculator
{
    const int MAXQUANTITY = 100;

    static void Main(string[] args)
    {
        bool indtaster = true;
        int quantity = 0;
        double price = 0;
        double discount = 0.15;
        string input = "";
        double fuldPris = 0;
        double discountPris = 0;
        double fratrukket = 0;

        while (indtaster)
        {
            Console.Clear();
            Console.WriteLine("Indtast antal varer:");
            input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                quantity = number;
                indtaster = false;
            }
            else
            {
                Console.WriteLine("Ikke validt input, prøv igen");
                Console.ReadKey();
            }

        }
        indtaster = true;
        while (indtaster)
        {
            Console.Clear();
            Console.WriteLine("Indtast pris pr. vare");
            input = Console.ReadLine();

            if (double.TryParse(input, out double number))
            {
                price = number;
                indtaster = false;
            }
            else
            {
                Console.WriteLine("Ikke validt input, prøv igen");
                Console.ReadKey();
            }

        }
        Console.Clear();

        fuldPris = quantity * price;

        if (fuldPris > 500)
        {
            fratrukket = fuldPris * discount;
            discountPris = fuldPris - fratrukket;
            Console.WriteLine("Før rabat: " + fuldPris);
            Console.WriteLine("Rabat: " + fratrukket);
            Console.WriteLine("Total: " + discountPris);
        }
        else
        {
            Console.WriteLine("Total: " + fuldPris);
        }

        string message = CalculateStatus(quantity);
        Console.WriteLine(message);
    }

    static string CalculateStatus(int quantity)
    {
        if (quantity > 50)
        {
            return "Stor ordre";
        }
        return "Almindelig ordre";
    }
}

class Customer
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }
}
