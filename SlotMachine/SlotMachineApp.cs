using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachineApp
    {
        SlotSetup SS;
        SlotMachine SM;
        SpinResult SR;
        SpinEval SE;
        SlotCalc SC;
        int spins;

        public SlotMachineApp(int numberOfSpins)
        {
            int spins = numberOfSpins;
            SS = new SlotSetup();
            SM = new SlotMachine(SS.Reels, SS.SlotCount);
            SC = new SlotCalc(SS.Reels, SS.SymbolCountPerReel1, SS.WinningCombinations, SS.WinningCombinationsPayout);            
        }
        public SlotMachineApp()
        {
            SS = new SlotSetup();
            SM = new SlotMachine(SS.Reels, SS.SlotCount);
            SC = new SlotCalc(SS.Reels, SS.SymbolCountPerReel1, SS.WinningCombinations, SS.WinningCombinationsPayout);
        }
        public void Play()
        {
            SR = new SpinResult();
            PullHandle();
            CheckForWin();

        }

        private void DisplayHeader()
        {
            Console.WriteLine("SLOT MACHINE HEADER");
        }

        private void PullHandle()
        {
            SR = SM.Spin();
        }

        private void CheckForWin()
        {
            SE = new SpinEval(SR, SC);
            Console.WriteLine("{0} - {1} - {2} || Winner: {3} Number Matched: {4}, Winning Symbol: {5}, Payout: {6}",SR.ArrayOfSymbols[0],SR.ArrayOfSymbols[1],SR.ArrayOfSymbols[2],SR.WinningSymbol.ToString(),SR.NumberMatched.ToString(),SR.WinningSymbol, SR.Payout.ToString());            
        }
    }
}
