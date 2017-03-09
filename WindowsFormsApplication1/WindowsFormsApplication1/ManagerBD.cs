using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace WindowsFormsApplication1
{
    class ManagerBD
    {
        SQLiteConnection sql;
        public void Connection()
        {
            try
            {
                sql = new SQLiteConnection(@"Data Source= mydb.sqlite;Version=3");
            }catch(Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Управляющий запрос
        /// </summary>
        public void controlquery(string сq)
        {
            try
            {
                SQLiteCommand sc = new SQLiteCommand(сq, sql);
                sql.Open();
                sc.ExecuteNonQuery();
                sql.Close();
            }
            catch (Exception ex)
            {
                sql.Close();
                throw ex; 
            }


        }
        /// <summary>
        /// запрос выборка
        /// </summary>
        /// <param name="sq"></param>
        public DataTable selectionquery(string sq)
        {
            DataTable dt;
            try
            {
                //SQLiteConnection sqlcon = new SQLiteConnection(@"Data Source= mydb.sqlite;Version=3");
                sql.Open();
                SQLiteCommand sc = new SQLiteCommand(sql);
                sc.CommandText = @sq;

                SQLiteDataReader sdr = sc.ExecuteReader();
                 dt = new DataTable();
                dt.Load(sdr);
                //dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

    }


}


