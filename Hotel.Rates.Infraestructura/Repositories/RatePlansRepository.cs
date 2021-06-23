using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Infraestructura.Repositories
{
	class RatePlansRepository: BaseRepository<RatePlan>
	{

		private readonly InventoryContext _inventoryContext;

		public RatePlansRepository(InventoryContext inventoryContext)
		{
			this._inventoryContext = inventoryContext;
		}

		public override RatePlan Create(RatePlan entity)
		{
			_inventoryContext.RatePlans.Add(entity);
			return entity;
		}

		public override IQueryable<RatePlan> Get()
		{
			return _inventoryContext.RatePlans;
		}

		public override RatePlan Get(int id)
		{
			return _inventoryContext.RatePlans.FirstOrDefault(x => x.Id == id);
		}

		public override RatePlan Update()
		{
			_inventoryContext.SaveChanges();
			return null;
		}
	}
}
