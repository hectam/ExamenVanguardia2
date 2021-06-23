﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Hotel.Rates.Core.Models
{
	public class RoomDto
	{
		public long Id { get; set; }
		public string Name { get; set; }
		public int MaxAdults { get; set; }
		public int MaxChildren { get; set; }
		public int Amount { get; set; }

	}
}
