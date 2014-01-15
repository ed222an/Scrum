using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {

            // Exempellista med medlemmar.
            List<Member> memberList = new List<Member>();

            memberList.Add(new Member("Clark", "Kent", 1111111, 101));
            memberList.Add(new Member("Bruce", "Wayne", 2222222, 212));
            memberList.Add(new Member("Hal", "Jordan", 3333333, 344));
            memberList.Add(new Member("Diana", "Prince", 4444444, 423));

            // Variabel för menyval.
            int option = 0;

            while (true)
            {
                option = GetMenuChoice();

                switch (option)
                {
                    case 0:
                        Environment.Exit(0);
                        break;
                    case 1:
                        Console.Clear();
                        // Visa medlemslista.
                        ShowMemberList(memberList);
                        ContinueOnKeyPressed();
                        break;
                    case 2:
                        Console.Clear();
                        // Visa enskild medlem.
                        ShowMember(memberList);
                        ContinueOnKeyPressed();
                        break;
                    case 3:
                        Console.Clear();
                        // Registrera ny medlem.
                        memberList.Add(RegisterNewMember(memberList));
                        Message("Ny medlem sparad");
                        ContinueOnKeyPressed();
                        break;
                    case 4:
                        Console.Clear();
                        // Ta bort medlem.
                        DeleteMember(memberList);
                        ContinueOnKeyPressed();
                        break;
                    case 5:
                        Console.Clear();
                        // Redigera befintlig medlem.
                        EditMember(memberList);
                        ContinueOnKeyPressed();
                        break;
                }
            }

        }

        private static int GetMenuChoice() // Visar menyn och ber användaren mata in ett värde som sedan skickas tillbaks.
        {
            int menuChoice = 0;

            do
            {
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔════════════════════════════════════════════════╗ ");
                Console.WriteLine(" ║                 Medlemsregister                ║ ");
                Console.WriteLine(" ╚════════════════════════════════════════════════╝ ");
                Console.ResetColor();
                Console.WriteLine("\n - Arkiv -----------------------------------------\n");
                Console.WriteLine(" 0. Avsluta.\n 1. Visa medlemslista.\n 2. Visa enskild medlem.\n");
                Console.WriteLine(" - Redigera -------------------------------------- \n");
                Console.WriteLine(" 3. Registrera ny medlem.\n 4. Ta bort medlem\n 5. Redigera befintlig medlem\n");
                Console.WriteLine(" ═════════════════════════════════════════════════ \n\n");
                Console.Write(" Ange menyval [0-5]: ");

                try // Ber användaren mata in ett menyalternativ & testar ifall det inmatade värdet är något utav de tillåtna intervallet 0 - 3 .
                {
                    menuChoice = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (menuChoice < 0 || menuChoice > 5)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Ange ett heltal mellan 0-5!\n\n");
                    Console.ResetColor();
                }
            } while (true);

            return menuChoice;
        }

        private static void ContinueOnKeyPressed() // Vid anrop bes användaren att trycka på valfri tangent för att fortsätta.
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n   Tryck tangent för att fortsätta   \n");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        private static void Message(string prompt)
        {
            // Skriver ut medlemmens information.
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\n ╔");
            for (int i = 0; i < prompt.Length + 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╗ \n");
            Console.WriteLine(" ║ {0} ║ ", prompt);


            Console.Write(" ╚");
            for (int i = 0; i < prompt.Length + 2; i++)
            {
                Console.Write("═");
            }
            Console.Write("╝ \n");
            Console.ResetColor();
        }

        private static void ShowMemberList(List<Member> memberList) // Visar menyn och ber användaren mata in ett värde som sedan skickas tillbaks.
        {
            try
            {
                // Ifall listan inte är tom körs övrig kod.
                if (memberList == null || memberList.Count == 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ╔════════════════════════════════════════════════╗ ");
                    Console.WriteLine(" ║                 Medlemslista                   ║ ");
                    Console.WriteLine(" ╚════════════════════════════════════════════════╝ \n");
                    Console.ResetColor();
                    for (int i = 0; i < memberList.Count; i++)
                    {
                        Console.WriteLine("  Medlem " + memberList[i].ID + ": " + memberList[i].FirstName);
                    }
                    Console.WriteLine(" ═════════════════════════════════════════════════ \n");
                }
            }
            catch (ArgumentException) // Finns det inga medlemmar att spara visas detta felmeddelande.
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n ╔════════════════════════════════════════╗ ");
                Console.WriteLine(" ║   Det finns inga medlemmar att visa    ║ ");
                Console.WriteLine(" ╚════════════════════════════════════════╝ ");
                Console.ResetColor();
            }
        }

        private static Member GetMember(List<Member> memberList) // Hämtar enskild medlem ur medlemslistan.
        {
            int choice = 0;
            Member chosenMember = null;

            do
            {
                try
                {
                    // Ifall listan inte är tom körs övrig kod.
                    if (memberList == null || memberList.Count == 0)
                    {
                        throw new ArgumentException();
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGreen;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ╔═════════════════════════════════╗ ");
                        Console.WriteLine(" ║           Välj medlem           ║ ");
                        Console.WriteLine(" ╚═════════════════════════════════╝ \n");
                        Console.ResetColor();
                        for (int i = 0; i < memberList.Count; i++)
                        {
                            Console.WriteLine("  Medlem {0}: {1}", memberList[i].ID, memberList[i].FirstName);
                        }
                        Console.WriteLine(" ═════════════════════════════════════════════════ \n");
                        Console.Write("  Ange medlemsnummer: ");

                        // Ber användaren mata in menyval.
                        choice = int.Parse(Console.ReadLine());
                        Console.Clear();

                        for (int i = 0; i < memberList.Count; i++)
                        {
                            if (memberList[i].ID.CompareTo(choice) == 0)
                            {
                                chosenMember = memberList[i];
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        break;
                    }
                }
                catch (ArgumentException) // Finns det inga medlemmar att spara visas detta felmeddelande.
                {
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n ╔════════════════════════════════════════╗ ");
                    Console.WriteLine(" ║   Det finns inga medlemmar att visa    ║ ");
                    Console.WriteLine(" ╚════════════════════════════════════════╝ ");
                    Console.ResetColor();
                    break;
                }
                catch (FormatException) // Matas fel format in visas detta felmeddelande.
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Ange endast siffror (utan mellanslag)!\n\n");
                    Console.ResetColor();
                } 
            } while (true);

            return chosenMember;
        }

        private static void ShowMember(List<Member> memberList) // Visar enskild medlem i detaljerad vy.
        {
            Member chosenMember = null;

            try
            {
                chosenMember = GetMember(memberList);

                // Variabler för lagring av medlemmens data.
                string firstName = chosenMember.FirstName;
                string lastName = chosenMember.LastName;
                string fullName = firstName + " " + lastName;
                int iD = chosenMember.ID;
                int phoneNumber = chosenMember.PhoneNumber;

                // Skriver ut medlemmens information.
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("\n ╔");
                for (int i = 0; i < firstName.Length + 2; i++)
                {
                    Console.Write("═");
                }
                Console.Write("╗ \n");
                Console.WriteLine(" ║ {0} ║ ", firstName);


                Console.Write(" ╚");
                for (int i = 0; i < firstName.Length + 2; i++)
                {
                    Console.Write("═");
                }
                Console.Write("╝ \n");
                Console.ResetColor();
                Console.WriteLine("\n Namn: {0}", fullName);
                Console.WriteLine(" Medlemsnummer: {0}", iD);
                Console.WriteLine(" Telefonnummer: {0}", phoneNumber);
            }
            catch (NullReferenceException)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n ╔════════════════════════════════════════╗ ");
                Console.WriteLine(" ║   Det finns inga medlemmar att visa    ║ ");
                Console.WriteLine(" ╚════════════════════════════════════════╝ ");
                Console.ResetColor();
            }
        }

        private static Member RegisterNewMember(List<Member> memberList) // Skapa en ny medlem.
        {
            // Variabler för lagring av data & testning.
            string fName = null;
            string lName = null;
            string pString = null;
            int pNumber = 0;
            int value = 0;
            Random rnd = new Random();
            int identity = rnd.Next(1, 1000);

            do
            {
                try // Ber användaren mata in värden för namn & telefonnummer.
                {
                    // Slumpar ett nytt användar-ID åt den nya medlemmen.
                    for (int i = 0; i < memberList.Count; i++)
                    {
                        if (identity == memberList[i].ID)
                        {
                            identity = rnd.Next(1, 1000);
                        }
                    }

                    // Skriver ut menyn.
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" ╔══════════════════════════════════════════════╗ ");
                    Console.WriteLine(" ║            Registrera ny medlem              ║ ");
                    Console.WriteLine(" ╚══════════════════════════════════════════════╝ ");
                    Console.ResetColor();

                    // Ber användaren mata in ny medlems förnamn.
                    Console.Write("\n Förnamn: ");
                    fName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(fName) == true)
                    {
                        throw new ArgumentNullException();
                    }
                    if (int.TryParse(fName, out value))
                    {
                        throw new FormatException();
                    }

                    // Ber användaren mata in ny medlems efternamn.
                    Console.Write("\n Efternamn: ");
                    lName = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(lName) == true)
                    {
                        throw new ArgumentNullException();
                    }

                    // Namnet får inte endast vara siffror.
                    if (int.TryParse(lName, out value))
                    {
                        throw new FormatException();
                    }

                    Console.Write("\n Telefonnummer: ");
                    pString = Console.ReadLine();
                    Console.Clear();
                    if (string.IsNullOrWhiteSpace(pString) == true)
                    {
                        throw new ArgumentNullException();
                    }

                    // Kontrollerar att strängen är en siffra.
                    int.TryParse(pString, out pNumber);

                    if (pNumber < 1 || pNumber > int.MaxValue)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                    else
                    {
                        break;
                    }
                }
                
                // Felhantering.
                catch (FormatException)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Namnet får inte vara en siffra!\n\n");
                    Console.ResetColor();
                }
                catch (ArgumentNullException)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Fältet får inte vara tomt!\n\n");
                    Console.ResetColor();
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Ange endast siffror (utan mellanslag)!\n\n");
                    Console.ResetColor();
                }
            } while (true);

            // Skickar tillbaks den nya medlemmen och dess data.
            Member myMember = new Member(fName, lName, pNumber, identity);
            return myMember;
        }

        private static void EditMember(List<Member> memberList) // Redigera en medlem.
        {

            //Variabel för menyval.
            int choice = 0;
            Member chosenMember = null;

            chosenMember = GetMember(memberList);

            do
            {
                try
                {
                    // Ifall listan inte är tom körs övrig kod.
                    if (memberList == null || memberList.Count == 0)
                    {
                        throw new ArgumentNullException();
                    }
                    else
                    {
                        //Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ╔══════════════════════════════════════════════╗ ");
                        Console.WriteLine(" ║               Redigera medlem                ║ ");
                        Console.WriteLine(" ╚══════════════════════════════════════════════╝ ");
                        Console.ResetColor();
                        Console.WriteLine("\n 1. Redigera medlem");
                        Console.WriteLine(" -------------------------------------------------");
                        Console.WriteLine("\n Medlemsnummer: {0}", chosenMember.ID);
                        Console.WriteLine(" Namn: {0} {1}", chosenMember.FirstName, chosenMember.LastName);
                        Console.WriteLine(" Telefonnummer: {0}", chosenMember.PhoneNumber);
                        Console.WriteLine(" -------------------------------------------------");
                        Console.WriteLine("\n 0. Avbryt");
                        Console.WriteLine(" ═════════════════════════════════════════════════ \n");
                        Console.Write(" Ange menyval [0-1]: ");

                        // Ber användaren mata in ett menyval för vad som ska redigeras.
                        choice = int.Parse(Console.ReadLine());

                        if (choice < 0 || choice > 1)
                        {
                            throw new ArgumentOutOfRangeException();
                        }
                        // Användaren får mata in namn.
                        if (choice == 1)
                        {
                            Console.Write("\n Nytt förnamn: ");
                            chosenMember.FirstName = Console.ReadLine();
                            Console.Write("\n Nytt efternamn: ");
                            chosenMember.LastName = Console.ReadLine();
                            Console.Write("\n Nytt telefonnummer: ");
                            chosenMember.PhoneNumber = int.Parse(Console.ReadLine());

                            if (chosenMember.PhoneNumber < 1 || chosenMember.PhoneNumber > 999999999)
                            {
                                throw new FormatException();
                            }
                            Message("Medlem redigerad");
                            break;
                        }
                        if (choice == 0)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Ange endast siffror (utan mellanslag)!\n\n");
                    Console.ResetColor();
                }
                catch (ArgumentOutOfRangeException) // Finns det inga medlemmar att spara visas detta felmeddelande.
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Ange något utav menyvalen.\n\n");
                    Console.ResetColor();
                }
                catch (ArgumentNullException) // Finns det inga medlemmar att spara visas detta felmeddelande.
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("\n ╔════════════════════════════════════════╗ ");
                    Console.WriteLine(" ║ Det finns inga medlemmar att redigera  ║ ");
                    Console.WriteLine(" ╚════════════════════════════════════════╝ ");
                    Console.ResetColor();
                    break;
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Du angav inte ett medlemsnummer!\n\n Du hamnar nu i huvudmenyn.\n");
                    Console.ResetColor();
                    break;
                }
            } while (true);
        }

        private static void DeleteMember(List<Member> memberList) // Tar bort vald medlem.
        {
            // Variabler.
            Member chosenMember = null;
            string menuChoice = null;

            try
            {
                // Ifall listan inte är tom körs övrig kod.
                if (memberList == null || memberList.Count == 0)
                {
                    throw new ArgumentException();
                }
                else
                {
                    chosenMember = GetMember(memberList); // Anropar metoden GetMember för att skriva ut de olika alternativen.

                    while (true)
                    {
                        if (chosenMember != null) // Är chosenMember inte null får användaren bekräfta att det vald medlem ska tas bort.
                        {
                            Console.BackgroundColor = ConsoleColor.Yellow;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\n Är du säker på att du vill ta bort '{0} {1}'? [j/N] \n", chosenMember.FirstName, chosenMember.LastName);
                            Console.ResetColor();

                            menuChoice = (Console.ReadLine()); // Ber användaren att mata in en sträng.

                            if (menuChoice == "j" || menuChoice == "J") // Om j/J väljs tas den valda medlemmen bort ur listan med medlemmar & ett rättmeddelande skrivs ut.
                            {
                                memberList.Remove(chosenMember);

                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n ╔═════════════════════════════════════╗ ");
                                Console.WriteLine(" ║     Medlemmen har tagits bort       ║ ");
                                Console.WriteLine(" ╚═════════════════════════════════════╝ ");
                                Console.ResetColor();
                                break;
                            }
                            else if (menuChoice == "n" || menuChoice == "N") // Väljs n/N bryts do-while-loopen och programmet fortsätter köras. 
                            {
                                break;
                            }
                            else // Trycker användaren på en knapp utöver j/J || n/N skrivs ett felmeddelande ut och användaren får försöka igen.
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n     FEL TECKEN!    \n"); ;
                                Console.ResetColor();
                            }
                        }
                        else
                        {
                            throw new Exception();
                        }
                    }
                }
            }
            catch (ArgumentException) // Finns det inga medlemmar att spara visas detta felmeddelande.
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("\n ╔════════════════════════════════════════╗ ");
                Console.WriteLine(" ║  Det finns inga medlemmar att ta bort  ║ ");
                Console.WriteLine(" ╚════════════════════════════════════════╝ ");
                Console.ResetColor();
            }
            catch (Exception)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n FEL! Du angav inte ett medlemsnummer!\n\n Du hamnar nu i huvudmenyn.\n");
                Console.ResetColor();
            }
        }
    }
}