//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDZ.Models.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class vw_ActiveAuctionsWithCurrentBids
    {
        public System.Guid AuctionID { get; set; }
        public string AuctionTitle { get; set; }
        public System.DateTime StartTime { get; set; }
        public System.DateTime EndTime { get; set; }
        public long StartingPrice { get; set; }
        public long BuyNowPrice { get; set; }
        public long MinBidStep { get; set; }
        public System.DateTime CreateDate { get; set; }
        public Nullable<long> LastBidAmount { get; set; }
        public Nullable<System.DateTime> LastBidTime { get; set; }
        public string LastBidderLogin { get; set; }
    }
}
