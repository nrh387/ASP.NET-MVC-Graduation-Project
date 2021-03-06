﻿namespace Auction.Services.Data
{
    using System.Linq;
    using System.Web.Mvc;
    using Auction.Data.Repositories;
    using Auction.Models;

    public class AuctionService : IAuctionService
    {
        private IDbRepository<Auction> auctionRepo;
        private IDbRepository<Item> itemRepo;

        public AuctionService(IDbRepository<Auction> auctionRepo, IDbRepository<Item> itemRepo)
        {
            this.auctionRepo = auctionRepo;
            this.itemRepo = itemRepo;
        }

        public IQueryable<Auction> GetAllAuctions()
        {
            return this.auctionRepo.All().OrderBy(a => a.DateOfAuction);
        }

        public Auction GetById(int id)
        {
            return this.auctionRepo.GetById(id);
        }

        public IQueryable<SelectListItem> GroupByTypes(ItemType itemType)
        {
            var auctionsByTypeOfItems =
                this.itemRepo.All()
                    .Where(item => item.Type == itemType && item.Auction.Id == item.AuctionId && item.AuctionId != null)
                    .Select(i => i.Auction);

            var auctionsAsListItems = auctionsByTypeOfItems.Select(a => new SelectListItem { Text = a.Name.ToString(), Value = a.Id.ToString() });
            
            return auctionsAsListItems;
        }
    }
}
