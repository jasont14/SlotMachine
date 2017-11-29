using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SlotMachineApp myApp = new SlotMachineApp();

            for (int i = 0; i< 10; i++)
            {
                myApp.Play();
            }
                       
            Console.ReadLine();
            

            //SlotMachine mySM = new SlotMachine();
            //mySM.BuildPayOffPercentagesTable();

            //for(int i = 0; i < 50; i++)
            //{
            //    mySM.Spin();
            //}

            //int[] myR1SymbolCount = { 1, 1, 2, 2, 4, 5 };
            //Reel myR1 = new Reel(myR1SymbolCount);
            //Console.WriteLine("REEL 1");
            //myR1.WriteSymbolsOnReelToConsole();

            //int[] myR2SymbolCount = { 1, 1, 3, 3, 3, 4 };
            //Reel myR2 = new Reel();
            //Console.WriteLine("\nREEL 2");
            //myR2.WriteSymbolsOnReelToConsole();

            //Reel myR3 = new Reel();
            //Console.WriteLine("\nREEL 3");
            //myR3.WriteSymbolsOnReelToConsole();

            //Console.WriteLine("Reel 1, Count of Symbol at Position 2" + myR1.GetCountOfSymbolAtSpecificPosition(2).ToString());
            //Console.WriteLine("Reel 1, Total Count of Symbols." + myR1.TotalCountOfSymbolsOnReel().ToString());
            //Console.WriteLine("Reel 1, Symbol at Position 2" + myR1.GetSymbolAtPosition(2));

            Console.ReadLine();
            
        }
    }
}
