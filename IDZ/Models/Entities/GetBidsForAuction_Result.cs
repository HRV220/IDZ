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
    
    public partial class GetBidsForAuction_Result
    {
        public System.Guid BidID { get; set; }
        public long BidAmount { get; set; }
        public System.DateTime BidTime { get; set; }
        public string BidderLogin { get; set; }
    }
}
