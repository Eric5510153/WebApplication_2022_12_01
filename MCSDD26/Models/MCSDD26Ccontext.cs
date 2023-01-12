using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;


namespace MCSDD26.Models
{
    public class MCSDD26Ccontext:DbContext //繼承Db Context類別
    {

        public  MCSDD26Ccontext():base("name=MCSDD26Connection") 
        { 
        
        
        }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //   throw new UnintentionalCodeFirstException();
        //}
        public virtual DbSet<Employees> Employees { get;set;}
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<PayTypes> PayTypes { get; set; }
        public virtual DbSet<Shippers> Shippers { get; set; }
        public virtual DbSet<OrderDetails> OrderDetails { get; set; }

    }
}