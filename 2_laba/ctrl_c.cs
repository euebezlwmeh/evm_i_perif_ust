using System;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        Console.WriteLine("Press any key...");
        while (true)
        {
            ConsoleKeyInfo cki;
            Console.CancelKeyPress += new ConsoleCancelEventHandler(myHandler);
            while (true)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Delete)
                {
                    Environment.Exit(0);
                } 
            }
        }
    }

    protected static void myHandler(object sender, ConsoleCancelEventArgs args)
    {
        Console.WriteLine("\nThe read operation has been interrupted.");
        Console.WriteLine("  Key pressed: {0}", args.SpecialKey);
        Console.WriteLine("  Cancel property: {0}", args.Cancel);
        Console.WriteLine("Setting the Cancel property to true...");
        args.Cancel = true;
        Console.WriteLine("  Cancel property: {0}", args.Cancel);
        Console.WriteLine("The read operation will resume...\n");
    }
}
