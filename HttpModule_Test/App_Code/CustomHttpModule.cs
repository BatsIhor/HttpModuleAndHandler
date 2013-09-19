using System;
using System.Web;

namespace HttpModule_Test
{
    public class CustomHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.AuthenticateRequest += ContextOnBeginRequest;
            context.AuthorizeRequest += ContextOnBeginRequest;
            context.BeginRequest += ContextOnBeginRequest;
            context.EndRequest += ContextOnEndRequest;
        }

        private void ContextOnEndRequest(object sender, EventArgs eventArgs)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string path = context.Request.FilePath;
            string extension = VirtualPathUtility.GetExtension(path);
            if (extension == ".aspx")
            {
                context.Response.Write("<h1><font color=red>Custom http module begin request.</font></h1>");
            }
        }

        private void ContextOnBeginRequest(object sender, EventArgs eventArgs)
        {
            HttpApplication application = (HttpApplication)sender;
            HttpContext context = application.Context;
            string path = context.Request.FilePath;
            string extension = VirtualPathUtility.GetExtension(path);
            if (extension == ".aspx")
            {
                context.Response.Write("<h1><font color=red>Custom http module begin request.</font></h1>");
            }
        }

        public void Dispose()
        {
        }
    }
}