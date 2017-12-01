/*
 * Slot Machine Spin Simluation 
 * Jason Thatcher
 * MIT
 * 2017
*/


using System;

namespace SlotMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            SlotMachineApp myApp = new SlotMachineApp();
            
            for (int i = 0; i<100000; i++)
            {
                myApp.Play();
            }
            
            myApp.DisplaySummary();
                       
            Console.ReadLine();
            
        }
    }
}
