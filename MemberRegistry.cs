using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistry
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Member> memberList = null;

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
                        //memberList = LoadRecipes();
                        break;
                    case 2:
                        Console.Clear();
                        //SaveRecipes(memberList);
                        break;
                    case 3:
                        Console.Clear();
                        //DeleteMember(memberList);
                        break;
                    case 4:
                        Console.Clear();
                        //ViewRecipe(memberList, true);
                        break;
                    case 5:
                        Console.Clear();
                        //ViewRecipe(memberList);
                        break;
                }
            }
        }

        private static int GetMenuChoice() // Visar menyn och ber användaren mata in ett värde som sedan skickas tillbaks. KLAR!
        {
            int menuChoice = 0;

            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ╔════════════════════════════════════════════════╗ ");
            Console.WriteLine(" ║                 Medlemsregister                ║ ");
            Console.WriteLine(" ╚════════════════════════════════════════════════╝ ");
            Console.ResetColor();
            Console.WriteLine("\n - Arkiv -----------------------------------------\n");
            Console.WriteLine(" 0. Avsluta.\n 1. Öppna textfil med medlemmar.\n 2. Spara medlem på textfil.\n");
            Console.WriteLine(" - Redigera -------------------------------------- \n");
            Console.WriteLine(" 3. Ta bort medlem.\n");
            Console.WriteLine(" - Visa ------------------------------------------\n");
            Console.WriteLine(" 4. Visa enskild medlem.\n 5. Visa alla medlemmar.\n");
            Console.WriteLine(" ═════════════════════════════════════════════════ \n\n");
            Console.Write(" Ange menyval [0-5]: ");

            do
            {
                try // Ber användaren mata in ett menyalternativ & testar ifall det inmatade värdet är något utav de tillåtna intervallet 0 - 5 .
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
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n FEL! Ange ett heltal mellan 0-5! ");
                    Console.ResetColor();
                    Console.Write("\n Ange menyval [0-5]: ");
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
    }
}
