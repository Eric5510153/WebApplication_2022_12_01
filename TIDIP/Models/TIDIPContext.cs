using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TIDIP.Models
{
    public class TIDIPContext:DbContext
    {
        public TIDIPContext():base("name=TIDIPConnection")
            {


            }

        public virtual DbSet<Admin>Admin { get; set; }
        public virtual DbSet<Member>Member { get; set; }
        public virtual DbSet<Disaster_Accident> Disaster_Accident { get; set; }
        public virtual DbSet<Disaster_Accident_Type> Disaster_Accident_Type { get; set; }
        
        public virtual DbSet<Police> Police { get; set; }
        public virtual DbSet<Rescue> Rescue { get; set; }
        public virtual DbSet<Medical> Medical { get; set; }
        
    }
}