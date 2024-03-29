﻿using System;
using System.Linq;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // POST /api/newrentals
        [HttpPost]
        public IHttpActionResult CreateRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers
                                    .Single(c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies
                                .Where(m => newRentalDto.MovieIds.Contains(m.Id))
                                .ToList();

            var currentDate = DateTime.Now;

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("Movie is unavailable");

                movie.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = currentDate
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
