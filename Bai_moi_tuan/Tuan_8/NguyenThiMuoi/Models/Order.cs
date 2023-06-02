namespace THtuan11.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Orderid { get; set; }

        public DateTime OrderDate { get; set; }

        [StringLength(50)]
        public string OrderNumber { get; set; }

        public byte Status { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Tel { get; set; }
    }
}
