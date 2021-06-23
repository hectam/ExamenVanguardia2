using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Models;
using Hotel.Rates.Infrastructura;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Interfaces
{
	public interface IRatePlanService
	{
		ServiceResult<IEnumerable<RatePlanDto>> GetAll();
		ServiceResult<RatePlanDto> Get(int id);

	}
}
