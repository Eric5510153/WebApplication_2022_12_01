using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MCSDD26.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }
        [DisplayName("員工姓名")]
        [StringLength(40,ErrorMessage ="姓名長度過長")]
        [Required(ErrorMessage ="姓名為必填欄位")]
        public string EmployeeName { get; set; }



        [DisplayName("建立日期")]
        [DisplayFormat(DataFormatString ="{0:yyyy/MM/dd hh:mm}",ApplyFormatInEditMode =true)]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime CreateDate { get; set; }


        [DisplayName("帳號")]
        [Required(ErrorMessage = "帳號為必填欄位")]
        [StringLength(20, ErrorMessage = "帳號不可超過20字")]
        [RegularExpression("[A-Za-z]{1}[A-Za-z0-9]{4,19}")]
        public string Account { get; set; }



        //string password;

        [DisplayName("密碼")]
        [Required(ErrorMessage = "密碼為必填欄位")]
        [DataType(DataType.Password)]
        //[MinLength(8,ErrorMessage ="密碼最少8個字元")]
        //[MaxLength(8, ErrorMessage = "密碼最多20個字元")]
        //[StringLength(20)]
        public string Password { get; set; }
       /* public string Password 
        {
            get 
            {

            return password   ;
            }

            set
            {

                password = BR.getHashPassword(value);
            
            } 
        }

        */


        //public string getHashPassword(string pw)
        //{

        //    byte[] hashValue;
        //    string result = "";
        //    System.Text.UnicodeEncoding ue = new System.Text.UnicodeEncoding();
        //    byte[] pwBytes = ue.GetBytes(pw);
        //    SHA256 shHash = SHA256.Create();
        //    hashValue = shHash.ComputeHash(pwBytes);
        //    foreach (byte b in hashValue)
        //    {

        //        result += b.ToString();
        //    }

        //    return result;

        //}







    }

    }

    


