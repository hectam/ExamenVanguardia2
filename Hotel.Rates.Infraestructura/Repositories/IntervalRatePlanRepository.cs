using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Entities;
using System.Linq;

namespace Hotel.Rates.Infraestructura.Repositories
{
	class IntervalRatePlanRepository : BaseRepository<IntervalRatePlan>
	{
		private readonly InventoryContext _inventoryContext;

		public IntervalRatePlanRepository(InventoryContext inventoryContext)
		{
			this._inventoryContext = inventoryContext;
		}

		public override IntervalRatePlan Create(IntervalRatePlan entity)
		{
			_inventoryContext.IntervalRatePlans.Add(entity);
			return entity;
		}

		public override IQueryable<IntervalRatePlan> Get()
		{
			return _inventoryContext.IntervalRatePlans;
		}

		public override IntervalRatePlan Get(int id)
		{
			return _inventoryContext.IntervalRatePlans.FirstOrDefault(x => x.Id == id);
		}

		public override IntervalRatePlan Update()
		{
			_inventoryContext.SaveChanges();
			return null;
		}


	}
}
