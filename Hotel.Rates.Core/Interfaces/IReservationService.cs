using Hotel.Rates.Infrastructura;
using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Rates.Core.Models;

namespace Hotel.Rates.Core.Interfaces
{
	public interface IReservationService<T>
	{
		ServiceResult<T> NightlyPlan(ReservationModelDto reservation);
		ServiceResult<T> IntervalPlan(ReservationModelDto reservation);
	}
}
