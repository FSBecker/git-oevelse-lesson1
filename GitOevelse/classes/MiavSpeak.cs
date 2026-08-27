namespace MiavN;

class Miav
{
    public void MiavLoop()
    {
        bool isUsing = true;
        Console.WriteLine("You see a cat, what do you do?");
        while (isUsing)
        {
            string input = Console.ReadLine();
            string output = MiavCalc(input);
            Console.WriteLine(output);
            if (input == "exit")
            {
                Console.ReadKey();
                isUsing = false;
            }
        }
    }
    public string MiavCalc(string input)
    {
        string output = "";
        string[] hundeOrd =
        {
            "vuf",
            "vov",
            "bark",
            "dog",
            "hund",
            "doggo",
            "puppy",
            "leika"
        };
        string[] katteOrd =
        {
            "purr",
            "pet",
            "tuna",
            "tun",
            "milk",
            "mælk",
            "pspsps"
        };
        input = input.ToLower();
        if (hundeOrd.Contains(input))
        {
            output = "hiss";
        }
        else if (katteOrd.Contains(input))
        {
            output = "purr";
        }
        else if (input == "exit")
        {
            output = "fr?? ok ig";
        }
        else
        {
            output = "miav";
        }
        return output;
    }
}