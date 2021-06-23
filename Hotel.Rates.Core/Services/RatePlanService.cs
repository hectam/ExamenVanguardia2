using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Models;
using Hotel.Rates.Infrastructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Core.Services
{
	class RatePlanService : IRatePlanService
	{
		private readonly IRepository<RatePlan> _RatePlanRepository;

		public RatePlanService(IRepository<RatePlan> ratePlanrepository)
		{
			this._RatePlanRepository = ratePlanrepository;
		}
		public Infrastructura.ServiceResult<IEnumerable<RatePlanDto>> GetAll()
		{
			
			var Ratep = _RatePlanRepository.Get().Select(x => new RatePlanDto {
				RatePlanId = x.Id,
				RatePlanName = x.Name,
				RatePlanType = x.RatePlanType,
				Price = x.Price,
				Seasons = x.Seasons.Select(s => new SeasonDto
				{
					Id = s.Id,
					StartDate = s.StartDate,
					EndDate = s.EndDate
				}),
				Rooms = x.RatePlanRooms.Select(r => new RoomDto
				{
					Id = 0,
					Name = r.Room.Name,
					MaxAdults = r.Room.MaxAdults,
					MaxChildren = r.Room.MaxChildren,
					Amount = r.Room.Amount
				})
			}
			);




			return ServiceResult<IEnumerable<RatePlanDto>>.SuccessResult(Ratep);
		}

		public Infrastructura.ServiceResult<RatePlanDto> Get(int id)
		{
			var ratePlan = _RatePlanRepository.Get(id);

			var dto = new RatePlanDto
			{
				RatePlanId = ratePlan.Id,
				RatePlanName = ratePlan.Name,
				RatePlanType = ratePlan.RatePlanType,
				Price = ratePlan.Price,
				Seasons = ratePlan.Seasons.Select(s => new SeasonDto
				{
					Id = s.Id,
					StartDate = s.StartDate,
					EndDate = s.EndDate
				}),
				Rooms = ratePlan.RatePlanRooms.Select(r => new RoomDto
				{
					Id = 0,
					Name = r.Room.Name,
					MaxAdults = r.Room.MaxAdults,
					MaxChildren = r.Room.MaxChildren,
					Amount = r.Room.Amount
				})
			};


			return ServiceResult<RatePlanDto>.SuccessResult(dto);
		}



	}
}
