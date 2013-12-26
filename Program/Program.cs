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
            Member[] memberList = new Member[4];
            memberList[0] = new Member("Clark", "Kent", 1111111, 1);
            memberList[1] = new Member("Bruce", "Wayne", 2222222, 2);
            memberList[2] = new Member("Hal", "Jordan", 3333333, 3);
            memberList[3] = new Member("Diana", "Prince", 4444444, 4);

            // Variabel för menyval.
            int option = 0;
            Member chosenMember = null;

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
                        chosenMember = GetMember(memberList);
                        ShowMember(chosenMember);
                        ContinueOnKeyPressed();
                        break;
                    case 3:
                        Console.Clear();
                        // Registrera ny medlem.
                        ContinueOnKeyPressed();
                        break;
                    case 4:
                        Console.Clear();
                        // Ta bort medlem.
                        ContinueOnKeyPressed();
                        break;
                }
            }

        }

        private static int GetMenuChoice() // Visar menyn och ber användaren mata in ett värde som sedan skickas tillbaks. KLAR!
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
                Console.WriteLine(" 3. Registrera ny medlem.\n 4. Ta bort medlem\n");
                Console.WriteLine(" ═════════════════════════════════════════════════ \n\n");
                Console.Write(" Ange menyval [0-4]: ");

                try // Ber användaren mata in ett menyalternativ & testar ifall det inmatade värdet är något utav de tillåtna intervallet 0 - 3 .
                {
                    menuChoice = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (menuChoice < 0 || menuChoice > 4)
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
                    Console.WriteLine("\n FEL! Ange ett heltal mellan 0-3!\n\n");
                    Console.ResetColor();
                }
            } while (true);

            return menuChoice;
        }

        private static void ContinueOnKeyPressed() // Vid anrop bes användaren att trycka på valfri tangent för att fortsätta. KLAR!
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n   Tryck tangent för att fortsätta   \n");
            Console.ResetColor();
            Console.ReadKey();
            Console.Clear();
        }

        private static void ShowMemberList(Member[] memberList) // Visar menyn och ber användaren mata in ett värde som sedan skickas tillbaks. KLAR!
        {
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔════════════════════════════════════════════════╗ ");
            Console.WriteLine(" ║                 Medlemslista                   ║ ");
            Console.WriteLine(" ╚════════════════════════════════════════════════╝ \n");
            Console.ResetColor();
            for (int i = 0; i < memberList.Length; i++)
            {
                Console.WriteLine("  Medlem " + memberList[i].ID + ": " + memberList[i].FirstName);
            }
            Console.WriteLine(" ═════════════════════════════════════════════════ \n");
        }

        private static Member GetMember(Member[] memberList)
        {
            int choice = 0;

            do
            {

                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" ╔═════════════════════════════════╗ ");
                Console.WriteLine(" ║           Välj medlem           ║ ");
                Console.WriteLine(" ╚═════════════════════════════════╝ \n");
                Console.ResetColor();
                for (int i = 0; i < memberList.Length; i++)
                {
                    Console.WriteLine("  Medlem " + memberList[i].ID + ": " + memberList[i].FirstName);
                }
                Console.WriteLine(" ═════════════════════════════════════════════════ \n");
                Console.Write("  Ange medlemsnummer: ");

                try // Ber användaren mata in ett menyalternativ & testar ifall det inmatade värdet är något utav de tillåtna intervallet 0 - 1 .
                {
                    choice = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (choice < 1 || choice > memberList.Length)
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
                    Console.WriteLine("\n FEL! Ange ett medlemsnummer!\n\n");
                    Console.ResetColor();
                } 
            } while (true);

            Member chosenMember = memberList[choice - 1];
            return chosenMember;
        }

        private static void ShowMember(Member chosenMember)
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

            Console.WriteLine("\n Namn: " + fullName);
            Console.WriteLine(" Medlemsnummer: " + iD);
            Console.WriteLine(" Telefonnummer: " + phoneNumber);
        }
    }
}