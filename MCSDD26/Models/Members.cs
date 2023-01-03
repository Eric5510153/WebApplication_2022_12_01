using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MCSDD26.Models
{
    public class Members
    {
        
            public int MemberId { get; set; }
            public string MemberName { get; set; }
            public string MemberPhotoFile { get; set; }
            public DateTime MemberBirdthday { get; set; }
            public DateTime CreateTime { get; set; }
            public string Account { get; set; }
            public string Password { get; set; }







    }
}