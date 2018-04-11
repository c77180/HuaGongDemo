
using NVelocity;
using NVelocity.App;
using NVelocity.Runtime;
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
    }
}