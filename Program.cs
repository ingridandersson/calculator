
public class Program
{
   
    static void Main(string[] args)
    {
        //Kod som sätter färg på programmets text.
        Console.ForegroundColor = ConsoleColor.Green;

        //Skapar en lista för att kunna addera historik av beräkningar.
        List<string> historik = new List<string>();

        //Deklarerar variabler som behövs i programmet, med tillfällig initiering.
        double total = 0;
        string resultat = "";
        double dittTal1 = 0;
        double dittTal2 = 0;
        string symbol = "";
        int i = 1;
        
        //Välkomsthälsning till användaren.
        Console.WriteLine("Välkommen till Miniräknaren!");
        Console.WriteLine("Dags att börja räkna!\n");

        //En liten fördröjning till nästa utskrift.
        Thread.Sleep(500);

        //Loop för att repetera följande kod tills användaren säger annat.
        while (true)
        {
            //Ber användaren om ett tal och sparar talet i "dittTal1".
            //Try-catch för att avsluta programmet om användaren skriver en bokstav istället för siffra.
            Console.WriteLine("Skriv in ett tal: ");
            try
            {
                dittTal1 = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Du har räknat klart..");
                Console.ReadKey();
                return;
            }

            //Användaren väljer matematisk operator som sparas i "symvbol"
            Console.WriteLine("Välj matematisk operator (+, -, /, *)");
            symbol = Console.ReadLine();

            //Användarens andra tal sparas i "dittTal2".
            Console.WriteLine("Skriv in ett tal");
            dittTal2 = Convert.ToDouble(Console.ReadLine());

            //Felmeddelande om användaren försöker dividera med 0.
            if (symbol == "/" && dittTal2 == 0)
            {
                Console.WriteLine("Felaktig inmatning. Du kan inte dividera med 0.");
                Console.WriteLine("Räknaren avslutas...");
                Console.ReadKey();
                break;
            }
            else
            {
                //Sparar angiven ekvation i "total".
                switch (symbol)
                {
                    case "/":
                        total = dittTal1 / dittTal2;
                        break;
                    case "*":
                        total = dittTal1 * dittTal2;
                        break;
                    case "-":
                        total = dittTal1 - dittTal2;
                        break;
                    case "+":
                        total = dittTal1 + dittTal2;
                        break;

                }
                //Skriver ut ekvationen och sparar som en string för att kunna adderas till lista.
                if (symbol == "/")
                {
                    resultat = dittTal1 + " / " + dittTal2 + " = " + total.ToString();
                    Console.WriteLine($"{dittTal1} / {dittTal2} = " + (dittTal1 / dittTal2));

                }
                else if (symbol == "*")
                {
                    resultat = dittTal1 + " * " + dittTal2 + " = " + total.ToString();
                    Console.WriteLine($"{dittTal1} * {dittTal2} = " + (dittTal1 * dittTal2));
                }
                else if (symbol == "-")
                {
                    resultat = dittTal1 + " - " + dittTal2 + " = " + total.ToString();
                    Console.WriteLine($"{dittTal1} - {dittTal2} = " + (dittTal1 - dittTal2));
                }
                else if (symbol == "+")
                {
                    resultat = dittTal1 + " + " + dittTal2 + " = " + total.ToString();
                    Console.WriteLine($"{dittTal1} + {dittTal2} = " + (dittTal1 + dittTal2));
                }
            }
    
            //Sparar varje sträng med ekvation till listan.
            historik.Add(resultat);

            //Frågar användaren om hen vill se tidigare beräkningar.
            Console.WriteLine("Vill du se tidigare beräkningar? (j/n)");
            string dittSvar = Console.ReadLine();

            //Skriver ut alla tidigare beräkningar.
            if (dittSvar == "j")
                foreach (var räkning in historik)
                {
                    Console.WriteLine(räkning);
                    
                }
                i++;

            // Frågar om användaren vill fortsätta eller avsluta. 
            Console.WriteLine("Vill du fortsätta räkna? (j/n)");
            string dittSvar2 = Console.ReadLine();

            if (dittSvar2 != "j")
            {
                Console.WriteLine("Tack för att du räknat med mig. Vi ses igen!");
                Console.ReadKey();
                break;
            }
            
        }

        Console.ReadKey();
    }
}