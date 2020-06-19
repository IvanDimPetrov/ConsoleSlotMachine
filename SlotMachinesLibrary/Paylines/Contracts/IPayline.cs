using SlotMachinesLibrary.Slots.Contracts;
using System.Collections.Generic;


namespace SlotMachinesLibrary.Paylines.Contracts
{
    /// <summary>
    /// Class providing functionality and information of the every payline of a slot machine.
    /// Hold collection of slots.
    /// </summary>
    public interface IPayline
    {
        /// <summary>
        /// Add slot to payline
        /// </summary>
        /// <param name="slot"></param>
        void AddSlot(ISlot slot);

        /// <summary>
        /// Return collection of slots of payline
        /// </summary>
        /// <returns></returns>
        IEnumerable<ISlot> GetAllSlots();

        /// <summary>
        /// Check if payline has wining combination of slots.
        /// Return true if all slots meet the requirements for winning combination.
        /// </summary>
        /// <returns>Boolean</returns>
        bool HasWinningCombination();

        /// <summary>
        /// Return sum of all coefficients of slot collection of a payline
        /// </summary>
        /// <returns>Decimal</returns>
        decimal GetTotalCoefficient();
    }
}
