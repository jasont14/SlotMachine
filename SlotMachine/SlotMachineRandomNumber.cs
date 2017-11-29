using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  SlotMachine
{
    class SlotMachineRandomNumber
    {
        int lowerBound;
        int upplerBound;
        Random rndm = new Random();

        public int LowerBound { get => lowerBound; set => lowerBound = value; }
        public int UpplerBound { get => upplerBound; set => upplerBound = value; }

        public SlotMachineRandomNumber()
        {

        }

        public SlotMachineRandomNumber(int lowerbound, int upperbound)
        {
            LowerBound = lowerbound;
            UpplerBound = upperbound;
        }

        public int GetChoiceFromProbability(int numberOfOptions,int[] probabilityOfEachOption)
        {
            int result = 0;
            return result;            
        }

        public int GetBoundedNumber()
        {
            return rndm.Next(LowerBound, UpplerBound);
        }

        public int GetNumberZeroToHundred()
        {
            int result = rndm.Next(1,100);
            return result;
        }

        public double GetDoubleZeroToNinetyNine()
        {
            double result = rndm.NextDouble();

            return result;
        }

        public int[] GetArrayOfNumbersZeroToHundred(int arraySizeToReturn)
        {
            int[] result = new int[arraySizeToReturn];
            
            for (int i=0; i<arraySizeToReturn; i++)
            {
                result[i] = rndm.Next(1,100);
            }

            return result;
        }
        public void WriteToConsoleArrayOfNumbersZeroToHundred(int arraySizeToReturn)
        {
            int counter = 1;
            int[] rNArray = GetArrayOfNumbersZeroToHundred(100);
            foreach (int i in rNArray)
            {
                string ds = i.ToString();
                Console.Write(String.Format("{0,-5}",ds));
               
                if (counter % 10 == 0)
                {
                    Console.Write("\n");
                }
                counter += 1;
            }
        }
        public void WriteToConsoleArrayOfDoubleZeroToOne()
        {
            int counter = 1;
            double[] rNArray = new double[100];

            for (int j = 0; j<100; j++)
            {
                rNArray[j] = rndm.NextDouble();
            }
            
            foreach (double i in rNArray)
            {
                //string ds = ;
                Console.Write("{0,-10}",i.ToString("#.0000"));

                if (counter % 10 == 0)
                {
                    Console.Write("\n");
                }
                counter += 1;
            }
        }


    }
}
