using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Entities;
using System.Linq;

namespace Hotel.Rates.Infraestructura.Repositories
{
	class NigthRatePlanRepository : IRepository<NightlyRatePlan>
	{
		private readonly InventoryContext _inventoryContext;

		public NigthRatePlanRepository(InventoryContext inventoryContext)
		{
			this._inventoryContext = inventoryContext;
		}
		public NightlyRatePlan Create(NightlyRatePlan entity)
		{
			_inventoryContext.NightlyRatePlans.Add(entity);
			return entity;
		}

		public IReadOnlyList<NightlyRatePlan> Get()
		{
			return _inventoryContext.NightlyRatePlans.ToList();
		}

		public NightlyRatePlan Get(int id)
		{
			return _inventoryContext.NightlyRatePlans.FirstOrDefault(x => x.Id == id);
		}
	}
}
