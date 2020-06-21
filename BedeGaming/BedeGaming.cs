using SlotMachinesLibrary.SlotMachines.Implementations;
using SlotMachinesLibrary.Slots.Contracts;
using SlotMachinesLibrary.Slots.Models;
using System;
using System.Collections.Generic;

namespace BedeGaming
{
    /*
     * This is console application for simplified slot machine.
     * It use 'SlotMachinesLibrary' that provides various types of slot machines.
     * With this library you may implement or use slot machine that work with diferent types of slots and different types of paylines.
     * Paylines represent collections of slots with logic how to calculate total winning coefficient of all slots of the payline
     * and matching algorithm to determine if payline is winning. Every slot holds value, winning coefficient and probability to appear on the cell.
     * Here we use 'BedeSlotMachine' that works with 'PaylineWithWildCard' payline with logic for calculating deposit, winning amount and winning 
     * combination of slots for every payline according specification described in 'Bede_Simplified_Slot_Machine_-_.NET_Developer_Task.pdf' file.
     * In this library can be implemented various paylines with logic for calculation of total winning coefficient or winning combination of slots.
     * Also it can be implemented variuos slot machines that works with different counts of paylines, 
     * slots own logic for calculating deposit and winning amount and specific type of payline.
     */
    public class BedeGaming
    {
        public static void Main(string[] args)
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

                    //get the generated paylines, deposit and winning amount after the spin
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
