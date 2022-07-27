using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Orders.Data.Orders
{
    [Table("order")]
    public class OrderEntity
    {
        [Column("id")]
        public string Id { get; set; }
        [Column("order_number")]
        public int OrderNumber { get; set; }
        [Column("senders_city")]
        public string SendersCity { get; set; }
        [Column("senders_address")]
        public string SendersAddress { get; set; }
        [Column("recipients_city")]
        public string RecipientsCity { get; set; }
        [Column("recipients_address")]
        public string RecipientsAddress { get; set; }
        [Column("order_weight_kg")]
        public double OrderWeightKg { get; set; }
        [Column("pickup_date")]
        public DateTime PickupDate { get; set; }
        
        internal class Map : IEntityTypeConfiguration<OrderEntity>
        {
            public void Configure(EntityTypeBuilder<OrderEntity> builder)
            {
                builder.HasKey(x => x.Id);
            }
        }
    }
}