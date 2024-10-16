using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Order : Base
    {
        public int id { get; set; }
        public DateTime order_date { get; set; }
        public decimal total_amount { get; set; }
        public required string status { get; set; }
        public int user_id { get; set; }
        public required User user { get; set; }

        public Order()
        {
            order_date = DateTime.Now;
        }
    }
}