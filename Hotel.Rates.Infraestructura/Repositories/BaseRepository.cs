using Hotel.Rates.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Infraestructura.Repositories
{
	public abstract class BaseRepository<TEntity> : IRepository<TEntity>
	{
		
		public abstract TEntity Create(TEntity entity);

		public abstract IQueryable<TEntity> Get();

		public abstract TEntity Get(int id);

		public abstract TEntity Update();
	}
}
