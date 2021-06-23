using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Entities;
using System.Linq;

namespace Hotel.Rates.Infraestructura.Repositories
{
	class IntervalRatePlanRepository : IRepository<IntervalRatePlan>
	{
		private readonly InventoryContext _inventoryContext;

		public IntervalRatePlanRepository(InventoryContext inventoryContext)
		{
			this._inventoryContext = inventoryContext;
		}

		public IntervalRatePlan Create(IntervalRatePlan entity)
		{
			_inventoryContext.IntervalRatePlans.Add(entity);
			return entity;
		}

		public IReadOnlyList<IntervalRatePlan> Get()
		{
			return _inventoryContext.IntervalRatePlans.ToList();
		}

		public IntervalRatePlan Get(int id)
		{
			return _inventoryContext.IntervalRatePlans.FirstOrDefault(x => x.Id == id);
		}

		

	
	}
}
