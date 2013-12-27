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
                        ShowMember(GetMember(memberList));
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
                        memberList.Remove(GetMember(memberList));
                        Message("Medlem borttagen");
                        ContinueOnKeyPressed();
                        break;
                    case 5:
                        Console.Clear();
                        // Redigera befintlig medlem.
                        EditMember(GetMember(memberList));
                        Message("Medlem redigerad");
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

        private static Member GetMember(List<Member> memberList) // Hämtar enskild medlem ur medlemslistan.
        {
            int choice = 0;
            Member chosenMember = null;

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

            try
            {
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
            }
            catch (Exception) { }

            return chosenMember;
        }

        private static void ShowMember(Member chosenMember) // Visar enskild medlem i detaljerad vy.
        {
            try
            {
                if (chosenMember == null)
                {
                    throw new Exception();
                }
                else
                {
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
                    Console.WriteLine("\n Namn: {0}",fullName);
                    Console.WriteLine(" Medlemsnummer: {0}",iD);
                    Console.WriteLine(" Telefonnummer: {0}",phoneNumber);
                }
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

        private static Member RegisterNewMember(List<Member> memberList) // Skapa en ny medlem.
        {
            string fName = null;
            string lName = null;
            int pNumber = 0;
            Random rnd = new Random();
            int identity = rnd.Next(1, 1000);

            do
            {
                for (int i = 0; i < memberList.Count; i++)
                {
                    if (identity == memberList[i].ID)
                    {
                        identity = rnd.Next(1, 1000);
                    }
                }

                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔══════════════════════════════════════════════╗ ");
                Console.WriteLine(" ║            Registrera ny medlem              ║ ");
                Console.WriteLine(" ╚══════════════════════════════════════════════╝ ");
                Console.ResetColor();

                Console.Write("\n Förnamn: ");
                fName = Console.ReadLine();
                Console.Write("\n Efternamn: ");
                lName = Console.ReadLine();
                Console.Write("\n Telefonnummer: ");

                try // Ber användaren mata in värden för namn & telefonnummer.
                {
                    pNumber = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (pNumber < 1 || pNumber > 999999999)
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
                    Console.WriteLine("\n FEL! Ange endast siffror (utan mellanslag)!\n\n");
                    Console.ResetColor();
                }
            } while (true);

            Member myMember = new Member(fName, lName, pNumber, identity);
            return myMember;
        }

        private static void EditMember(Member chosenMember) // Redigera en medlem.
        {
            do
            {
                //Variabel för menyval.
                int choice = 0;

                try
                {
                    if (chosenMember == null)
                    {
                        throw new Exception();
                    }
                    else
                    {
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(" ╔══════════════════════════════════════════════╗ ");
                        Console.WriteLine(" ║               Redigera medlem                ║ ");
                        Console.WriteLine(" ╚══════════════════════════════════════════════╝ ");
                        Console.ResetColor();
                        Console.WriteLine("\n Medlemsnummer: {0}", chosenMember.ID);
                        Console.WriteLine("\n 1.Namn: {0} {1}",chosenMember.FirstName,chosenMember.LastName);
                        Console.WriteLine(" 2.Telefonnummer: {0}",chosenMember.PhoneNumber);
                        Console.WriteLine("\n 3. Avbryt");
                        Console.WriteLine(" ═════════════════════════════════════════════════ \n");
                        Console.Write(" Ange menyval [1-3]: ");

                        // Ber användaren mata in ett menyval för vad som ska redigeras.
                        choice = int.Parse(Console.ReadLine());

                        if (choice < 0 || choice > 3)
                        {
                            throw new Exception();
                        }
                        if (choice == 1)
                        {
                            Console.Write("\n Nytt förnamn: ");
                            chosenMember.FirstName = Console.ReadLine();
                            Console.Write("\n Nytt efternamn: ");
                            chosenMember.LastName = Console.ReadLine();
                        }
                        if (choice == 2)
                        {
                            Console.Write("\n Nytt telefonnummer: ");
                            chosenMember.PhoneNumber = int.Parse(Console.ReadLine());

                            if (chosenMember.PhoneNumber < 1 || chosenMember.PhoneNumber > 999999999)
                            {
                                throw new ArgumentOutOfRangeException();
                            }
                        }
                        if (choice == 3)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.Clear();
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Ange endast siffror (utan mellanslag)!\n\n");
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
            } while (true);
        }
    }
}