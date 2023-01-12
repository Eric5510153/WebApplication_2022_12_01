using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Runtime.CompilerServices;

namespace MCSDD26.Models
{

        public class Orders
        {
            [Key]
            [DisplayName("訂單編號")]
            [StringLength(11)]
          
         public string OrderID { get; set; }

            [DisplayName("訂單成立時間")]
            [DataType(DataType.DateTime)]
            
        public DateTime OrderDate { get; set; }

            [DisplayName("收貨人姓名")]
            [Required(ErrorMessage ="收件人姓名為必填欄位")]
            [StringLength(40,ErrorMessage = "收件人姓名長度過長")]
        public string ShipName { get; set; }

            [DisplayName("收貨人地址")]
            [Required(ErrorMessage ="收件人地址為必填欄位")]
            [StringLength(100,ErrorMessage = "收件人地址長度過長")]
         public string ShipAddress { get; set; }

            [DisplayName("出貨日")]
            [DataType(DataType.DateTime)]
         public Nullable<DateTime> ShippedDate { get; set; }


            //Forign Key
            public int EmployeeID { get; set; }
            [Required]
            public int MemberID { get; set; }
            public int ShipID { get; set; }
            [Required]
            public int PayTypeID { get; set; }

            //拉關聯
            public virtual Employees Employees { get; set; }
            public virtual Members Members { get; set; }
            public virtual Shippers Shippers { get; set; }
            public virtual PayTypes PayTypes { get; set; }
        }
    }

