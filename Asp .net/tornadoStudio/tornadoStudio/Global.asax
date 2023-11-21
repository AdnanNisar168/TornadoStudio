<%@ Application Codebehind="Global.asax.cs" Inherits="tornadoStudio.MvcApplication" Language="C#" %>

protected void Application_BeginRequest(object sender, EventArgs e)
{
    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "http://localhost:4200");
    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Headers", "Content-Type, Accept");
    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Methods", "POST, GET, OPTIONS");
    HttpContext.Current.Response.AddHeader("Access-Control-Allow-Credentials", "true");

    if (HttpContext.Current.Request.HttpMethod == "OPTIONS")
    {
        HttpContext.Current.Response.StatusCode = 200;
        HttpContext.Current.Response.End();
    }
}

