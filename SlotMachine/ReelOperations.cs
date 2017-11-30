using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class ReelOperations
    {
        Random RN;
        Reel R;

        public ReelOperations()
        {
            RN = new Random();
        }


        public string SpinReel(Reel reel)
        {
            int randomNumber = GetRandomNumber(0, (reel.TotalCountOfAllSymbolsOnReel() - 1));
            return reel.GetSymbolOnReelAtPosition(randomNumber);
        }

        private int GetRandomNumber(int lower, int upper)
        {
            int result = 0;
            result = RN.Next(lower, upper);
            return result;
        }

        public List<Reel> GetReelSetForSlotMachine(int slots, List<int[]> s, int numberOfUniqueSymbolsOnReel)
        { 
            List<Reel> result = new List<Reel>();

            for (int i = 0; i<slots; i++)
            {
                Reel R = new Reel(numberOfUniqueSymbolsOnReel, s[i]);
                result.Add(R);
            }
            
            return result;  
        }
    }
}
