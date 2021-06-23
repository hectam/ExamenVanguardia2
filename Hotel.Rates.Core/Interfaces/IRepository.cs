using System;
using System.Collections.Generic;
using System.Linq;

namespace Hotel.Rates.Core.Interfaces
{
	public interface IRepository<TEntity>
	{
		IReadOnlyList<TEntity> Get();

		TEntity Get(int id);

		TEntity Create(TEntity entity);

	}
}
