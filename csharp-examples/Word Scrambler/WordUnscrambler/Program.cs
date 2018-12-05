using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continueWordUnscramble = true;

            do
            {
                Console.WriteLine("Please enter option F for File and M for manual entry");
                string option = Console.ReadLine();

                switch (option)
                {
                    case "F":
                    case "f":
                        Console.WriteLine("Please enter path");
                        ProgramManager.ExecutescramblewordInFileScenario();
                        break;
                    case "M":
                    case "m":
                        Console.WriteLine("Please enter words seprated by commas");
                       ProgramManager.ExecutescramblewordInManualScenario();
                        break;
                    default:
                        Console.WriteLine("Please enter correct option");
                        break;
                }

                string doYouWantToContinue = string.Empty;
                do
                {
                    Console.WriteLine("Do you want to continue? Y/N");
                    doYouWantToContinue = Console.ReadLine().ToLower();

                } while (doYouWantToContinue != "y" && doYouWantToContinue != "n");

                continueWordUnscramble = doYouWantToContinue == "y";

            } while (continueWordUnscramble);
        }

       



    }





}
