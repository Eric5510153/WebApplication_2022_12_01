using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _06ADOnet.Models
{
    public class VMLogin
    {
        [DisplayName("Account")]
        [Required(ErrorMessage = "Please Enter Account")]
        public string Account { get; set; }
        [DisplayName("Password")]
        [Required(ErrorMessage = "Please Enter Password")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        




    }
}