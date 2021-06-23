using System;
using System.Collections.Generic;
using System.Text;



namespace Hotel.Rates.Infrastructure.Interfaces
{
	class IRoomService
	{

		private readonly InventoryContext _inventoryContext;

		public RoomsRepository(InventoryContext inventoryContext)
		{
			this._inventoryContext = inventoryContext;
		}
	}
}
