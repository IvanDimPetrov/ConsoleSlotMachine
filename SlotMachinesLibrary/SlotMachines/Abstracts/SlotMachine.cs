using SlotMachinesLibrary.Paylines.Contracts;
using SlotMachinesLibrary.SlotMachines.Models;
using SlotMachinesLibrary.Slots.Contracts;
using System;
using System.Collections.Generic;

namespace SlotMachinesLibrary.SlotMachines.Abstracts
{
    /// <summary>
    /// Base class for all slot games
    /// Provide functionality for proper work of a slot machine.
    /// One methods have to be implemented in the derived class:
    /// 1.Spin - generation of the paylines for specific slot machine and necessary calculation
    /// </summary>
    public abstract class SlotMachine
    {
        #region Protected fields

        protected int _paylinesCount;
        protected int _slotsCount;


        protected decimal _deposit;
        protected decimal _stakeAmount;

        //hold value of winning amount for every spin
        protected decimal _winningAmount;

        protected IList<ISlot> _slotsCollection;

        //hold genereted paylines for every spin
        protected IList<IPayline> _currentPaylines = new List<IPayline>();
        #endregion

        #region Public Properties

        public decimal Deposit { 
            get{ return this._deposit; } 
            set {

                if (value <= 0)
                    throw new Exception("Deposit can not be zero or negative.");

                this._deposit = value; 
            }
        }

        public decimal StakeAmount
        {
            get { return this._stakeAmount; }
            set {

                if (value <= 0)
                    throw new Exception("Stake amount can not be zero or negative.");

                this._stakeAmount = value; 
            }
        }

        public IList<IPayline> CurrentPayLines
        {
            get { return this._currentPaylines; }
        }

        #endregion

        /// <summary>
        /// Constructor of the slot machine class
        /// </summary>
        /// <param name="paylinesCount">Count of the paylines of the slot machine</param>
        /// <param name="slotsCount">Count of slots for every payline of the slot machine</param>
        public SlotMachine(int paylinesCount, int slotsCount)
        {
            this._paylinesCount = paylinesCount;
            this._slotsCount = slotsCount;
        }

        #region Public methods

        /// <summary>
        /// Methods for providing slots for proper work of the machine
        /// </summary>
        /// <param name="slotCollection"></param>
        public void SetupSlotTypes(IList<ISlot> slotCollection)
        {
            this._slotsCollection = slotCollection;
        }


        /// <summary>
        /// Return paylines, actual amount of deposit and current winning amount of the slot machine;
        /// </summary>
        /// <returns>SlotMachineCurrentState - Model that hold current state of the slot machine</returns>
        public virtual SlotMachineCurrentState GetCurrentState()
        {
            return new SlotMachineCurrentState()
            {
                Paylines = this._currentPaylines,
                Deposit = this._deposit,
                CurrentWiningAmount = this._winningAmount
            };
        }

        /// <summary>
        /// Generating paylines and make necessary calculation for every spin of the slot machine 
        /// </summary>
        public abstract void Spin();

  
        #endregion

    }
}
