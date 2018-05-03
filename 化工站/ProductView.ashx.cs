using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 化工站
{
    /// <summary>
    /// ProductView 的摘要说明
    /// </summary>
    public class ProductView : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            long id = Convert.ToInt32(context.Request["Id"]);
           
            DataTable data = SqlHelper.ExecuteDataTable("select * from T_Products where Id=@Id", new SqlParameter("@Id", id));
            if (data.Rows.Count < 1)
            {
                context.Response.Write("Not Found!");
            }
            else if (data.Rows.Count > 1)
            {
                context.Response.Write("Find more than one");
            }
            else
            {
                var dt=new {Products=data.Rows,Settings = CommonHelper.GetSettings() };
                string html = CommonHelper.RenderHtml("Front/ProductView.html", dt);
                context.Response.Write(html);
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