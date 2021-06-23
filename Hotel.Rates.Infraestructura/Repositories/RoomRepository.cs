using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Infraestructura.Repositories
{
	class RoomRepository : BaseRepository<Room>
	{
		private readonly InventoryContext _inventoryContext;

		public RoomRepository(InventoryContext inventoryContext)
		{
			this._inventoryContext = inventoryContext;
		}

		public override Room Create(Room entity)
		{
			_inventoryContext.Rooms.Add(entity);
			return entity;
		}

		public override IQueryable<Room> Get()
		{
			return _inventoryContext.Rooms;
		}

		public override Room Get(int id)
		{
			return _inventoryContext.Rooms.FirstOrDefault(x => x.Id == id);
		}

		public override Room Update()
		{
			_inventoryContext.SaveChanges();
			return null;
		}
	}
}
