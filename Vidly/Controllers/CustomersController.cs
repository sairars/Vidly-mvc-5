﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET Customers/1
        public ActionResult Details(int id)
        {
            var customer = _context.Customers
                                   .Include(c => c.MembershipType)
                                   .SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        // GET Customers/New
        public ActionResult New()
        {
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = new Customer()
            };

            return View("CustomerForm", viewModel);
        }

        // GET Customers/Edit/1
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = customer
            };

            return View("CustomerForm", viewModel);
        }

        // POST Customers/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid) 
            {
                var viewModel = new CustomerFormViewModel
                {
                    MembershipTypes = _context.MembershipTypes.ToList(),
                    Customer = customer
                };

                return View("CustomerForm", viewModel);
            }
                
            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == customer.Id);

                if (customerInDb == null)
                    return HttpNotFound();

                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;

            }

            _context.SaveChanges();
            
            return RedirectToAction("Index", "Customers");
        }
    }
}