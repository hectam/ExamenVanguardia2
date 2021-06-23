using Hotel.Rates.Core.Entities;
using Hotel.Rates.Core.Interfaces;
using Hotel.Rates.Core.Models;
using Hotel.Rates.Infrastructura;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hotel.Rates.Core.Services
{
	class ReservationService : IReservationService<double>
	{

        private readonly IRepository<NightlyRatePlan> nightRatePlanRepository;
        private readonly IRepository<IntervalRatePlan> intervalRatePlanRepository;
      

        public ReservationService(IRepository<NightlyRatePlan> nightlyRatePlanRepository, IRepository<IntervalRatePlan> intervalRatePlanRepository)
        {
            this.nightRatePlanRepository = nightlyRatePlanRepository;
            this.intervalRatePlanRepository = intervalRatePlanRepository;
        }
        public ServiceResult<double> IntervalPlan(ReservationModelDto reservationModel)
		{
            
            var ratePlan = intervalRatePlanRepository.Get()
               .Include(r => r.Seasons)
               .Include(r => r.RatePlanRooms)
               .ThenInclude(r => r.Room)
               .First(r => r.Id == reservationModel.RatePlanId);

            var canReserve = ratePlan.Seasons
                .Any(s => reservationModel.ReservationStart >= s.StartDate && reservationModel.ReservationEnd <= s.EndDate && (reservationModel.ReservationEnd - reservationModel.ReservationStart).Days >= ratePlan.IntervalLength);

            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == reservationModel.RoomId && r.RatePlanId == reservationModel.RatePlanId);

            var isRoomAvailable = room.Room.Amount > 0 &&
                reservationModel.AmountOfAdults <= room.Room.MaxAdults &&
                reservationModel.AmountOfChildren <= room.Room.MaxChildren;

            if (canReserve && isRoomAvailable)
            {
                room.Room.Amount -= 1;
                intervalRatePlanRepository.Update();
                var days = (reservationModel.ReservationEnd - reservationModel.ReservationStart).TotalDays;
                var Price = days * (ratePlan.Price / ratePlan.IntervalLength);
                return ServiceResult<double>.SuccessResult(Price);
            }
            return ServiceResult<double>.ErrorResult("Error");
        }

		public ServiceResult<double> NightlyPlan(ReservationModelDto reservation)
		{
            var ratePlan = nightRatePlanRepository.Get()
               .Include(r => r.Seasons)
               .Include(r => r.RatePlanRooms)
               .ThenInclude(r => r.Room)
               .First(r => r.Id == reservation.RatePlanId);

            var canReserve = ratePlan.Seasons
                .Any(s => reservation.ReservationStart >= s.StartDate && reservation.ReservationEnd <= s.EndDate);

            var room = ratePlan.RatePlanRooms
                .First(r => r.RoomId == reservation.RoomId && r.RatePlanId == reservation.RatePlanId);

            var isRoomAvailable = room.Room.Amount > 0 &&
                reservation.AmountOfAdults <= room.Room.MaxAdults &&
                reservation.AmountOfChildren <= room.Room.MaxChildren;

            if (canReserve && isRoomAvailable)
            {
                room.Room.Amount -= 1;
                nightRatePlanRepository.Update();
                var days = (reservation.ReservationEnd - reservation.ReservationStart).TotalDays;
                var Price = days * ratePlan.Price;
                return ServiceResult<double>.SuccessResult(Price);
            }
            return ServiceResult<double>.ErrorResult("Error");
        }
	}


}
