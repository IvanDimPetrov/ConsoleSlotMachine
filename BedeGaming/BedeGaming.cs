using SlotMachinesLibrary.SlotMachines.Implementations;
using SlotMachinesLibrary.Slots.Contracts;
using SlotMachinesLibrary.Slots.Models;
using System;
using System.Collections.Generic;

namespace BedeGaming
{
    class BedeGaming
    {
        static void Main(string[] args)
        {

            //set up the bede slot machine
            var mySlotMachine = new BedeSlotMachine();

            mySlotMachine.SetupSlotTypes(GetSlotsCollection());

            try
            {
                Console.Write("Please enter deposit money you would play with:");
                var deposit = decimal.Parse(Console.ReadLine());

                Console.Write("Enter stake amount:");
                var stakeAmount = decimal.Parse(Console.ReadLine());

                if (stakeAmount >= deposit)
                    throw new Exception("Stake amount can not be equal or bigger than deposit");

                mySlotMachine.Deposit = deposit;
                mySlotMachine.StakeAmount = stakeAmount;

                //start the game
                var consoleKey = ConsoleKey.Enter;

                while (consoleKey != ConsoleKey.Escape)
                {

                    mySlotMachine.Spin();

                    //get the current state after the spin and calculation of the machine 
                    //printing necessary information
                    var currentState = mySlotMachine.GetCurrentState();

                    foreach (var payLine in currentState.Paylines)
                    {
                        Console.WriteLine(payLine);
                    }

                    Console.WriteLine($"You have won: {currentState.CurrentWiningAmount}");

                    //stoping the game
                    if (currentState.Deposit <= 0)
                    {
                        Console.WriteLine("Sorry my friend!!! This is the end :))))");
                        break;
                    }

                    Console.WriteLine($"Current Balance: {currentState.Deposit}");
                    Console.WriteLine("Press any key to spin again or 'Esc' key to stop the game!!!");
                    Console.WriteLine();


                    //another spin
                    consoleKey = Console.ReadKey().Key;
                }

            }
            catch(FormatException e)
            {
                Console.WriteLine("You provide incorect deposit amount or stack amount!!!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        /// <summary>
        /// Provide slots for Bede slot machine
        /// </summary>
        /// <returns></returns>
        public static IList<ISlot> GetSlotsCollection()
        {
            return new List<ISlot>()
            {
                new Slot("B", 0.6m, 35),
                new Slot("*", 0.0m, 5),
                new Slot("P", 0.8m, 15),
                new Slot("A", 0.4m, 45)
            };
        }
    }
}
