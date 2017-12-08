/* Reel.cs                                          Jason Thatcher
 *                                                  December 2017
 * 
 * Represents a "reel" in a slot machine. Provides methods to retrieve
 * information about the reel.
 * 
 * C#, Arrays, Methods, Loop, Conditional, Comments, Console.
*/

using System;
using System.Linq;

namespace SlotMachine
{
    class Reel
    {
        int NumberOfUniqueSymbolsOnReel;
        char[] symbolArrayOfEachSymbolInOrderAsOnReel;       
        int[] symbolCountByUniqueSymbol;
        char[] symbolsArrayOfSymbolsToSelectFrom;

        public Reel()
        {
            symbolsArrayOfSymbolsToSelectFrom = new char[] { '\u0021', '\u0023', '\u0024', '\u0025', '\u0026', '\u003b', '\u003f', '\u007e', '\u003c', '\u002a', '\u003a', '\u005c' };
            NumberOfUniqueSymbolsOnReel = 6;                        
            SymbolCountByUniqueSymbol = new int[] { 1, 2, 2, 2, 3, 5 };
            SetSymbolsOnReel();
        }

        public int[] SymbolCountByUniqueSymbol { get => symbolCountByUniqueSymbol; set => symbolCountByUniqueSymbol = value; }
        public char[] SymbolArrayOfEachSymbolInOrderAsOnReel { get => symbolArrayOfEachSymbolInOrderAsOnReel; set => symbolArrayOfEachSymbolInOrderAsOnReel = value; }
                
        public Reel(int numberOfSymbols)
        {
            symbolsArrayOfSymbolsToSelectFrom = new char[] { '\u0021', '\u0023', '\u0024', '\u0025', '\u0026', '\u003b', '\u003f', '\u007e', '\u003c', '\u002a', '\u003a', '\u005c' };
            NumberOfUniqueSymbolsOnReel = numberOfSymbols;
            SymbolCountByUniqueSymbol = new int[] { 1, 2, 2, 2, 3, 5 };
            SetSymbolsOnReel();
        }

        public Reel(int[] symbolsCountOnReel)
        {
            symbolsArrayOfSymbolsToSelectFrom = new char[] { '\u0021', '\u0023', '\u0024', '\u0025', '\u0026', '\u003b', '\u003f', '\u007e', '\u003c', '\u002a', '\u003a', '\u005c' };
            NumberOfUniqueSymbolsOnReel = 6;
            SymbolCountByUniqueSymbol = symbolsCountOnReel;
            SetSymbolsOnReel();
        }

        public Reel(int numberOfSymbols, int[] symbolsCountOnReel)
        {
            symbolsArrayOfSymbolsToSelectFrom = new char[] { '\u0021', '\u0023', '\u0024', '\u0025', '\u0026', '\u003b', '\u003f', '\u007e', '\u003c', '\u002a', '\u003a', '\u005c' };
            NumberOfUniqueSymbolsOnReel = numberOfSymbols;
            SymbolCountByUniqueSymbol = symbolsCountOnReel;
            SetSymbolsOnReel();
        }

        private void SetSymbolsOnReel()
        {
            SymbolArrayOfEachSymbolInOrderAsOnReel = new char[SymbolCountByUniqueSymbol.Sum()];
            
            int symbolPosition = 0;
            for (int i = 0; i<NumberOfUniqueSymbolsOnReel; i++)
            {
                int counter = 0;
                do
                {
                    SymbolArrayOfEachSymbolInOrderAsOnReel[symbolPosition] = symbolsArrayOfSymbolsToSelectFrom[i];
                    counter += 1;
                    symbolPosition += 1;
                } while (counter < SymbolCountByUniqueSymbol[i]);

            }
        }

        public string GetUniqueSymbolOnReel(int a)
        {
            string result;
                        
                result = symbolsArrayOfSymbolsToSelectFrom[a].ToString();
            
            return result;
        }

        public int GetUniqueNumberForSymbolBySymbolString(string s)
        {
            int result = 100;

            for (int i = 0; i<symbolsArrayOfSymbolsToSelectFrom.Length; i++)
            {
                if(Convert.ToChar(s) == symbolsArrayOfSymbolsToSelectFrom[i])
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        public string[] GetUniqueSymbolsAsArrayOnReel()
        {
            string[] result = new string[NumberOfUniqueSymbolsOnReel];

            for(int i= 0; i<NumberOfUniqueSymbolsOnReel; i++)
            {
                result[i] = symbolsArrayOfSymbolsToSelectFrom[i].ToString();
            }
            return result;
        }
        
        public string GetSymbolOnReelAtPosition(int a)
        {
            string result;

            result = SymbolArrayOfEachSymbolInOrderAsOnReel[a].ToString();

            return result;
        }

        public int TotalCountOfAllSymbolsOnReel()
        {
            return SymbolArrayOfEachSymbolInOrderAsOnReel.Count();
        }

        public int GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(int a)
        {
            return SymbolCountByUniqueSymbol[a];
        }       

        public void WriteSymbolsOnReelToConsole()
        {
            Console.Write("\nReel: ");
            int counter = 0;
            foreach (char c in SymbolArrayOfEachSymbolInOrderAsOnReel)
            {
                Console.Write(" {1} ",counter.ToString(),c.ToString());
                counter += 1;
            }
        }
    }
}
