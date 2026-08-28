using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* 
Fejl fra staten:
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
    
    static void Main(string[] args)
    {
        Methods Methods = new Methods();
        bool indtaster = true;
        string produktNavn = "";
        string brugerNavn = "";
        int brugerTelefonnummer = 0;
        string leveringsAdresse = "";
        Console.Clear();
        
        List<ProductUnit> alleProdukter = new List<ProductUnit>();
        
        Console.WriteLine("Registrering af bruger");
        Console.WriteLine("Indtast navn: ");
        brugerNavn = Console.ReadLine();
        brugerTelefonnummer = Methods.InputInt("Indtast telefonnummer: ");
        Customer bruger = new Customer(brugerNavn, brugerTelefonnummer);
        
        while (indtaster)
        {

            Console.Clear();
            bool vilFortsaette = true;
            while (vilFortsaette)
            {
                Console.Clear();
                alleProdukter.Add(Methods.ProductUnitCreation());
                Console.WriteLine("Vil du gerne tilføje en til vare? (y/n)");
                char svar = Console.ReadKey().KeyChar;
                if (svar == 'y')
                {
                    vilFortsaette = false;
                }
                else if (svar == 'n')
                {
                    vilFortsaette = false;
                    indtaster = false;
                }
            }

        }

        indtaster = true;

        Console.Clear();
        Console.WriteLine("Indtast leverings adresse: ");
        leveringsAdresse = Console.ReadLine();

        Console.Clear();
        Order ordre = new Order(bruger, leveringsAdresse, alleProdukter);
        Console.WriteLine($"Navn: {ordre.Customer.Name}\nTelefonnummer: {ordre.Customer.PhoneNumber}\nLeveringsadresse: {ordre.DeliveryAddress}");
        foreach (var pu in ordre.Products)
        {
            Console.WriteLine($"Vare: {pu.Product.Name} af {pu.Product.Price} kr stk x {pu.Quantity} = {pu.Product.Price * pu.Quantity} kr");
        }
        if (ordre.HasDiscount)
        {
            Console.WriteLine($"Total pris efter rabat (15%): {ordre.TotalPrice},- kr");
        }
        else
        {
            Console.WriteLine($"Total pris: {ordre.TotalPrice},- kr");
        }
        Console.ReadKey();
    }
}
class Methods
{
    public int InputInt(string besked)
    {
        bool indtaster = true;
        int output = 0;
        while (indtaster)
        {
            Console.Clear();
            Console.WriteLine(besked);
            string input = Console.ReadLine();

            if (int.TryParse(input, out int number))
            {
                output = number;
                indtaster = false;
            }
            else
            {
                Console.WriteLine("Ikke validt input, prøv igen");
                Console.ReadKey();
            }

        }
        return output;
    }
    public decimal InputDecimal(string besked)
    {
        bool indtaster = true;
        decimal output = 0;
        while (indtaster)
        {
            Console.Clear();
            Console.WriteLine(besked);
            string input = Console.ReadLine();

            if (decimal.TryParse(input, out decimal number))
            {
                output = number;
                indtaster = false;
            }
            else
            {
                Console.WriteLine("Ikke validt input, prøv igen");
                Console.ReadKey();
            }

        }
        return output;
    }

    public ProductUnit ProductUnitCreation()
    {
        const int MAXQUANTITY = 100;
        Console.WriteLine("Navnet på vare: ");
        string navn = Console.ReadLine();
        decimal pris = InputDecimal("Indtast pris: ");
        Product vare = new Product(navn, pris);
        bool indtasterAntal = true;
        int antal = 0;
        while (indtasterAntal)
        {
            Console.Clear();
            antal = InputInt("Indtast antal: ");
            if (antal > MAXQUANTITY)
            {
                Console.WriteLine($"Du har overskredet max antal for denne vare ({MAXQUANTITY}), vælg et mindre antal");
                Console.ReadKey();
            }
            else
            {
                indtasterAntal = false;
            }
        }
        
        ProductUnit vareEnhed = new ProductUnit(vare, antal);
        return vareEnhed;
    }
}
class Customer
{
    public string Name { get; set; }
    public int PhoneNumber { get; set; }
    public Customer(string name, int phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Product(string name, decimal price)
    {
        Name = name;
        Price = price;
    }
}
class ProductUnit
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public ProductUnit(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

}

class Order
{
    public Customer Customer { get; set; }
    public string DeliveryAddress { get; set; }
    public List<ProductUnit> Products { get; set; }
    public decimal Subtotal
    {
        get
        {
            decimal price = 0;
            foreach (var pu in Products)
            {
                price += pu.Product.Price * pu.Quantity;
            }
            return price;
        }
    }
    public bool HasDiscount {
        get
        {
            return Subtotal > 500;
        } }
    public decimal TotalPrice
    {
        get
        {
            decimal discount = 0.15m;
            
            if (HasDiscount)
            {
                return Subtotal - (Subtotal * discount);
            }
            return Subtotal;
        }
    }
    

    public Order(Customer customer, string deliveryAddress, List<ProductUnit> products)
    {
        Customer = customer;
        DeliveryAddress = deliveryAddress;
        Products = products;
    }

}
