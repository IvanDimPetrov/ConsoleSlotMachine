

namespace SlotMachinesLibrary.Slots.Contracts
{
    /// <summary>
    /// Class represent slot of a payline
    /// </summary>
    public interface ISlot
    {
        /// <summary>
        /// Value of the slot
        /// </summary>
        string Value { get; set; }

        /// <summary>
        /// Coefficient of the slot 
        /// </summary>
        decimal Coefficient { get; set; }

        /// <summary>
        /// Probability of the slot.
        /// </summary>
        int Probability { get; set; }
    }
}
