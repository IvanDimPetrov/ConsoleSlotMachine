using SlotMachinesLibrary.Paylines.Contracts;
using SlotMachinesLibrary.Slots.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace SlotMachinesLibrary.Paylines.Implementations

{

    /// <summary>
    /// Implementation of payline with WildCard(*).
    /// The payline has winning cobination if contains 3 matching symbols.
    /// Wildcard(*) is a symbol that matches any other symbol;
    /// </summary>
    public class PaylineWithWildCard : IPayline
    {

        #region Private fields
        private readonly string _wildCard = "*";
        private IList<ISlot> _slots = new List<ISlot>();
        #endregion

        #region Public methods
        /// <summary>
        /// Add slot to list collection of slots;
        /// </summary>
        /// <param name="slot">slot that have to be added</param>
        public void AddSlot(ISlot slot)
        {
            this._slots.Add(slot);
        }

        /// <summary>
        /// Return all slots of a payline
        /// </summary>
        /// <returns>List<ISlot> collection</returns>
        public IEnumerable<ISlot> GetAllSlots()
        {
            return this._slots;
        }

        /// <summary>
        /// Check if payline has wining combination of slots.
        /// Return true if all slots meet the requirements for winning combination.
        /// If payline has three matching slots, or matching slot with wild card return true.
        /// </summary>
        /// <returns>Boolean</returns>
        public bool HasWinningCombination()
        {
            //Extract all slots with wild card value, then grouping  and counting
            //so for wining combination count of the group has to be 1 or 0;
            var groupCount = this._slots.Where(x => x.Value != this._wildCard).GroupBy(x => x.Value).Count();
            return groupCount > 1 ? false : true;
        }

        /// <summary>
        /// Return sum of all coefficients of slot collection of a payline.
        /// </summary>
        /// <returns>Decimal</returns>
        public decimal GetTotalCoefficient()
        {
            return this._slots.Sum(x => x.Coefficient);
        }

        public override string ToString()
        {
            return string.Join("|", this._slots.Select(x => x.Value));
        }
        #endregion

    }
}
