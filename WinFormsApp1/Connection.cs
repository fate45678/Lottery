﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace WinFormsApp1
{
    public partial class Connection : Component
    {
        static string DB_Account = "sa";
        static string DB_PW = "sa";

        public Connection()
        {
            InitializeComponent();
        }

        
        public static SqlConnection OpenSqlConn(string Server, string Database)
        {
            //string cnstr = string.Format("server={0};database={1};uid={2};pwd={3};Connect Timeout = 180", Server, Database, DB_Account, DB_PW);
            //SqlConnection icn = new SqlConnection();
            //icn.ConnectionString = cnstr;
            //if (icn.State == ConnectionState.Open) icn.Close();
            //icn.Open();
            //return icn;
            string ConnStr;
            ConnStr = "Data Source = 43.229.154.156;Initial catalog = lottery;" +
            "User id = sa; Password = sa";
            SqlConnection conn = new SqlConnection(ConnStr);
            conn.Open();
            return conn;
        }
        public DataTable GetSqlDataTable(string Server, string Database, string query)
        {
            DataTable dt = new DataTable();
            SqlConnection icn = null;
            icn = OpenSqlConn(Server, Database);
            SqlCommand isc = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter(isc);
            isc.Connection = icn;
            isc.CommandText = query;
            isc.CommandTimeout = 600;
            DataSet ds = new DataSet();
            ds.Clear();
            da.Fill(ds);
            dt = ds.Tables[0];
            if (icn.State == ConnectionState.Open) icn.Close();
            return dt;
        }

        public void SqlInsertUpdateDelete(string Server, string Database, string query)
        {
            SqlConnection icn = OpenSqlConn(Server, Database);
            SqlCommand cmd = new SqlCommand(query, icn);
            SqlTransaction mySqlTransaction = icn.BeginTransaction();
            try
            {
                cmd.Transaction = mySqlTransaction;
                cmd.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch (Exception ex)
            {
                mySqlTransaction.Rollback();
                throw (ex);
            }
            if (icn.State == ConnectionState.Open) icn.Close();
        }
        /// <summary>
        /// readTxt for User.txt
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        public int searchUser(string Userid)
        {
            StreamReader str = new StreamReader("User.txt");
            string ReadAll = "";
            ReadAll = str.ReadToEnd();
            
            str.Close();
            if (ReadAll.IndexOf(Userid)!=-1)
                return 1;//帳號已經存在
            else
                return 0;
        }
        /// <summary>
        /// writeTExt for User.txt
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="pw"></param>
        public void addUser(string userid,string pw)
        {
            StreamWriter sw = File.AppendText("User.txt");
            string WriteWord = "id:" + userid + ";userpw:"+pw+";userName;";
            sw.WriteLine(WriteWord);
            sw.Flush();
            sw.Close();
        }

        public void readTxt(string file)
        {

        }
        public void addRule(string fileName,string gametype,string rule,string user, string startPeriod,string endPeriod)
        {
            StreamWriter sw = File.AppendText(fileName);
            string WriteWord = "user:"+user+";start:"+startPeriod+";end:"+endPeriod+";gametype:"+gametype+";rule:"+rule+";";
            sw.WriteLine(WriteWord);
            sw.Flush();
            sw.Close();
        }
    }
}