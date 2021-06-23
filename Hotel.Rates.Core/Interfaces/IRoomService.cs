using System;
using System.Collections.Generic;
using System.Text;
using Hotel.Rates.Core.Models;

using Hotel.Rates.Infrastructura;

namespace Hotel.Rates.Core.Interfaces
{
	public interface IRoomService
	{
		ServiceResult<IEnumerable<RoomDto>> Get();
	}
}
