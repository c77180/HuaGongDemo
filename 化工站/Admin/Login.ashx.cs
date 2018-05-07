using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace 化工站.Admin
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler,IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            bool isSubmit = !string.IsNullOrEmpty(context.Request["submit"]);
            if (isSubmit)
            {
                string uid = context.Request["uid"];
                string pwd = context.Request["pwd"];
              int count=(int)SqlHelper.ExecuteScalar("select count(*) from T_SysUsers where name=@uid and password=@pwd",
                   new SqlParameter("@uid", uid), new SqlParameter("@pwd", pwd));
                if (count == 1)
                {
                    context.Session["uid"] = uid;
                    context.Response.Redirect("ProductList.ashx");
                
                }
                else if (count >= 1)
                {
                    context.Response.Write("有重复数据出现");
                }
                else
                {
                    context.Response.Write("用户名或者密码错误");
                }
            }
            else  //展示Login.html
            {
                var html = CommonHelper.RenderHtml("Admin/Login.html", null);
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