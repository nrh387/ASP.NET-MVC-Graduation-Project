﻿using System.Web.Mvc;

namespace Auction.Web.Controllers
{
    using System;
    using System.Linq;
    using Models;

    public class AuctionController : BaseController
    {
        // GET: Auction
        public ActionResult CreateAuction()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAuction(CreateAuctionModel auction)
        {
            if (ModelState.IsValid)
            {
                var item = this.DbContext.Items.FirstOrDefault(i => i.Title == auction.ItemTitle);
                var currentUser = this.DbContext.Users.FirstOrDefault(u => u.UserName == this.User.Identity.Name );
                var bidders = this.DbContext.Users.OrderBy(u => u.UserName).Take(3).ToList();

                this.DbContext.Auctions.Add(new Auction
                {
                    Name = auction.Name,
                    Item = item,
                    DateOfCreation = DateTime.UtcNow,
                    DateOfAuction = auction.DateOfAuction,
                    Creator = currentUser,
                    Bidders = bidders
                });

                this.DbContext.SaveChanges();

                TempData["Success"] = "You have successfully created Auction";

                return RedirectToAction("CreateAuction");
            }

            return View("CreateAuction", auction);
        }
    }
}