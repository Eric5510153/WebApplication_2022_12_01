using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Xml;

namespace MCSDD26.Models
{
    public class MCSDD26Initializer:DropCreateDatabaseAlways<MCSDD26Ccontext>
    {
        protected override void Seed(MCSDD26Ccontext db)
        {
            base.Seed(db);


            List<Shippers> shippers = new List<Shippers>
            {
                new Shippers

                {
                    ShipVia = "取貨付款"

                },
                new Shippers

                {
                    ShipVia = "宅配"

                },
                new Shippers

                {
                    ShipVia = "郵寄"

                }
            };
            shippers.ForEach(s => db.Shippers.Add(s));
            db.SaveChanges();

            List<PayTypes> payTypes = new List<PayTypes>

            {
                new PayTypes

                {
                    PayTypeName = "匯款"

                },
                new PayTypes

                {
                    PayTypeName = "信用卡"

                },
                new PayTypes

                {
                    PayTypeName = "貨到付款"

                },
                new PayTypes

                {
                    PayTypeName = "取貨付款"

                }

            };
            payTypes.ForEach(s => db.PayTypes.Add(s));
            db.SaveChanges();





            List<Employees> employees = new List<Employees>
            {
                new Employees
                {
                EmployeeName="陳某某",
                CreateDate= DateTime.Today,
                Account="admin",
                Password="123456"

         }
            };

            employees.ForEach(s => db.Employees.Add(s));
            db.SaveChanges();




            List<Members> members = new List<Members>
            { 
             new Members
             { 
             MemberName="張某某",
             MemberBirdthday=Convert.ToDateTime("1999/09/09"),
             CreatedDate= DateTime.Today,
             Account="Zhang123",
             Password="19990909"

             }
            
           
            };
            members.ForEach(s => db.Members.Add(s));
            db.SaveChanges();





        }

        }
    }