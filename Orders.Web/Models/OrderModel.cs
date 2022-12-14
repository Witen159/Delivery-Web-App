using System;

namespace Orders.Web.Models
{
    public class OrderModel
    {
        public int OrderNumber { get; set; }
        public string SendersCity { get; set; }
        public string SendersAddress { get; set; }
        public string RecipientsCity { get; set; }
        public string RecipientsAddress { get; set; }
        public double OrderWeightKg { get; set; }
        public DateTime PickupDate { get; set; }
    }
}