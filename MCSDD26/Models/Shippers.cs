﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD26.Models
{
    public class Shippers
    {
        [Key]
        public int ShipID { get; set; }

        [DisplayName("運送方式")]
        [Required(ErrorMessage = "請輸入運送方式")]
        [StringLength(20, ErrorMessage = "運送方式最多20個字")]
        public string ShipVia { get; set; }
    }
}