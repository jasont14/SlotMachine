using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlotMachine
{
    class SlotMachine
    {
        List<Reel> Reels = new List<Reel>();        
        ReelOperations RO;
        SpinResult SR;
        int slotCount;
        
        public SlotMachine(List<Reel> r, int slots) 
        {
            RO = new ReelOperations();
            SR = new SpinResult();            
            slotCount = slots;
            Reels = r;
        }        

        public SpinResult Spin()
        {   
            SR.ArrayOfSymbols = new string[Reels.Count];

            for (int i=0; i<Reels.Count; i++)
            {
                SR.ArrayOfSymbols[i] = RO.SpinReel(Reels[i]);
            }

            return SR;
        }        
    }
}
