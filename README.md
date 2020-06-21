Console application for simplified Slot machine. 
The specification for the slot machine are described in 'Bede_Simplified_Slot_Machine_-_.NET_Developer_Task.pdf' in the repository.
This application use 'SlotMachinesLibrary'.
This library provides API for creating and using the various slot machines.
With this library you may implement or use slot machine that work with diferent types of slots and different types of paylines.
Paylines represent collections of slots with logic how to calculate total winning coefficient of all slots of the payline
and matching algorithm to determine if payline is winning. Every slot holds value, winning coefficient and probability to appear on the cell.
Here we use 'BedeSlotMachine' that works with 'PaylineWithWildCard' payline with logic for calculating deposit, winning amount and winning combination of slots for every payline according specification described in 'Bede_Simplified_Slot_Machine_.NET_Developer_Task.pdf' file.
In this library can be implemented various paylines with logic for calculation of total winning coefficient or winning combination of slots.
Also it can be implemented variuos slot machines that works with different counts of paylines, slots own logic for calculating deposit and winning amount and specific type of payline.



