using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace 化工站
{
    /// <summary>
    /// Index 的摘要说明
    /// </summary>
    public class Index : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Products where IsRecommend=1");
            var data = new { Categories = SqlHelper.GetCategory().Rows, Settings = CommonHelper.GetSettings(), RecommendProducts = dt.Rows };
            var html= CommonHelper.RenderHtml("Front/Index.html", data);
            context.Response.Write(html);

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