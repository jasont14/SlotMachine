/* ReelOperations.cs                                Jason Thatcher
 *                                                  November 2017
 * 
 * Calculates probabilities and generates Probability Table with
 * comparison.  Set the number of "spins" in Program.CS.
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
    class SlotCalc
    {
        List<Reel> reels;
        int totalCombinations;

        int totalWinningCombinations;
        string[] winningCombinationSymbolSet;
        int[] winningCombinationsSum;
        int[,] winningCombinations;
        int[] winningCombinationsPayout;
        double[] winningCombinationsPayoutPercent;
        double winningCombinationsPayoutPercentSum;
        int[] winningCombinationsPayoutOneCoin;
        int winningCombinationsPayoutOneCoinSum;

        public SlotCalc()
        {

        }

        public SlotCalc(List<Reel> r, List<int[]> reelSetup, int[,] winningcombinations, int[] payout)
        {
            Reels = r;
            WinningCombinations = winningcombinations;
            WinningCombinationsPayout = payout;
            WinningCombinationsSum = new int[WinningCombinations.GetLength(0)];
            WinningCombinationsPayoutOneCoin = new int[WinningCombinations.GetLength(0)];
            WinningCombinationsPayoutPercent = new double[WinningCombinations.GetLength(0)];
            WinningCombinationSymbolSet = new string[WinningCombinations.GetLength(0)];
            SetNumberOfCombinations();
            SetStats();
        }

        public int TotalWinningCombinations { get => totalWinningCombinations; set => totalWinningCombinations = value; }
        public string[] WinningCombinationSymbolSet { get => winningCombinationSymbolSet; set => winningCombinationSymbolSet = value; }
        public int[] WinningCombinationsSum { get => winningCombinationsSum; set => winningCombinationsSum = value; }
        public int[,] WinningCombinations { get => winningCombinations; set => winningCombinations = value; }
        public int[] WinningCombinationsPayout { get => winningCombinationsPayout; set => winningCombinationsPayout = value; }
        public double[] WinningCombinationsPayoutPercent { get => winningCombinationsPayoutPercent; set => winningCombinationsPayoutPercent = value; }
        public double WinningCombinationsPayoutPercentSum { get => winningCombinationsPayoutPercentSum; set => winningCombinationsPayoutPercentSum = value; }
        public int[] WinningCombinationsPayoutOneCoin { get => winningCombinationsPayoutOneCoin; set => winningCombinationsPayoutOneCoin = value; }
        public int WinningCombinationsPayoutOneCoinSum { get => winningCombinationsPayoutOneCoinSum; set => winningCombinationsPayoutOneCoinSum = value; }
        internal List<Reel> Reels { get => reels; set => reels = value; }

        private void SetStats()
        {
            SetTotalWinningCombination();
            SetTotalCombinations();
            GetWinningCombinationsPayoutOneCoin();
            GetWinningCombinationPayoutPercent();
            GetWinningCombinationSum();
            GetWinningCombinationSymbols();
        }

        private void SetNumberOfCombinations()
        {
            for (int i = 0; i < WinningCombinations.GetLength(0); i++)
            {
                int Reel1NumberOfSymbol = Reels[0].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);
                int Reel2NumberOfSymbol = Reels[1].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);
                int Reel3NumberOfSymbol = Reels[2].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);

                int NumberOfSlotsToMatch = WinningCombinations[i, 1];
                int NumberOfSlotDoNotMatch = Reels.Count - NumberOfSlotsToMatch;

                int Combinations = 0;

                int Reel1Match = Reels[0].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);
                int Reel2Match = Reels[1].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);
                int Reel3Match = Reels[2].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);

                int Reel1DoNotMatch = Reels[0].TotalCountOfAllSymbolsOnReel() - Reels[0].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);
                int Reel2DoNotMatch = Reels[1].TotalCountOfAllSymbolsOnReel() - Reels[1].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);
                int Reel3DoNotMatch = Reels[2].TotalCountOfAllSymbolsOnReel() - Reels[2].GetCountOfSpecificSymbolUsingSymbolOnReelAtSpecificPosition(WinningCombinations[i, 0]);

                if (NumberOfSlotsToMatch == 3)
                {
                    Combinations += Reel1Match * Reel2Match * Reel3Match;
                }
                else if (NumberOfSlotsToMatch == 2)
                {
                    Combinations += Reel1Match * Reel2Match * Reel3DoNotMatch;
                    Combinations += Reel1Match * Reel2DoNotMatch * Reel3Match;
                    Combinations += Reel1DoNotMatch * Reel2Match * Reel3Match;
                }
                else if (NumberOfSlotsToMatch == 1)
                {
                    Combinations += Reel1Match * Reel2DoNotMatch * Reel3DoNotMatch;
                    Combinations += Reel1DoNotMatch * Reel2DoNotMatch * Reel3Match;
                    Combinations += Reel1DoNotMatch * Reel2Match * Reel3DoNotMatch;
                }
                WinningCombinationsSum[i] = Combinations;
            }
        }
        
        private void GetWinningCombinationsPayoutOneCoin()
        {
            // Number of Winning Combinations * Winning Payout
            for (int i = 0; i < WinningCombinationsSum.Length; i++)
            {
                WinningCombinationsPayoutOneCoin[i] = WinningCombinationsSum[i] * WinningCombinationsPayout[i];
            }

            WinningCombinationsPayoutOneCoinSum = WinningCombinationsPayoutOneCoin.Sum();
        }

        private void GetWinningCombinationSum()
        {
            //Number of Winning Combinations total = sum or winning combinations;
            int result = 0;
            for (int i = 0; i < WinningCombinationsSum.Length; i++)
            {
                result += WinningCombinationsSum[i];
            }
        }
        private void GetWinningCombinationPayoutPercent()
        {
            for (int i = 0; i < WinningCombinationsSum.Length; i++)
            {
                WinningCombinationsPayoutPercent[i] = (Convert.ToDouble(WinningCombinationsPayoutOneCoin[i]) / Convert.ToDouble(WinningCombinationsPayoutOneCoinSum));
            }

            WinningCombinationsPayoutPercentSum = WinningCombinationsPayoutPercent.Sum();
        }

        private void GetWinningCombinationSymbols()
        {
            for (int i = 0; i < WinningCombinations.GetLength(0); i++)
            {
                string temp = "";

                for (int j = 0; j < WinningCombinations[i, 1]; j++)
                {
                    temp += Reels[1].GetUniqueSymbolOnReel(WinningCombinations[i, 0]);
                }

                WinningCombinationSymbolSet[i] = temp;
            }
        }

        private void SetTotalWinningCombination()
        {
            int j = 0;

            for (int i = 0; i < WinningCombinationsSum.Length; i++)
            {
                j += WinningCombinationsSum[i];
            }

            TotalWinningCombinations = j;
        }

        private void SetTotalCombinations()
        {
            int result = 0;

            int reel1Count = reels[0].TotalCountOfAllSymbolsOnReel();
            int reel2Count = reels[1].TotalCountOfAllSymbolsOnReel();
            int reel3Count = reels[2].TotalCountOfAllSymbolsOnReel();

            result = reel1Count * reel2Count * reel3Count;

            totalCombinations = result;
        }

        public void BuildPayOffPercentagesTable()
        {
            Console.WriteLine("{0,5} {1,15} {2, 10} {3,15} {4, 12}", " Symbol", "Combinations", "Payout", "1-Coin Payout", "Payout %");
            Console.WriteLine("*****************************************************************");

            for (int i = 0; i < WinningCombinationsSum.Length; i++)
            {
                Console.Write("{0,4}", WinningCombinationSymbolSet[i]);
                Console.Write("{0,15} ", WinningCombinationsSum[i].ToString());
                Console.Write("{0,13} ", WinningCombinationsPayout[i].ToString());
                Console.Write("{0,12} ", WinningCombinationsPayoutOneCoin[i].ToString());
                Console.Write("{0,15}", WinningCombinationsPayoutPercent[i].ToString("#0.##%"));
                Console.WriteLine("\n");
            }


            Console.WriteLine("*****************************************************************");
            Console.WriteLine("{0,3} {1,15} {2, 10} {3,15} {4, 12}", "Total", WinningCombinationsSum.Sum(), "**", WinningCombinationsPayoutOneCoinSum, WinningCombinationsPayoutPercentSum);
            Console.WriteLine("\nTotal Combinations: " + totalCombinations.ToString());
            Console.WriteLine("Winning Combinations: " + TotalWinningCombinations.ToString());
            Console.WriteLine("Expected Winning Percentage; {0}", (Convert.ToDouble(TotalWinningCombinations) / Convert.ToDouble(totalCombinations)).ToString("#0.##%"));

            Console.WriteLine("Expected Payout Percentage: {0}", (Convert.ToDouble(WinningCombinationsPayoutOneCoinSum) / Convert.ToDouble(totalCombinations)).ToString("#0.##%"));

        }

    }
}
