using SlotMachinesLibrary.Paylines.Contracts;
using System.Collections.Generic;


namespace SlotMachinesLibrary.SlotMachines.Models
{
    /// <summary>
    /// Class represent current state of a slot machine
    /// </summary>
    public class SlotMachineCurrentState
    {
        /// <summary>
        /// Collection of all paylines in the machine 
        /// </summary>
        public IEnumerable<IPayline> Paylines { get; set;  }

        /// <summary>
        /// Current amount of the deposit
        /// </summary>
        public decimal Deposit { get; set; }

        /// <summary>
        /// Current winning amount
        /// </summary>
        public decimal CurrentWiningAmount { get; set; }
    }
}
