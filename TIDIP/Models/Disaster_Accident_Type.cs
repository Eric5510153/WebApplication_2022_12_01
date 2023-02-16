﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TIDIP.Models
{
    public class Disaster_Accident_Type
    {
        [Key]
        [DisplayName("災害事故類型編號")]
        public string  DATypeID { get; set; }



        [Required]
        [DisplayName("災害事故類型名稱")]
        public string DATypeName { get; set; }




    }
}