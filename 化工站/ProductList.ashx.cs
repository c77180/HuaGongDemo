using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace 化工站
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
            if (context.Request["pageNum"] != null)
            {
                pageNum=Convert.ToInt32(context.Request["pageNum"]);

            }
            bool hasCategoryId = !string.IsNullOrEmpty(context.Request["CategoryId"]);
            DataTable products;
            int pre = pageNum - 1;
            int totalCount = 0;
            if (hasCategoryId)
            {
                int CategoryId = Convert.ToInt32(context.Request["CategoryId"]);
                products = SqlHelper.ExecuteDataTable("select * from (select *,row_number() over(order by p.Id asc) as  num  from T_Products p where p.CategoryId=@CategoryId ) s where s.num between @Start and @End",
                new SqlParameter("@CategoryId", CategoryId), new SqlParameter("@Start", (pageNum - 1) * 9 + 1), new SqlParameter("@End", pageNum * 9));
               totalCount = (int)SqlHelper.ExecuteScalar("select count(*) from T_Products where T_Products.CategoryId=@CategoryId",new SqlParameter("@CategoryId",CategoryId));
               
            }
            else
            {
                products = SqlHelper.ExecuteDataTable("select * from (select *,row_number() over(order by p.Id asc) as  num  from T_Products p ) s where s.num between @Start and @End",
                           new SqlParameter("@Start", (pageNum - 1) * 9 + 1), new SqlParameter("@End", pageNum * 9));
                totalCount = (int)SqlHelper.ExecuteScalar("select count(*) from T_Products");
               
            }
            int pageCount = (int)Math.Ceiling(totalCount / 9.0);
            object[] pageData=new object[pageCount];
           for (int i = 0; i < pageData.Length; i++)
			{
			    pageData[i]=new {Href="ProductList.ashx?PageNum="+(i+1),Title=(i+1)};
			}

           var data = new {Categories= SqlHelper.GetCategory().Rows, Products = products.Rows, PageData = pageData, totalCount = totalCount,Pre= pre, PageNum = pageNum, PageCount=pageCount};
            string html = CommonHelper.RenderHtml("Front/ProductList.html", data);
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