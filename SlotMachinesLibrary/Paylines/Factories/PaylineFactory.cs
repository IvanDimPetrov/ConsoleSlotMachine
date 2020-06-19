using SlotMachinesLibrary.Paylines.Contracts;
using SlotMachinesLibrary.Slots.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SlotMachinesLibrary.Paylines.Factories
{
    /// <summary>
    /// Helper class provides static methods for generating a paylines
    /// </summary>
    public class PaylineFactory
    {
        //Thread save random generator;
        private static readonly ThreadLocal<Random> Random = new ThreadLocal<Random>(() => new Random());

        /// <summary>
        /// Generate payline with slots respecting the probability of each of them
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="slotsCollection">Collection of slots</param>
        /// <param name="numberOfSlots">Counts of slot of a payline</param>
        /// <returns></returns>
        public static T GenerateRandomPayLine<T>(IList<ISlot> slotsCollection, int slotsCount)  where T: IPayline, new()
        {
            T newPayline = new T();

            int totalProbability = slotsCollection.Sum(x => x.Probability);

            for (var i = 1; i <= slotsCount; i++)
            {
                int randomNumber = Random.Value.Next(0, totalProbability) + 1;
         
                int probability = 0;

                foreach (var slot in slotsCollection)
                {
                    probability += slot.Probability;

                    if (randomNumber <= probability)
                    {
                        newPayline.AddSlot(slot);
                        break;
                    }
                }
            }

            return newPayline;
        }
    }
}
