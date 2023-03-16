﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MCSDD26.Models
{
    public class setData
    {
        
        //1.建立資料庫連線物件
        static SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["MCSDD26Connection"].ConnectionString);
        //2.建立SQL命令物件
        SqlCommand cmd = new SqlCommand("", conn);

        public void executeSql(string sql)
        {
            cmd.CommandText = sql;

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        /// <summary>
        /// 必須傳入SqlParameter List泛型參數
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="list"></param>
        public void executeSql(string sql, List<SqlParameter> list)
        {
            cmd.CommandText = sql;

            foreach (var p in list)
            {
                cmd.Parameters.Add(p);
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }



        public void executeSqlBySP(string SPName)
        {
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }

        /// <summary>
        /// 必須傳入SqlParameter List泛型參數
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="list"></param>
        public void executeSqlBySP(string SPName, List<SqlParameter> list)
        {
            cmd.CommandText = SPName;
            cmd.CommandType = CommandType.StoredProcedure;

            foreach (var p in list)
            {
                cmd.Parameters.Add(p);
            }

            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
    }
}