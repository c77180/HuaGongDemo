using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 化工站.Admin
{
    /// <summary>
    /// ProductList 的摘要说明
    /// </summary>
    public class ProductList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            int pageNum = 1;
            if (context.Request["PageNum"] != null)
            {
                pageNum = Convert.ToInt16(context.Request["PageNum"]);
            }
            int totalCount = (int)SqlHelper.ExecuteScalar("select count(*) from T_Products");
            int pageCount = (int)Math.Ceiling(totalCount / 10.0);
            object[] pageData = new object[pageCount];
            for (int i = 0; i < pageData.Length; i++)
            {
                pageData[i] = new {Href="ProductList.ashx?pageNum="+(i+1),Title="第"+(i+1)+"页" };
            }
            //DataTable dt = SqlHelper.ExecuteDataTable("select p.Id as Id,p.Name as Name,c.Name as CategoryName from T_Products p left join T_ProductCategories c on p.CategoryId=c.Id");
            DataTable dt = SqlHelper.ExecuteDataTable(@"select * from 
(select p.Id,p.Name as Name,c.Name as CategoryName,ROW_NUMBER() over(order by p.Id asc) as num from T_Products p left join T_ProductCategories c on p.CategoryId=c.Id) as s 
where s.num between @Start and @End",new SqlParameter("@Start",(pageNum-1)*10+1),new SqlParameter("@End",pageNum*10));

//            select * from 
//(select p.Id,p.Name as Name,c.Name as CategoryName,ROW_NUMBER() over(order by p.Id asc) as num from T_Products p left join T_ProductCategories c on p.CategoryId=c.Id) as s 
//where s.num between 3 and 5;
            var data = new {Title="新增列表", Products = dt.Rows,PageList=pageData };
            string html = CommonHelper.RenderHtml("Admin/ProductList.html", data);
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