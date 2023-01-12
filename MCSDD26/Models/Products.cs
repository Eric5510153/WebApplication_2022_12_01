using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MCSDD26.Models
{
    public class Products
    {
        [Key]
        [DisplayName("商品編號")]
        [StringLength(6)]
        [RegularExpression("[A-F][0-9]{5}")]  //此ID應於資料庫撰自動編號之程式
        public string ProductID { get; set; }



        [DisplayName("商品名稱")]
        [Required(ErrorMessage = "商品名稱為必填欄位")]
        [StringLength(150, ErrorMessage = "名稱長度過長")]
        public string ProductName { get; set; }


        [DisplayName("商品圖片")]
        [Required(ErrorMessage = "請上傳商品圖片")]
        public byte[] PhotoFile { get; set; }


        [DisplayName("圖片格式")]
        [StringLength(20)]
        public string ImageMimeType { get; set; }


        [DisplayName("商品單價")]
        [Required(ErrorMessage ="商品單價為必填欄位")]
        [Range(0, short.MaxValue, ErrorMessage = "單價不可小於0")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public short UnitPrice { get; set; }


        [DisplayName("商品敘述")]
        [Required(ErrorMessage = "商品敘述為必填欄位")]
        [StringLength(1000, ErrorMessage = "商品介紹不得超過1000字")]
        public string Description { get; set; }



        [DisplayName("商品庫存量")]
        [Required(ErrorMessage = "商品庫存量為必填欄位")]
        [Range(0, short.MaxValue, ErrorMessage = "庫存量不可小於0")]
        public short UnitsInStock { get; set; }



        [DisplayName("已下架")]
        [DefaultValue(false)]
        public bool Discontinued { get; set; }


        [DisplayName("建立日期")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        public DateTime CreateTime { get; set; }

    }
}