using System.Collections.Generic;

namespace ProStoSystem.Database.Entities
{
    public class BillType
    {
        public BillType()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
