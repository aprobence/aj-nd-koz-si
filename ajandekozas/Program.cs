using System.Resources;
using System.Xml;

namespace ajandekozas;

class Program
{
    static void Main(string[] args)
    {
        List<string> ajandekNev = new List<string>();
        List<int> ajandekAr = new List<int>();
        List<string> ajandekKategoria = new List<string>();
        bool fut = true;
        int koltseg = 0;
        Console.WriteLine("Karácsonyi Ajándéktervező Program");

        while (true)
        {
            try
            {
                Console.WriteLine("Kérlek állítsd be a költségvetésed!");
                koltseg = Convert.ToInt32(Console.ReadLine());
                if (koltseg < 0)
                {
                    Console.WriteLine("Negatív költségvetést nem lehet beállítani!");
                }
                else
                {
                    Console.WriteLine($"Költségvetés beállítva ({koltseg} ft)");
                    break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Kérlek, egy számot adj meg a költségvetéshez!");
            }
        }

        while (fut == true)
        {
            Console.WriteLine("\nVálassz egy opciót:");
            Console.WriteLine("1. Ajándék hozzáadása");
            Console.WriteLine("2. Ajándék módosítása");
            Console.WriteLine("3. Ajándék eltávolítása");
            Console.WriteLine("4. Ajándékok megtekintése");
            Console.WriteLine("5. Költségvetés ellenőrzése");
            Console.WriteLine("6. Statisztikák megtekintése");
            Console.WriteLine("7. Kilépés");

            string valasztas = Console.ReadLine();
            switch (valasztas)
            {
                case "1":
                {
                    AddGift(ajandekNev, ajandekAr, ajandekKategoria);
                    break;
                }

                case "2":
                {
                    EditGift(ajandekNev, ajandekAr, ajandekKategoria);
                }
            }
        }

        static void AddGift(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            try
            {
                Console.WriteLine("Jándék neve:");
                string nev = Console.ReadLine();
                if (string.IsNullOrEmpty(nev)) throw new Exception("Az ajándék neve nem lehet üres.");
                Console.WriteLine("Ár:");
                int ar = Convert.ToInt32(Console.ReadLine());
                if (int.IsNegative(ar)) throw new Exception("A termék ára nem lehet negatív!");
                Console.WriteLine("Kategória:");
                string kategoria = Console.ReadLine();
                if (string.IsNullOrEmpty(kategoria)) throw new Exception("Az ajándék kategóriája nem lehet üres.");
                
                ajandekNev.Add(nev);
                ajandekAr.Add(ar);
                ajandekKategoria.Add(kategoria);
            }
            catch (FormatException)
            {
                Console.WriteLine("Hiba: Kérlek, adj meg érvényes számokat az árhoz!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba: ", e.Message);
            }

            Console.WriteLine("{nev} nevű ajándék hozzáadva a listához.");
            return;
        }
        
        
        static void EditGift(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            Console.Write("Add meg annak az ajándéknak a nevét, amit módosítani szeretnél: ");
            string nev = Console.ReadLine().Trim();
            int index = ajandekNev.IndexOf(nev);
        }
    }
}
