using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Entities;
using System.Linq;

namespace Hotel.Rates.Infraestructura.Repositories
{
	class NigthRatePlanRepository : BaseRepository<NightlyRatePlan>
	{
		private readonly InventoryContext _inventoryContext;

		public NigthRatePlanRepository(InventoryContext inventoryContext)
		{
			this._inventoryContext = inventoryContext;
		}
		public override NightlyRatePlan Create(NightlyRatePlan entity)
		{
			_inventoryContext.NightlyRatePlans.Add(entity);
			return entity;
		}

		public override IQueryable<NightlyRatePlan> Get()
		{
			return _inventoryContext.NightlyRatePlans;
		}

		public override NightlyRatePlan Get(int id)
		{
			return _inventoryContext.NightlyRatePlans.FirstOrDefault(x => x.Id == id);
		}

		public override NightlyRatePlan Update()
		{
			_inventoryContext.SaveChanges();
			return null;
		}
	}
}
