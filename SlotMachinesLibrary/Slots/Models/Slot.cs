using SlotMachinesLibrary.Slots.Contracts;

namespace SlotMachinesLibrary.Slots.Models
{
    /// <summary>
    /// Class represent slot of a payline
    /// </summary>
    public class Slot : ISlot
    {
        #region Public Properties
        public string Value { get; set; }
        public decimal Coefficient { get; set; }
        public int Probability { get; set; }
        #endregion

        #region Constructors
        public Slot() { }

        /// <summary>
        /// Constructor of the Slot class
        /// </summary>
        /// <param name="value">Value of the slot</param>
        /// <param name="coefficient">Coefficient of the slot</param>
        /// <param name="probability">Probability of the slot</param>
        public Slot(string value, decimal coefficient, int probability)
        {
            this.Value = value;
            this.Coefficient = coefficient;
            this.Probability = probability;
        }

        #endregion
    }
}
