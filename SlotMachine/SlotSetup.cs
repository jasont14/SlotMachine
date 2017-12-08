/* SlotSetup.cs                                Jason Thatcher
 *                                                  November 2017
 * 
 * Controls how the slot machine is setup.  Sets winning combinations,
 * Payout for each combination, and number of symbol types on each
 * reel.
 * 
 * C#, Probability, Loop, Conditional, Methods Comments, Console.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotSetup
    {
        List<Reel> reels;
        List<int[]> SymbolCountPerReel;
        int slotCount;
        int[,] winningCombinations;
        int[] winningCombinationsPayout;
        int[] r1SymbolCount;
        int[] r2SymbolCount;
        int[] r3SymbolCount;


        public SlotSetup()
        {
            SlotCount = 3;
            WinningCombinations = new int[,] { { 0, 3 }, { 1, 3 }, { 2, 3 }, { 2, 2 }, { 2, 1 }, { 3, 3 }, { 4, 3 }, { 5, 3 } };
            WinningCombinationsPayout = new int[] { 75, 30, 15, 2, 1, 20, 8, 4 };
            R1SymbolCount = new int[] { 1, 1, 3, 2, 4, 4 };
            R2SymbolCount = new int[] { 1, 2, 3, 3, 3, 3 };
            R3SymbolCount = new int[] { 1, 2, 3, 2, 3, 5 };
            GetReelsForSlotMachine();
            GetSymbolCountPerReel();
        }

        public int SlotCount { get => slotCount; set => slotCount = value; }
        public int[,] WinningCombinations { get => winningCombinations; set => winningCombinations = value; }
        public int[] WinningCombinationsPayout { get => winningCombinationsPayout; set => winningCombinationsPayout = value; }
        public int[] R1SymbolCount { get => r1SymbolCount; set => r1SymbolCount = value; }
        public int[] R2SymbolCount { get => r2SymbolCount; set => r2SymbolCount = value; }
        public int[] R3SymbolCount { get => r3SymbolCount; set => r3SymbolCount = value; }
        public List<int[]> SymbolCountPerReel1 { get => SymbolCountPerReel; set => SymbolCountPerReel = value; }
        internal List<Reel> Reels { get => reels; set => reels = value; }

        private void GetReelsForSlotMachine()
        {
            Reels = new List<Reel> {new Reel(R1SymbolCount), new Reel(R2SymbolCount),new Reel(R3SymbolCount)};            
        }

        private void GetSymbolCountPerReel()
        {
            List<int[]> SymbolCountPerReel = new List<int[]>{R1SymbolCount , R2SymbolCount, R3SymbolCount };            
        }
    }
}
