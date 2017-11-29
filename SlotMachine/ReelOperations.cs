using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class ReelOperations
    {
        SlotMachineRandomNumber RM;
        Reel R;

        public ReelOperations()
        {

        }

        public string SpinReel(Reel r)
        {
            return r.GetSymbolOnReelAtPosition(GetNumber(r));
        }

        private int GetNumber(Reel r)
        {
            RM = new SlotMachineRandomNumber(0, r.TotalCountOfAllSymbolsOnReel());
            return RM.GetBoundedNumber();
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
