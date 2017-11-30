using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachineApp
    {
        SpinResult SR;
        SlotSetup SS;
        SlotMachine SM;
        SpinEval SE;
        SlotCalc SC;
        
        List<SpinResult> ListOfSpinResults = new List<SpinResult>();
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
            int spins = 1;
            SS = new SlotSetup();
            SM = new SlotMachine(SS.Reels, SS.SlotCount);
            SC = new SlotCalc(SS.Reels, SS.SymbolCountPerReel1, SS.WinningCombinations, SS.WinningCombinationsPayout);
        }
        public void Play()
        {
            
            SR = new SpinResult();
            SR = PullHandle(SR);
            CheckForWin(SR);
        } 

        private void DisplayHeader()
        {
            Console.WriteLine("SLOT MACHINE HEADER");
        }

        private SpinResult PullHandle(SpinResult SR)
        {
            
            SR = SM.Spin(SR);
            return SR;
        }

        private void CheckForWin(SpinResult SR)
        {
            SE = new SpinEval(SC);
            SR = SE.EvaluateSpin(SR);
            ListOfSpinResults.Add(SR);
            
            //Console.WriteLine("{0} - {1} - {2} || Winner: {3,-10} Number Matched: {4,-10}, Winning Symbol: {5,-5}, Payout: {6,-10}",SR.ArrayOfSymbols[0], SR.ArrayOfSymbols[1], SR.ArrayOfSymbols[2], SR.WinningSymbol.ToString(), SR.NumberMatched.ToString(), SR.WinningSymbol, SR.Payout.ToString());            
            //SR = new SpinResult();
            
        }

        public void DisplaySummary()
        {
            Console.WriteLine("Total Spins: {0}. Winning Spins: {1}. Total Paid Out: {2}", ListOfSpinResults.Count, AddAllResult().ToString(), SumPayout().ToString());
            Console.WriteLine("\n");
            SC.BuildPayOffPercentagesTable();
            SumPayoutPercentByCombination();
        }

        private int AddAllResult()
        {
            int result = 0;

            foreach(SpinResult s in ListOfSpinResults)
            {
                if (s.SpinWon)
                {
                    result += 1;
                }
                                                                                                                                                                        
            }

            return result;
        }

        private int SumPayout()
        {
            int result = 0;

            foreach (SpinResult s in ListOfSpinResults)
            {
                if (s.SpinWon)
                {
                    result += s.Payout;
                }

            }

            return result;
        }

        public void SumPayoutPercentByCombination()
        {
            int excli = 0, pound = 0, threemoney = 0, twomoney = 0, onemoney = 0, percenta = 0, ampers = 0, semicol =0;
                        
            foreach(SpinResult s in ListOfSpinResults)
            {
                if(s.WinningSymbol == "!") { excli += 1; }

                if (s.WinningSymbol == "#") { pound += 1; }

                if (s.WinningSymbol == "$" && s.NumberMatched==3) { threemoney += 1; }

                if (s.WinningSymbol == "$" && s.NumberMatched == 2) { twomoney += 1; }

                if (s.WinningSymbol == "$" && s.NumberMatched == 1) { onemoney += 1; }

                if (s.WinningSymbol == "%") { percenta += 1; }

                if (s.WinningSymbol == "&") { ampers += 1; }

                if (s.WinningSymbol == ";") { semicol += 1; }
            }

            
            int TotalWinsFromThis = excli + pound + threemoney + twomoney + onemoney + percenta + ampers + semicol;
            int TotalWinsCalc = AddAllResult();
            int TotalRolls = ListOfSpinResults.Count;

            Console.WriteLine("Total Wins: {0} VS Total Wins Calc: {1} VS Total Wins Table: {2}",TotalWinsFromThis.ToString(),TotalWinsCalc.ToString(),"??50%");
            Console.WriteLine("!!! Wins: {0} Payout: {1}", excli.ToString(),(SC.WinningCombinationsPayout[0]*excli).ToString());
            Console.WriteLine("### Wins: {0} Payout: {1}", pound.ToString(),(SC.WinningCombinationsPayout[1] * pound).ToString());
            Console.WriteLine("$$$ Wins: {0} Payout: {1}", threemoney.ToString(), (SC.WinningCombinationsPayout[2] * threemoney).ToString());
            Console.WriteLine("$$  Wins: {0} Payout: {1}", twomoney.ToString(), (SC.WinningCombinationsPayout[3] * twomoney).ToString());
            Console.WriteLine("$   Wins: {0} Payout: {1}", onemoney.ToString(), (SC.WinningCombinationsPayout[4] * onemoney).ToString());
            Console.WriteLine("%%% Wins: {0} Payout: {1}", percenta.ToString(), (SC.WinningCombinationsPayout[5] * percenta).ToString());
            Console.WriteLine("&&& Wins: {0} Payout: {1}", ampers.ToString(), (SC.WinningCombinationsPayout[6] * ampers).ToString());
            Console.WriteLine(";;; Wins: {0} Payout: {1}", semicol.ToString(), (SC.WinningCombinationsPayout[7] * semicol).ToString());



        }
    }
}
