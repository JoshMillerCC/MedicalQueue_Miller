using System;

namespace MedicalQueue_Miller
{
    class Program
    {
        static void Main(string[] args)
        {
            ERQueue ERQ = new ERQueue();
            menu();
            var input = Console.ReadKey(true);
            bool menustuff = true;

            while(menustuff)
            {
                switch (input.Key)
                {
                    case ConsoleKey.A:
                        Console.WriteLine("Name of patient?");
                        string name = Console.ReadLine();
                        Console.WriteLine("Patient priority? 1 being the highest, 5 being the lowest.");
                        string priority = Console.ReadLine();
                        int priorityNumber;
                        while(!Int32.TryParse(priority, out priorityNumber) || (priorityNumber > 5 || priorityNumber < 1))
                        {
                            Console.WriteLine("Priority has to be 1-5, 1 being highest, 5 being lowest.\n");
                            priority = Console.ReadLine();
                        }
                        int total = ERQ.Enqueue(name, priorityNumber);
                        if(total == -1)
                        {
                            Console.WriteLine("No patient added, queue full.\n");
                        }
                        else
                        {
                            Console.Write("Total patients in queue: " + total + ".\n\n");
                        }
                        menu();
                        input = Console.ReadKey(true);
                        break;

                    case ConsoleKey.P:
                        Patient p = ERQ.Dequeue();
                        if (p == null)
                        {
                            Console.WriteLine("There is nobody is in the queue.\n");
                        }
                        else
                        {
                            Console.WriteLine("Patient, " + p.getName() + "/" + p.getPriority() + " has been processed.\n");
                        }
                        menu();
                        input = Console.ReadKey(true);
                        break;

                    case ConsoleKey.L:
                        Console.WriteLine(ERQ.ToString());
                        menu();
                        input = Console.ReadKey(true);
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Please type a valid input.\n");
                        break;
                }
            }
            
        }

        public static void menu()
        {
            Console.WriteLine("(A)dd as Patient to the queue.");
            Console.WriteLine("(P)rocess current Patient.");
            Console.WriteLine("(L)ist all in queue.");
            Console.WriteLine("(Q)uit.\n");
        }
    }
}
