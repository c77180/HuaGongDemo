using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace 化工站
{
    /// <summary>
    /// Setting 的摘要说明
    /// </summary>
    public class Setting : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            
           bool hasSave=!string.IsNullOrEmpty(context.Request["Save"]);
            if (hasSave)
            {
                string siteName = context.Request["SiteName"];
                string siteURL = context.Request["SiteURL"];
                string address = context.Request["Address"];
                string postCode = context.Request["PostCode"];
                string contactPerson = context.Request["ContactPerson"];
                string telPhone = context.Request["TelPhone"];
                string fax = context.Request["Fax"];
                string mobile = context.Request["Mobile"];
                string email = context.Request["Email"];
                CommonHelper.WriteSetting("SiteName", siteName);
                CommonHelper.WriteSetting("SiteURL", siteURL);
                CommonHelper.WriteSetting("Address", address);
                CommonHelper.WriteSetting("PostCode", postCode);
                CommonHelper.WriteSetting("ContactPerson", contactPerson);
                CommonHelper.WriteSetting("TelPhone", telPhone);
                CommonHelper.WriteSetting("Fax", fax);
                CommonHelper.WriteSetting("Mobile", mobile);
                CommonHelper.WriteSetting("Email", email);
                context.Response.Write("保存成功！");
               
            }
            else
            {
                var data = CommonHelper.GetSettings();
                string html = CommonHelper.RenderHtml("Admin/Setting.html", data);
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