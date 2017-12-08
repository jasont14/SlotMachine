/* SpinResult.cs                                   Jason Thatcher
 *                                                  November 2017
 * 
 * Class to record information about each spin.
 * 
 * C#, Methods Comments.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SpinResult
    {
        string  reelOneSymbol;
        string  reelTwoSymbol;
        string  reelThreeSymbol;
        string[] arrayOfSymbols;
        bool    spinWon;
        int     numberMatched;
        string  winningSymbol;
        int     payout;

        public SpinResult()
        {

            }
        public SpinResult(string rOneSymbol, string rTwoSymbol, string rThreeSymbol, bool win, int numberMatch, string symbolMatched, int pay)
        {
            ReelOneSymbol   = rOneSymbol;
            ReelTwoSymbol   = rTwoSymbol;
            ReelThreeSymbol = rThreeSymbol;
            arrayOfSymbols = new string[3];
            SpinWon         = win;
            NumberMatched   = numberMatch;
            WinningSymbol   = symbolMatched;
            Payout          = pay;

        }
        public SpinResult(string rOneSymbol, string rTwoSymbol, string rThreeSymbol)
        {
            ReelOneSymbol = rOneSymbol;
            ReelTwoSymbol = rTwoSymbol;
            ReelThreeSymbol = rThreeSymbol;
            arrayOfSymbols = new string[3];
        }

        public SpinResult(string[] s)
        {
            ReelOneSymbol = s[0];
            ReelTwoSymbol = s[1];
            ReelThreeSymbol = s[2];
            arrayOfSymbols = new string[3];
        }

        public string   ReelOneSymbol   { get => reelOneSymbol; set => reelOneSymbol = value; }
        public string   ReelTwoSymbol   { get => reelTwoSymbol; set => reelTwoSymbol = value; }
        public string   ReelThreeSymbol { get => reelThreeSymbol; set => reelThreeSymbol = value; }
        public bool     SpinWon         { get => spinWon; set => spinWon = value; }
        public int      NumberMatched   { get => numberMatched; set => numberMatched = value; }
        public string   WinningSymbol   { get => winningSymbol; set => winningSymbol = value; }
        public int      Payout          { get => payout; set => payout = value; }
        public string[] ArrayOfSymbols { get => arrayOfSymbols; set => arrayOfSymbols = value; }
    }
}
