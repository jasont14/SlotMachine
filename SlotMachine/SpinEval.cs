using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public SpinEval(SpinResult s, SlotCalc sc)
        {
            SR1 = s;
            SC = sc;
            SR1.Payout = 0;
            SR1.NumberMatched = 0;
            SR1.SpinWon = false;
            SR1.WinningSymbol = "";

            countOfWinningSymbolsMatched = 0;
            matchTwoSymbols = SymbolsWithTwoMatch();
            matchOneSymbols = SymbolsWithOneMatch();

            EvaluateSpin();
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

        private void EvaluateSpin()
        {
            bool matchOneWin = GetMatchOneWinResult();
            bool matchTwoWin = GetMatchTwoWinResult();
            bool matchThreeWin = GetMatchThreeWinResult();

            if (matchThreeWin)
            {
                SR1.WinningSymbol = winningSymbol;
                SR1.NumberMatched = countOfWinningSymbolsMatched;
                SR1.Payout = winningPayout;
            }
            else if (matchTwoWin)
            {
                SR1.WinningSymbol = winningSymbol;
                SR1.NumberMatched = countOfWinningSymbolsMatched;
                SR1.Payout = winningPayout;

            }
            else if (matchOneWin)
            {
                SR1.WinningSymbol = winningSymbol;
                SR1.NumberMatched = countOfWinningSymbolsMatched;
                SR1.Payout = winningPayout;
            }
            else
            {
                SR1.WinningSymbol = "LOSS";
                SR1.NumberMatched = 0;
                SR1.Payout = 0;
            }
        }

        private int GetPayout(string winningSymbol,int numberMatched)
        {
            int result = 0;
            int a = SC.Reels[0].GetUniqueNumberForSymbolBySymbolString(SR1.ArrayOfSymbols[0]);  //gets number of symbol
            //loop through winning combinations

            for (int i = 0; i<SC.WinningCombinations.GetLength(0); i++)
            {
                if(SC.WinningCombinations[i,0]==a && SC.WinningCombinations[i,1] == countOfWinningSymbolsMatched)
                {
                    result = SC.WinningCombinationsPayout[i];
                }
            }
            return result;
        }

        private bool GetMatchThreeWinResult()
        {
            bool matchThreeWin = false;

            if (SR1.ArrayOfSymbols[0] == SR1.ArrayOfSymbols[1] && SR1.ArrayOfSymbols[1] == SR1.ArrayOfSymbols[2])
            {
                matchThreeWin = true;
                countOfWinningSymbolsMatched = 3;
                winningSymbol = SR1.ArrayOfSymbols[0];
                winningPayout = GetPayout(winningSymbol, countOfWinningSymbolsMatched);                
            }
            return matchThreeWin;
        }

        private bool GetMatchTwoWinResult()
        {
            bool matchTwoWin = false;

            if (SR1.ArrayOfSymbols[0] == SR1.ArrayOfSymbols[1] && Array.IndexOf(matchTwoSymbols, SR1.ArrayOfSymbols[0]) > -1)
            {
                matchTwoWin = true;
                winningSymbol = SR1.ArrayOfSymbols[0];
                countOfWinningSymbolsMatched = 2;
                winningPayout = GetPayout(winningSymbol, countOfWinningSymbolsMatched);
            }

            if (SR1.ArrayOfSymbols[1] == SR1.ArrayOfSymbols[2] && Array.IndexOf(matchTwoSymbols, SR1.ArrayOfSymbols[1]) > -1)
            {
                matchTwoWin = true;
                winningSymbol = SR1.ArrayOfSymbols[1];
                countOfWinningSymbolsMatched = 2;
                winningPayout = GetPayout(winningSymbol, countOfWinningSymbolsMatched);
            }

            if (SR1.ArrayOfSymbols[0] == SR1.ArrayOfSymbols[2] && Array.IndexOf(matchTwoSymbols, SR1.ArrayOfSymbols[2]) > -1)
            {
                matchTwoWin = true;
                winningSymbol = SR1.ArrayOfSymbols[2];
                countOfWinningSymbolsMatched = 2;
                winningPayout = GetPayout(winningSymbol, countOfWinningSymbolsMatched);
            }

            return matchTwoWin;
        }

        private bool GetMatchOneWinResult()
        {
            bool matchOneWin = false;

            if (Array.IndexOf(matchOneSymbols, SR1.ArrayOfSymbols[0]) > -1)
            {
                matchOneWin = true;
                winningSymbol = SR1.ArrayOfSymbols[0];
                countOfWinningSymbolsMatched = 1;
                winningPayout = GetPayout(winningSymbol, countOfWinningSymbolsMatched);
            }
            if (Array.IndexOf(matchOneSymbols, SR1.ArrayOfSymbols[1]) > -1)
            {
                matchOneWin = true;
                winningSymbol = SR1.ArrayOfSymbols[1];
                countOfWinningSymbolsMatched = 1;
                winningPayout = GetPayout(winningSymbol, countOfWinningSymbolsMatched);
            }
            if (Array.IndexOf(matchOneSymbols, SR1.ArrayOfSymbols[2]) > -1)
            {
                matchOneWin = true;
                winningSymbol = SR1.ArrayOfSymbols[2];
                countOfWinningSymbolsMatched = 1;
                winningPayout = GetPayout(winningSymbol, countOfWinningSymbolsMatched);
            }

            return matchOneWin;

        }

        //private bool MatchTwoPayOutTrue()
        //{
        //    bool result = false;

        //    for (int i = 0; i < SC.WinningCombinations.GetLength(0); i++)
        //    {
        //        if (SC.WinningCombinations[i, 1] == 2)
        //        {
        //            result = true;
        //        }
        //    }
        //    return result;
        //}

    }
}
