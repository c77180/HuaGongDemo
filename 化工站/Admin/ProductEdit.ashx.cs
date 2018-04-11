using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;

namespace 化工站.Admin
{
    /// <summary>
    /// ProductEdit 的摘要说明
    /// </summary>
    public class ProductEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            bool isPostBack = !string.IsNullOrEmpty(context.Request["isPostBack"]);
             string action = context.Request["Action"];
            if (isPostBack)
            {
                if (action == "AddNew")
                {
                    int Id = Convert.ToInt32(context.Request["Id"]);
                    string name = context.Request["Name"];
                    string msg = context.Request["Msg"];
                    long CategoryId =Convert.ToInt64(context.Request["CategoryId"]);
                    HttpPostedFile ProductImage = context.Request.Files["ProductImage"];
                    string filename=DateTime.Now.ToString("yyyyMMddHHmmssffffff")+Path.GetExtension(ProductImage.FileName);
                    ProductImage.SaveAs(context.Server.MapPath("~/uploadfile/"+filename));
                    SqlHelper.ExecuteNonQuery(@"insert into T_Products(Name,CategoryId,ImagePath,Msg)
values(@name,@CategoryId,@ImagePath,@msg)", new SqlParameter("@name", name), new SqlParameter("@CategoryId", CategoryId), new SqlParameter("@ImagePath", "/uploadfile/" + filename), new SqlParameter("@msg", msg));
                    context.Response.Redirect("ProductList.ashx");
                }
                if (action == "Edit")
                {
                    int Id = Convert.ToInt32(context.Request["Id"]);
                    string name = context.Request["Name"];
                    string msg = context.Request["Msg"];
                    long CategoryId = Convert.ToInt64(context.Request["CategoryId"]);

                    HttpPostedFile ProductImage = context.Request.Files["ProductImage"];
                    if ((ProductImage.FileName)=="")
                    {                      
                        SqlHelper.ExecuteNonQuery(@"update T_Products Set Name=@name,CategoryId=@CategoryId,Msg=@Msg where Id=@Id", new SqlParameter("@Name", name), new SqlParameter("@CategoryId", CategoryId),
                                              new SqlParameter("@Msg", msg), new SqlParameter("@Id", Id));
                    }
                    else
                    {
                        string filename = DateTime.Now.ToString("yyyyMMddHHmmssffffff") + Path.GetExtension(ProductImage.FileName);
                        ProductImage.SaveAs(context.Server.MapPath("~/uploadfile/" + filename));
                        SqlHelper.ExecuteNonQuery(@"update T_Products Set Name=@name,CategoryId=@CategoryId,Msg=@msg,ImagePath=@ImagePath where Id=@Id", new SqlParameter("@Name", name), new SqlParameter("@CategoryId", CategoryId),
                             new SqlParameter("@Msg", msg), new SqlParameter("@ImagePath", "/uploadfile/" + filename), new SqlParameter("@Id", Id));
                    }

                    context.Response.Redirect("ProductList.ashx");


                }
                if (action == "Delete")
                {
                    int id=Convert.ToInt16(context.Request["Id"]);
                    SqlHelper.ExecuteNonQuery("delete T_Products where id=@Id",new SqlParameter("@Id",id));
                    context.Response.Redirect("ProductList.ashx");
                }

            }
            else
            {
                DataTable categories = SqlHelper.ExecuteDataTable("select * from T_ProductCategories");
                if (action=="AddNew")
                {
                    var data = new { Title = "新增产品", Action = action, Product = new { Id = 0, Name = "", CategoryId = 0, Msg = "" }, Categories = categories.Rows };
                    string html=CommonHelper.RenderHtml("Admin/ProductEdit.html",data);
                    context.Response.Write(html);
                }else if(action=="Edit")
	            {
                    long id =Convert.ToInt64(context.Request["Id"]);
                    DataTable products = SqlHelper.ExecuteDataTable("select * from T_Products where Id=@Id", new SqlParameter("@Id", id));
                    if (products.Rows.Count <= 0)
                    {
                        context.Response.Write("没有找到ID="+id+"的产品");
                    }
                    else if (products.Rows.Count > 1)
                    {
                        context.Response.Write("找不到Id=" + id + "的产品");
                    }
                    else
                    {
                        DataRow row = products.Rows[0];
                        var data = new { Title = "编辑产品杀", Action = action, Product = row, Categories = categories.Rows };
                        string html = CommonHelper.RenderHtml("Admin/ProductEdit.html", data);
                        context.Response.Write(html);

                    }
	            }else if(action=="Delete"){
                    int id = Convert.ToInt16(context.Request["Id"]);
                    SqlHelper.ExecuteNonQuery("delete T_Products where id=@Id", new SqlParameter("@Id", id));
                    context.Response.Redirect("ProductList.ashx");
                }
                else
                {
                    context.Response.Write("ActionError"+action);
                }
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