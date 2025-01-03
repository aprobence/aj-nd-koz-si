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
            Console.WriteLine("5. Kategóriák megtekintése");
            Console.WriteLine("6. Költségvetés ellenőrzése");
            Console.WriteLine("7. Statisztikák megtekintése");
            Console.WriteLine("8. Kilépés");

            string valasztas = Console.ReadLine();
            switch (valasztas)
            {
                case "1":
                    AddGift(ajandekNev, ajandekAr, ajandekKategoria);
                    break;

                case "2":
                    EditGift(ajandekNev, ajandekAr, ajandekKategoria);
                    break;

                case "3":
                    RemoveGift(ajandekNev, ajandekAr, ajandekKategoria);
                    break;

                case "4":
                    ViewGifts(ajandekNev, ajandekAr, ajandekKategoria);
                    break;

                case "5":
                    CategorizeGifts(ajandekNev, ajandekAr, ajandekKategoria);
                    break;
                
                case "6":
                    CheckBudget(koltseg, ajandekAr);
                    break;
                
                case "7":
                    ShowStatistics(ajandekNev, ajandekAr);
                    break;
                
                case "8":
                    fut = false;
                    Console.WriteLine("Kellemes karácsonyt! 🎄");
                    break;
                
                default:
                    Console.WriteLine("Érvénytelen választás! Próbáld újra.");
                    break;
            }
        }

        static void AddGift(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            try
            {
                Console.WriteLine("Ajándék neve:");
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
                Console.WriteLine("Hiba: {e.Message}");
            }
        }
        
        
        static void EditGift(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            Console.Write("Add meg annak az ajándéknak a nevét, amit módosítani szeretnél: ");
            string nev = Console.ReadLine();
            int index = ajandekNev.IndexOf(nev);

            if (index <= 0)
            {
                try
                {
                    Console.Write($"Új név (jelenlegi: {ajandekNev[index]}): ");
                    string ujNev= Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(ujNev)) ajandekNev[index] = ujNev;

                    Console.Write($"Új ár (jelenlegi: {ajandekAr[index]}): ");
                    int ujAr = Convert.ToInt32(Console.ReadLine());
                    if (ujAr <= 0) throw new Exception("Az ajándék ára pozitív szám kell legyen!");
                    ajandekAr[index] = ujAr;

                    Console.Write($"Új kategória (jelenlegi: {ajandekKategoria[index]}): ");
                    string ujKategoria = Console.ReadLine();
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
            string nev = Console.ReadLine();
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
                Console.WriteLine($"{ajandekNev[i]} - {ajandekAr[i]} Ft - Kategória: {ajandekKategoria[i]}");
            }
        }

        static void CategorizeGifts(List<string> ajandekNev, List<int> ajandekAr, List<string> ajandekKategoria)
        {
            if (ajandekNev.Count == 0)
            {
                Console.WriteLine("Még nincs ajándék hozzáadva.");
                return;
            }

            var kategoriak = new Dictionary<string, List<string>>();
            for (int i = 0; i < ajandekKategoria.Count; i++)
            {
                if (!kategoriak.ContainsKey(ajandekKategoria[i]))
                    kategoriak[ajandekKategoria[i]] = new List<string>();

                kategoriak[ajandekKategoria[i]].Add(ajandekNev[i]);
            }

            Console.WriteLine("\nAjándékok kategóriák szerint:");
            foreach (var kategoria in kategoriak)
            {
                Console.WriteLine($"{kategoria.Key}: {string.Join(", ", kategoria.Value)}");
            }
        }

        static void CheckBudget(int koltseg, List<int> ajandekAr)
        {
            int osszesAr = 0;
            foreach (int ar in ajandekAr)
            {
                osszesAr += ar;
            }

            Console.WriteLine($"Eddig elköltött összeg: {osszesAr} Ft");
            Console.WriteLine($"Hátralévő költségvetés: {koltseg - osszesAr} Ft");

            if (osszesAr > koltseg)
            {
                Console.WriteLine("Figyelmeztetés: Túllépted a költségvetést!");
            }
        }

        static void ShowStatistics(List<string> ajandekNev, List<int> ajandekAr)
        {
            if (ajandekNev.Count == 0)
            {
                Console.WriteLine("Még nincs ajándék hozzáadva.");
                return;
            }

            int maxAr = ajandekAr[0];
            int minAr = ajandekAr[0];
            int osszesen = 0;
            string legdragabb = "", legolcsobb = "";

            for (int i = 0; i < ajandekAr.Count; i++)
            {
                osszesen += ajandekAr[i];
                if (ajandekAr[i] > maxAr)
                {
                    maxAr = ajandekAr[i];
                    legdragabb = ajandekNev[i];
                }
                if (ajandekAr[i] < minAr)
                {
                    minAr = ajandekAr[i];
                    legolcsobb = ajandekNev[i];
                }
            }

            Console.WriteLine($"Ajándékok száma: {ajandekNev.Count}");
            Console.WriteLine($"Összes ár: {osszesen} Ft");
            Console.WriteLine($"Legdrágább ajándék: {legdragabb} ({maxAr} Ft)");
            Console.WriteLine($"Legolcsóbb ajándék: {legolcsobb} ({minAr} Ft)");
        }
    }
}
