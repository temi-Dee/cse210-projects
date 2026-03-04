class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("what is your first name? ");
        string first = Console.ReadLine();

        Console.Write("what is your last name? ");
        string last = Console.ReadLine();


        Console.WriteLine($"Your name is {last}, {first} {last}");
    }
}