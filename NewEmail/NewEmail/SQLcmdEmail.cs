using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using NewEmail.Models;
namespace NewEmail
{
    public class SQLcmdEmail
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param 查询条件="name"></param>
        /// <returns></returns>
        public static List<Emails> SQLcmdData(string name,int?id)
        {
            string sql = "server=.;database=EmailData;Trusted_Connection=SSPI";
            string querystring = "select * from tb_Email where EDelete=1";
            if (name!=null)
            {
                 querystring =string.Format("select * from tb_Email where EDelete=1 and EmailName like '%{0}%'", name);
            }
            else if (id!=null)
            {
                querystring = string.Format("select * from tb_Email where EID={0}", id);
            }
            List<Emails> mList = new List<Emails>();
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(querystring, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Emails u = new Emails();
                        u.EID = (int)reader[0];
                        u.EmailName = reader[1].ToString();
                        u.CreateTime = reader[2].ToString();
                        u.UpdateTime = reader[3].ToString();
                        u.EDelete = (int)reader[4];
                        mList.Add(u);
                    }
                }
            }
            return mList;
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param 邮箱="name"></param>
        /// <param 创建时间="createtime"></param>
        /// <param 是否删除="edelete"></param>
        /// <param 修改时间="UpdateTime"></param>
        /// <returns></returns>
        public static int SQLinsertData( string name,string createtime,int edelete,string UpdateTime)
        {
            string sql = "server=.;database=EmailData;Trusted_Connection=SSPI";
            string querystring = string.Format("INSERT INTO tb_Email(EmailName,CreateTime,UpdateTime,EDelete) VALUES('{0}','{1}','{2}','{3}')", name,createtime, UpdateTime, edelete);
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(querystring, conn);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    return a;
                }
                else { return 0; };
            }
        }
        public static int SQLUpdateData(string name,int id,string updatetime)
        {
            string sql = "server=.;database=EmailData;Trusted_Connection=SSPI";
            string querystring = string.Format("update tb_Email set EmailName='{0}',UpdateTime='{1}' where EID={2}",  name,updatetime,id);
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(querystring, conn);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    return a;
                }
                else { return 0; };
            }
        }
        public static int SQLDeleteData(int Id)
        {
            string sql = "server=.;database=EmailData;Trusted_Connection=SSPI";
            string querystring = string.Format("update tb_Email set EDelete=0 where EID={0}", Id);
            using (SqlConnection conn = new SqlConnection(sql))
            {
                SqlCommand cmd = new SqlCommand(querystring, conn);
                conn.Open();
                int a = cmd.ExecuteNonQuery();
                if (a > 0)
                {
                    return a;
                }
                else { return 0; };
            }
        }
    }
}
