using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace 化工站
{
    /// <summary>
    /// ProductComment 的摘要说明
    /// </summary>
    public class ProductComment : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["Action"];
            if (action=="PostComment")
            {
                long productId = Convert.ToInt64(context.Request["ProductId"]);
                string title = context.Request["Title"];
                string msg = context.Request["Msg"];
                SqlHelper.ExecuteNonQuery("insert into T_ProductComments values(@ProductId,@Title,@Msg,getdate())",
                    new SqlParameter("@ProductId", productId), new SqlParameter("@Title", title),
                    new SqlParameter("@Msg", msg));
                context.Response.Write("Ok");
            }
            else if (action=="Load")
            {
                long productId = Convert.ToInt64(context.Request["ProductId"]);
                DataTable dt = SqlHelper.ExecuteDataTable("select * from T_ProductComments where productId=@Id", new SqlParameter("@Id", productId));
                object[] comments = new object[dt.Rows.Count];
                for (int i = 0; i < comments.Length; i++)
                {
                    DataRow dr = dt.Rows[i];
                    comments[i] = new { Title = dr["Title"], Msg = dr["Msg"], CreateDateTime = dr["CreateDateTime"].ToString() };

                }
                string json = new JavaScriptSerializer().Serialize(comments);
                context.Response.Write(json);
            }
            else
            {
                context.Response.Write("Not Fount");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}