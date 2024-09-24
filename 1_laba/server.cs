using System;
using System.IO;
using System.IO.Pipes;

public struct User
{
    public string name;
    public string hometown;
};

class PipeServer
{
    static void Main()
    {
        using (NamedPipeServerStream pipeServer =
            new NamedPipeServerStream("testpipe", PipeDirection.Out))
        {
            Console.WriteLine("NamedPipeServerStream object created.");
            Console.Write("Waiting for client connection...");
            pipeServer.WaitForConnection();

            Console.WriteLine("Client connected.");
            try
            {
                User newUser = new User();

                Console.WriteLine("Enter name: ");
                newUser.name = Console.ReadLine();

                Console.WriteLine("Enter hometown: ");
                newUser.hometown = Console.ReadLine();

                string result = string.Format("Name: {0}\nHometown: {1}", newUser.name, newUser.hometown);

                using (StreamWriter sw = new StreamWriter(pipeServer))  // StreamWriter использовать нельзя
                {
                    sw.AutoFlush = true;
                    sw.WriteLine(result);
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("ERROR: {0}", e.Message);
            }
        }
    }
}