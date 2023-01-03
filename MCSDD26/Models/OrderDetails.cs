using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSDD26.Models
{
    public class OrderDetails
    {
      public string OrderID { get; set; }
        public string ProductID { get; set; }

        public short UnitPrice { get; set; }
        public short Quantity { get; set; }

        //關聯
        public virtual Orders Orders { get; set; }
        public virtual Products Products { get; set; }

    }
}