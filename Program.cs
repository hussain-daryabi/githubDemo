using WestcoastEducation;

class Program
{
    static void Main()
    {
        // 1. Dina vanliga objekt
        var larare1 = new Larare
        {
            Fornamn = "Michael",
            Efternamn = "Gustavsson",
            Personnummer = "800512-1234",
            Telefon = "0701122334",
            Adress = "Storgatan 1",
            Postnummer = "41102",
            Ort = "Göteborg",
            Omraden = new List<string> { "C#", ".NET" }
        };

        var admin1 = new Administrator
        {
            Fornamn = "Thomas",
            Efternamn = "Önnevik",
            Personnummer = "750315-9988",
            Telefon = "0709988776",
            Adress = "Kungsgatan 10",
            Postnummer = "41119",
            Ort = "Malmö",
            StartJobb = new DateTime(2026, 10, 15)
        };

        var elev1 = new Elev { Fornamn = "Olle", Efternamn = "Nilsson", Personnummer = "020110-5544" };
        var elev2 = new Elev { Fornamn = "Older", Efternamn = "Hassan", Personnummer = "010920-3322" };

        var kurs = new Kurs
        {
            Kursnummer = "N26",
            Namn = "C#",
            Dagar = 40,
            StartDatum = DateTime.Now.AddDays(10),
            SlutDatum = DateTime.Now.AddDays(50),
            Typ = Kurstyp.Klassrum,
            Larare = larare1
        };

        kurs.RegistreraElev(elev1);
        kurs.RegistreraElev(elev2);

        // 2. En enkel meny som bara visar det du vill se
        bool kor = true;

        while (kor)
        {
            Console.Clear();
            Console.WriteLine("Westcoast Education");
            Console.WriteLine("1. Visa kursinformation");
            Console.WriteLine("2. Visa lärare");
            Console.WriteLine("3. Visa studenter");
            Console.WriteLine("4. Visa administratör");
            Console.WriteLine("5. Spara och ladda kurs (JSON)");
            Console.WriteLine("0. Avsluta");
            Console.Write("\nVälj: ");

            string? val = Console.ReadLine();

            Console.WriteLine(); 
            // Tom rad
            switch (val)
            {
                case "1":
                    Console.WriteLine(kurs.VisaInfo());
                    break;
                case "2":
                    Console.WriteLine(larare1.SkrivUt());
                    break;
                case "3":
                    Console.WriteLine(elev1.SkrivUt());
                    Console.WriteLine(elev2.SkrivUt());
                    break;
                case "4":
                    Console.WriteLine(admin1.SkrivUt());
                    break;
                case "5":
                    kurs.Spara("min_kurs.json");
                    var laddad = Kurs.Ladda("min_kurs.json");
                    Console.WriteLine(laddad?.VisaInfo());
                    break;
                case "0":
                    kor = false;
                    continue;
            }

            Console.WriteLine("\nTryck Enter för att fortsätta...");
            Console.ReadLine();
        }
    }
}