using System.Collections.Generic;

namespace ProStoSystem.Database.Entities
{
    public class Salesman
    {
        public Salesman()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
