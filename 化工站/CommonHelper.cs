
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace 化工站
{

    //NvelocityEngine模板
    public class CommonHelper
    {
            public static string RenderHtml(string templateName, object data)
            {
                //初始化模板引擎
                VelocityEngine vltEngine = new VelocityEngine();
                vltEngine.SetProperty(RuntimeConstants.RESOURCE_LOADER, "file");
                vltEngine.SetProperty(RuntimeConstants.FILE_RESOURCE_LOADER_PATH, System.Web.Hosting.HostingEnvironment.MapPath("~/templates"));
                vltEngine.Init();
                // 设置变量
                VelocityContext vltContext = new VelocityContext();
                vltContext.Put("Model", data);

                // 获取模板文件
                Template vltTemplate = vltEngine.GetTemplate(templateName);
                // 输出
                StringWriter vltWriter = new StringWriter();
                vltTemplate.Merge(vltContext, vltWriter);
                string html = vltWriter.GetStringBuilder().ToString();
                return html;
        }
        public static object GetSettings()
        {
            string siteName = CommonHelper.ReadSetting("SiteName");
            string siteURL = CommonHelper.ReadSetting("SiteURL");
            string address = CommonHelper.ReadSetting("Address");
            string postCode = CommonHelper.ReadSetting("PostCode");
            string contactPerson = CommonHelper.ReadSetting("ContactPerson");
            string telPhone = CommonHelper.ReadSetting("TelPhone");
            string fax = CommonHelper.ReadSetting("Fax");
            string mobile = CommonHelper.ReadSetting("Mobile");
            string email = CommonHelper.ReadSetting("Email");

            var data = new { SiteName = siteName, SiteURL = siteURL, Address = address, PostCode = postCode, ContactPerson = contactPerson, TelPhone = telPhone, Fax = fax, Mobile = mobile, Email = email };
            return data;
        }

        public static string ReadSetting(string name)
        {
            DataTable dt = SqlHelper.ExecuteDataTable("select value from T_Settings where Name=@Name", new SqlParameter("@Name", name));
            if (dt.Rows.Count <= 0)
            {
                throw new Exception("找不到Name=" + name + "的配置项");
            }
            else if (dt.Rows.Count > 1)
            {
                throw new Exception("找到多条Name=" + name + "的配置项");
            }
            return (string)dt.Rows[0]["Value"];
        }

        public static void WriteSetting(string name, string value)
        {
            SqlHelper.ExecuteNonQuery("Update T_Settings set Value=@Value where Name=@Name", new SqlParameter("@Value", value), new SqlParameter("@Name", name));
        }
    }
   
}