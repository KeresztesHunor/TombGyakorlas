namespace TombGyakorlas
{
    internal class Program()
    {
        static readonly Random rnd = new Random();

        static void Main(string[] args)
        {
            new Program().Feladatok();
            Console.ReadLine();
        }

        void Feladatok()
        {
            Console.WriteLine("A feladatok normálisan:\n");
            Normalisan();
            Console.WriteLine("\nMost a feladatok megint, de a vicces megoldásokkal:\n");
            Viccesen();
        }

        void Normalisan()
        {
            Console.Write("Add meg a véletlen számok alsó határát (inkluzív): ");
            int alsoHatar = int.Parse(Console.ReadLine()!);
            Console.Write("Add meg a véletlen számok felső határát (exkluzív): ");
            int felsoHatar = int.Parse(Console.ReadLine()!);
            int[] tomb = new int[15];
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(alsoHatar, felsoHatar);
            }
            Console.Write("Sorban: ");
            for (int i = 0; i < tomb.Length - 1; i++)
            {
                Console.Write(tomb[i] + ", ");
            }
            Console.WriteLine(tomb[tomb.Length - 1]);
            Console.Write("Visszafele: ");
            for (int i = tomb.Length - 1; i > 0; i--)
            {
                Console.Write(tomb[i] + ", ");
            }
            Console.WriteLine(tomb[0]);
            int osszeg = 0;
            foreach (int szam in tomb)
            {
                osszeg += szam;
            }
            Console.WriteLine("Összeg: " + osszeg);
            Console.WriteLine("Átlag: " + (osszeg / (float)tomb.Length));
            Console.WriteLine("5-tel oszthatóak:");
            foreach (int szam in tomb)
            {
                if (szam % 5 == 0)
                {
                    Console.WriteLine(szam);
                }
            }
            Console.Write("Adj meg egy egész számot aminél kisebbeket akarod megszámolni: ");
            int n = int.Parse(Console.ReadLine()!);
            int db = 0;
            foreach (int szam in tomb)
            {
                if (szam < n)
                {
                    db++;
                }
            }
            Console.WriteLine($"Kisebb mint {n} darab: " + db);
            int parosOsszeg = 0;
            foreach (int szam in tomb)
            {
                if (szam % 2 == 0)
                {
                    parosOsszeg += szam;
                }
            }
            Console.WriteLine("A páros számok összege: " + parosOsszeg);
        }

        void Viccesen()
        {
            int[] tomb = ((Func<int[]>)(() => {
                int alsoHatar = EgeszetBeker(VeletlenSzamHatartBekerUzenet());
                int felsoHatar = EgeszetBeker(VeletlenSzamHatartBekerUzenet(true));
                return Enumerable.Range(0, 15).Select((int _) => rnd.Next(alsoHatar, felsoHatar)).ToArray();
            }))();
            Console.WriteLine("Sorban: " + tomb.VesszovelKiirat());
            Console.WriteLine("Visszafele: " + tomb.VesszovelKiirat(true));
            Console.WriteLine("Összeg: " + tomb.Sum());
            Console.WriteLine("Átlag: " + tomb.Average());
            Console.WriteLine("5-tel oszthatók: " + tomb.Where((int i) => i % 5 == 0).ToArray().VesszovelKiirat());
            Console.WriteLine(((Func<string>)(() => {
                int n = EgeszetBeker("Adj meg egy egész számot aminél a kisebbeket akarod megszámolni: ");
                return $"Kisebb mint {n} darab: " + tomb.Count((int i) => i < n);
            }))());
            Console.WriteLine("Páros elemek összege: " + tomb.Where((int i) => i % 2 == 0).Sum());
        }

        static string VeletlenSzamHatartBekerUzenet(bool felsoHatar = false)
        {
            (string alsoE, string inkluzivE) = !felsoHatar ? ("alsó", "in") : ("felső", "ex");
            return $"Add meg a véletlen számok {alsoE} határát ({inkluzivE}kluzív): ";
        }

        static int EgeszetBeker(string uzenet, bool torol = false)
        {
            Action torolAction = torol ? Console.Clear : () => { };
            int ertek = 0;
            bool validErtek = false;
            while (!validErtek)
            {
                Console.Write(uzenet);
                if (int.TryParse(Console.ReadLine(), out ertek))
                {
                    validErtek = true;
                }
                else
                {
                    torolAction();
                    Console.WriteLine("Hiba! Csak egész számot adhatsz meg.");
                }
            }
            torolAction();
            return ertek;
        }
    }
}
