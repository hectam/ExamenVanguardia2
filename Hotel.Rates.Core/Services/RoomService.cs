using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Models;
using Hotel.Rates.Infrastructura;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Linq;

namespace Hotel.Rates.Core.Services
{
	class RoomService
	{
        private readonly IRepository<Room> roomRepository;

        public RoomService(IRepository<Room> _roomRepository)
        {
            this.roomRepository = _roomRepository;
        }
        public ServiceResult<IEnumerable<RoomDto>> Get()
        {
            var rooms = roomRepository.Get().Select(r => new RoomDto
            {
                Id = r.Id,
                Name = r.Name,
                MaxAdults = r.MaxAdults,
                MaxChildren = r.MaxChildren,
                Amount = r.Amount
            });

            return ServiceResult<IEnumerable<RoomDto>>.SuccessResult(rooms);
        }
    }
}
