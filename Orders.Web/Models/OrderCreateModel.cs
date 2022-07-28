using System;

namespace Orders.Web.Models
{
    public class OrderCreateModel
    {
        public string SendersCity { get; set; }
        public string SendersAddress { get; set; }
        public string RecipientsCity { get; set; }
        public string RecipientsAddress { get; set; }
        public double OrderWeightKg { get; set; }
        public DateTime PickupDate { get; set; }
    }
}