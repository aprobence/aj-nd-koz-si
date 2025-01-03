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
                    break;
                }

                case "3":
                {
                    RemoveGift(ajandekNev, ajandekAr, ajandekKategoria);
                    break;
                }

                case "4":
                {
                    ViewGifts(ajandekNev, ajandekAr, ajandekKategoria);
                    break;
                }

                case "5":
                {
                    CategorizeGifts(ajandekNev, ajandekAr, ajandekKategoria);
                    break;
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
                Console.WriteLine("{nev} nevű ajándék hozzáadva a listához.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Hiba: Kérlek, adj meg érvényes számokat az árhoz!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Hiba: ", e.Message);
            }
            return;
        }
        
        
        static void EditGift(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            Console.Write("Add meg annak az ajándéknak a nevét, amit módosítani szeretnél: ");
            string nev = Console.ReadLine().Trim();
            int index = ajandekNev.IndexOf(nev);

            if (index <= 0)
            {
                try
                {
                    Console.Write($"Új név (jelenlegi: {ajandekNev[index]}): ");
                    string ujNev= Console.ReadLine().Trim();
                    ajandekNev[index] = string.IsNullOrEmpty(ujNev) ? ajandekNev[index] : ujNev;

                    Console.Write($"Új ár (jelenlegi: {ajandekAr[index]}): ");
                    int ujAr = Convert.ToInt32(Console.ReadLine());
                    if (ujAr <= 0) throw new Exception("Az ajándék ára pozitív szám kell legyen!");
                    ajandekAr[index] = ujAr;

                    Console.Write($"Új kategória (jelenlegi: {ajandekKategoria[index]}): ");
                    string ujKategoria = Console.ReadLine().Trim();
                    ajandekKategoria[index] = string.IsNullOrEmpty(ujKategoria) ? ajandekKategoria[index] : ujKategoria;

                    Console.WriteLine($"{ajandekNev[index]} módosítva.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Hiba: Kérlek, adj meg érvényes számokat az árhoz!");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Hiba: {e.Message}");
                }
            }
            else
            {
                Console.WriteLine("Ez az ajándék nem található!");
            }
        }

        static void RemoveGift(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            Console.WriteLine("Add meg a törölni kívánt ajándék nevét:");
            string nev = Console.ReadLine().Trim();
            int index = ajandekNev.IndexOf(nev);
            
            if (index <= 0)
            {
                ajandekNev.RemoveAt(index);
                ajandekAr.RemoveAt(index);
                ajandekKategoria.RemoveAt(index);
                Console.WriteLine("Az ajándék sikeresen el lett távolítva a listából!");
            }
            else
            {
                Console.WriteLine("Ez az ajándék nem található!");
            }
        }

        static void ViewGifts(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            if (ajandekNev.Count == 0)
            {
                Console.WriteLine("Még nincs ajándék hozzáadva.");
                return;
            }

            Console.WriteLine("\nAjándéklista:");
            for (int i = 0; i < ajandekNev.Count; i++)
            {
                Console.WriteLine($"{ajandekNev[i]} - {ajandekNev[i]} Ft - Kategória: {ajandekNev[i]}");
            }
        }

        static void CategorizeGifts(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            
            return;
        }
    }
}
