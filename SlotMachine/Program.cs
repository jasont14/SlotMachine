/* Program.cs                                       Jason Thatcher
 *                                                  December 2017
 * 
 * Entry to SlotMachine app.  Sets number of iterations below by
 * changing value of "i" in for loop.
 * 
 * C#, Loop, Comments, Console.
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
