﻿namespace Auction.Web.ViewModels.Auction
{
    using System;
    using System.Linq.Expressions;

    using global::Auction.Infrastructure.Mapping;

    using Models;

    public class AuctionViewModel : IMapFrom<Auction>
    {
        public static Expression<Func<Auction, AuctionViewModel>> FromAuction
        {
            get
            {
                return auction => new AuctionViewModel { 
                    Id = auction.Id,
                    Name = auction.Name,
                    DateOfAuction = auction.DateOfAuction,
                    Active = auction.Active,
                    InitialPrice = auction.InitialPrice,
                    BidStep = auction.BidStep,
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateOfAuction { get; set; }

        public bool Active { get; set; }

        public int InitialPrice { get; set; }

        public int BidStep { get; set; }
    }
}