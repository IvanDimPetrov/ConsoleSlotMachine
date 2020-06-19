using SlotMachinesLibrary.Paylines.Implementations;
using SlotMachinesLibrary.Paylines.Contracts;
using SlotMachinesLibrary.SlotMachines.Abstracts;
using System.Collections.Generic;
using System.Linq;
using SlotMachinesLibrary.Paylines.Factories;

namespace SlotMachinesLibrary.SlotMachines.Implementations
{

    /// <summary>
    /// Implementation of the slot machine PaylineWithWildCard
    /// </summary>
    public class BedeSlotMachine : SlotMachine
    {
        /// <summary>
        /// Constructor of the BedeSlot Machine
        /// </summary>
        /// <param name="paylinesCount">Count of the paylines of the BedeSlotMachine.Default value of 4</param>
        /// <param name="slotsCount">Count of the slots for every payline of BedeSlotMachine.Default value of 3</param>
        public BedeSlotMachine(int paylinesCount = 4, int slotsCount = 3) : base(paylinesCount, slotsCount)
        {
        }

        #region Public Methods

        /// <summary>
        /// Generate paylines with wild card and calculate current state of the machine
        /// </summary>
        public override void Spin()
        {
            this.ResetCurrentState();

            for (int i = 1; i <= this._paylinesCount; i++)
            {
                var currentPayLine = PaylineFactory.GenerateRandomPayLine<PaylineWithWildCard>(this._slotsCollection, this._slotsCount);

                this._currentPaylines.Add(currentPayLine);
            }

            this.CalculateCurrentState();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Reseting current state;
        /// </summary>
        private void ResetCurrentState()
        {
            this._currentPaylines.Clear();
            this._winningAmount = 0;
        }

        /// <summary>
        /// Calculate current wining amount if BedeSlotMachine has wining paylines
        /// and set deposit accordind this formula: ({deposit amount} - {stake amount}) + {win amount})
        /// </summary>
        private void CalculateCurrentState()
        {
            this._deposit -= this._stakeAmount;

            IEnumerable<IPayline> winningPayLines = this._currentPaylines.Where(x => x.HasWinningCombination());

            foreach (var payline in winningPayLines)
            {
                decimal totalCoefficient = payline.GetTotalCoefficient();
                this._winningAmount += totalCoefficient * this._stakeAmount;
            }

            this._deposit += this._winningAmount;

        }

        #endregion

    }
}
