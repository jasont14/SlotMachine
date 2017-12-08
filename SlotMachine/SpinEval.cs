/* SpinEval.cs                                      Jason Thatcher
 *                                                  November 2017
 * 
 * Evaluates the spin results to determine winnings and provides
 * spin result with information.
 * 
 * C#, Probability, Loop, Conditional, Methods Comments, Console.
*/


using System;

namespace SlotMachine
{
    class SpinEval
    {
        SpinResult SR = new SpinResult();
        SlotCalc SC = new SlotCalc();
        bool spinWon;
        string winningSymbol;
        int countOfWinningSymbolsMatched;
        int winningPayout;

        string[] matchTwoSymbols;
        string[] matchOneSymbols;

        internal SpinResult SR1 { get => SR; set => SR = value; }

        public SpinEval(SlotCalc sc)
        {
            SC = sc;
            matchTwoSymbols = SymbolsWithTwoMatch();
            matchOneSymbols = SymbolsWithOneMatch();
        }

        private string[] SymbolsWithTwoMatch()
        {
            int counter = 0;
            string[] result = new string[8];

            //Do any match 2?
            for (int i = 0; i < SC.WinningCombinations.GetLength(0); i++)
            {
                if (SC.WinningCombinations[i, 1] == 2)
                {
                    result[counter] = SC.Reels[0].GetUniqueSymbolOnReel(SC.WinningCombinations[i, 0]);
                }
            }
            
            return result;
        }

        private string[] SymbolsWithOneMatch()
        {
            int counter = 0;
            string[] result = new string[8];

            //Do any match 2?
            for (int i = 0; i < SC.WinningCombinations.GetLength(0); i++)
            {
                if (SC.WinningCombinations[i, 1] == 1)
                {
                    result[counter] = SC.Reels[1].GetUniqueSymbolOnReel(SC.WinningCombinations[i, 0]);
                    counter += 1;
                }
            }
            
            return result;
        }

        public SpinResult EvaluateSpin(SpinResult sr)
        {
            bool matchThreeWin = false;
            bool matchTwoWin = false;
            bool matchOneWin = false;

            matchThreeWin = GetMatchThreeWinResult(sr);
            if (!matchThreeWin)
            { 
                matchTwoWin = GetMatchTwoWinResult(sr);
            }
            if (!matchThreeWin && !matchTwoWin)
            {
                matchOneWin = GetMatchOneWinResult(sr);
            }

            if (matchThreeWin)
            {
                sr.WinningSymbol = winningSymbol;
                sr.NumberMatched = 3;
                sr.Payout = GetPayout(winningSymbol,countOfWinningSymbolsMatched, sr);
                sr.SpinWon = true;
                sr.ReelOneSymbol = sr.ArrayOfSymbols[0];
                sr.ReelTwoSymbol = sr.ArrayOfSymbols[1];
                sr.ReelThreeSymbol = sr.ArrayOfSymbols[2];
            }
            else if (matchTwoWin)
            {
                sr.WinningSymbol = winningSymbol;
                sr.NumberMatched = 2;
                sr.Payout = GetPayout(winningSymbol, countOfWinningSymbolsMatched, sr);
                sr.SpinWon = true;
                sr.ReelOneSymbol = sr.ArrayOfSymbols[0];
                sr.ReelTwoSymbol = sr.ArrayOfSymbols[1];
                sr.ReelThreeSymbol = sr.ArrayOfSymbols[2];

            }
            else if (matchOneWin)
            {
                sr.WinningSymbol = winningSymbol;
                sr.NumberMatched = 1;
                sr.Payout = GetPayout(winningSymbol, countOfWinningSymbolsMatched,sr);
                sr.SpinWon = true;
                sr.ReelOneSymbol = sr.ArrayOfSymbols[0];
                sr.ReelTwoSymbol = sr.ArrayOfSymbols[1];
                sr.ReelThreeSymbol = sr.ArrayOfSymbols[2];
            }
            else
            {
                sr.WinningSymbol = "LOSS";
                sr.NumberMatched = 0;
                sr.Payout = 0;
                sr.SpinWon = false;
                sr.ReelOneSymbol = sr.ArrayOfSymbols[0];
                sr.ReelTwoSymbol = sr.ArrayOfSymbols[1];
                sr.ReelThreeSymbol = sr.ArrayOfSymbols[2];
            }

            return sr;
        }

        private int GetPayout(string winningSymbol,int numberMatched, SpinResult s)
        {
            int result = 0;
            
            int[,] pytCBO = SC.WinningCombinations;
            int symbolNumber = SC.Reels[0].GetUniqueNumberForSymbolBySymbolString(winningSymbol);
                
            for (int i = 0; i<SC.WinningCombinationsPayout.Length; i++)
            {
                if(SC.WinningCombinations[i,0]== symbolNumber && SC.WinningCombinations[i,1] == numberMatched)
                {
                    result = SC.WinningCombinationsPayout[i];
                    break;
                }
            }
            return result;
        }

        private bool GetMatchThreeWinResult(SpinResult s)
        {
            bool matchThreeWin = false;

            if (s.ArrayOfSymbols[0] == s.ArrayOfSymbols[1] && s.ArrayOfSymbols[1] == s.ArrayOfSymbols[2])
            {
                matchThreeWin = true;
                countOfWinningSymbolsMatched = 3;
                winningSymbol = s.ArrayOfSymbols[0];
            }

            return matchThreeWin;
        }
        
        private bool GetMatchTwoWinResult(SpinResult s)
        {
            bool matchTwoWin = false;

            if (s.ArrayOfSymbols[0] == s.ArrayOfSymbols[1] && Array.IndexOf(matchTwoSymbols, s.ArrayOfSymbols[0]) > -1)
            {
                matchTwoWin = true;
                countOfWinningSymbolsMatched = 2;
                winningSymbol = s.ArrayOfSymbols[0];
            }

            if (s.ArrayOfSymbols[1] == s.ArrayOfSymbols[2] && Array.IndexOf(matchTwoSymbols, s.ArrayOfSymbols[1]) > -1)
            {
                matchTwoWin = true;
                countOfWinningSymbolsMatched = 2;
                winningSymbol = s.ArrayOfSymbols[1];
            }

            if (s.ArrayOfSymbols[0] == s.ArrayOfSymbols[2] && Array.IndexOf(matchTwoSymbols, s.ArrayOfSymbols[2]) > -1)
            {
                matchTwoWin = true;
                countOfWinningSymbolsMatched = 2;
                winningSymbol = s.ArrayOfSymbols[2];
            }

            return matchTwoWin;
        }

        private bool GetMatchOneWinResult(SpinResult s)
        {
            bool matchOneWin = false;

            if (Array.IndexOf(matchOneSymbols, s.ArrayOfSymbols[0]) > -1)
            {
                matchOneWin = true;
                countOfWinningSymbolsMatched = 1;
                winningSymbol = s.ArrayOfSymbols[0];
            }
            if (Array.IndexOf(matchOneSymbols, s.ArrayOfSymbols[1]) > -1)
            {
                matchOneWin = true;
                countOfWinningSymbolsMatched = 1;
                winningSymbol = s.ArrayOfSymbols[1];

            }
            if (Array.IndexOf(matchOneSymbols, s.ArrayOfSymbols[2]) > -1)
            {
                matchOneWin = true;
                countOfWinningSymbolsMatched = 1;
                winningSymbol = s.ArrayOfSymbols[2];
            }

            return matchOneWin;

        }
    }
}
