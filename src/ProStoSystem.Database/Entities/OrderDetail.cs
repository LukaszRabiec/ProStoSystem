using System;
using System.Collections.Generic;

namespace ProStoSystem.Database.Entities
{
    public class OrderDetail
    {
        public OrderDetail()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string Customer { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public string Comment { get; set; }
        public decimal Discount { get; set; }
        public int BillTypeId { get; set; }
        public int SalesmanId { get; set; }


        public virtual BillType BillType { get; set; }
        public virtual Salesman Salesman { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
