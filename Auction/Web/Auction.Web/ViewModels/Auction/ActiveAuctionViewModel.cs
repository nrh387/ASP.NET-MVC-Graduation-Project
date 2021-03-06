﻿using System.Collections.Generic;

namespace Auction.Web.ViewModels.Auction
{
    using System;

    using global::Auction.Infrastructure.Mapping;
    using global::Auction.Models;

    public class ActiveAuctionViewModel : IMapFrom<Auction>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Value { get; set; }

        public bool Active { get; set; }

        public DateTime DateOfAuction { get; set; }

        public int InitialPrice { get; set; }

        public int CurrentPrice { get; set; }

        public int BidStep { get; set; }

        public string WinnerId { get; set; }

        public string ReceiverId { get; set; }

        public ICollection<Item> Items { get; set; }

        public ICollection<User> Bidders { get; set; }
    }
}