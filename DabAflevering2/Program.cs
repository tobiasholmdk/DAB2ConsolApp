using System;
using DabAflevering2.DBContext;


/* Dab aflevering 2: Medlemmer, Tobias Holm, Gustav Hjortshøj Sørensen og Sebastian Laczek Nielsen */


namespace DabAflevering2
{
    class Program
    {
        static void Main(string[] args)
        {
            var c = new CreateData();
            var db = new DabDBContext();
            var a = new DummyData();
            var v = new Views(db);
            bool loop = true;
            Console.WriteLine("----------------------------------------------------------------------------------------");
            Console.WriteLine("Welcome to DabAflevering, for investigating the database use the following commands:");
            Console.WriteLine("----------------------------------------------------------------------------------------");

            while (loop == true)
            {
                Console.WriteLine("Press 1 to view data");
                Console.WriteLine("Press 2 To add Dummy Data");
                Console.WriteLine("Press 3 to create new data");
                Console.WriteLine("Press 4 to exit program");
                Console.WriteLine("----------------------------------------------------------------------------------------");

                var input = Console.ReadLine();
                
                switch (input)
                {
                    case "1":
                        v.ViewsSwitcher();
                        Console.Clear();
                        break;
                    case "2":
                        Console.Clear();
                        a.InsertDummyData();
                        break;
                    case "3":
                        c.CreateDataHandler(db);
                        db.SaveChanges();
                        Console.Clear();
                        break;
                    case "4":
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        Console.WriteLine("Bye bye!");
                        Console.WriteLine("----------------------------------------------------------------------------------------");
                        loop = false;
                        break;
                } 
            }
        }
    }
}