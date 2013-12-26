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
            memberList[0] = new Member("Clark", "Kent", 11111, 101);
            memberList[1] = new Member("Bruce", "Wayne", 22222, 102);
            memberList[2] = new Member("Hal", "Jordan", 33333, 103);
            memberList[3] = new Member("Diana", "Prince", 44444, 104);

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
                        MemberListOptions(memberList);
                        break;
                    case 2:
                        Console.Clear();
                        // Registrera ny medlem.
                        break;
                    case 3:
                        Console.Clear();
                        // Ta bort medlem.
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
                Console.WriteLine(" 0. Avsluta.\n 1. Visa medlemslista.\n");
                Console.WriteLine(" - Redigera -------------------------------------- \n");
                Console.WriteLine(" 2. Registrera ny medlem.\n 3. Ta bort medlem\n");
                Console.WriteLine(" ═════════════════════════════════════════════════ \n\n");
                Console.Write(" Ange menyval [0-3]: ");

                try // Ber användaren mata in ett menyalternativ & testar ifall det inmatade värdet är något utav de tillåtna intervallet 0 - 3 .
                {
                    menuChoice = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (menuChoice < 0 || menuChoice > 3)
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

        private static int MemberListOptions(Member[] memberList) // Visar menyn och ber användaren mata in ett värde som sedan skickas tillbaks. KLAR!
        {
            int menuChoice = 0;

            do
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

                Console.WriteLine("\n - Arkiv -----------------------------------------\n");
                Console.WriteLine(" 0. Tillbaks.\n 1. Visa enskild medlem.\n");
                Console.WriteLine(" ═════════════════════════════════════════════════ \n\n");
                Console.Write(" Ange menyval [0-1]: ");

                try // Ber användaren mata in ett menyalternativ & testar ifall det inmatade värdet är något utav de tillåtna intervallet 0 - 1 .
                {
                    menuChoice = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (menuChoice < 0 || menuChoice > 1)
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
                    Console.WriteLine("\n FEL! Ange ett heltal mellan 0-1!\n\n");
                    Console.ResetColor();
                }
            } while (true);

            return menuChoice;
        }
    }
}

