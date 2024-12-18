using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace IDZ.Models.DTO
{
    public class AuctionDTO
    {
        [Display(Name = "Название")]
        public string Title { get; set; }
        public string CreatedLogin { get; set; }
        public string Description { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public long StartingPrice { get; set; }
        public long BuyNowPrice { get; set; }
        public long MinBidStep { get; set; }
        public string CategoryName { get; set; }
    }
}