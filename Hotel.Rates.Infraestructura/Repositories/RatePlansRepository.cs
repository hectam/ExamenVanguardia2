using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Infraestructura.Repositories
{
	class RatePlansRepository: IRepository<RatePlan>
	{

		private readonly InventoryContext _inventoryContext;

		public RatePlansRepository(InventoryContext inventoryContext)
		{
			this._inventoryContext = inventoryContext;
		}

		public RatePlan Create(RatePlan entity)
		{
			_inventoryContext.RatePlans.Add(entity);
			return entity;
		}

		public IReadOnlyList<RatePlan> Get()
		{
			return _inventoryContext.RatePlans.ToList();
		}

		public RatePlan Get(int id)
		{
			return _inventoryContext.RatePlans.FirstOrDefault(x => x.Id == id);
		}
	}
}
