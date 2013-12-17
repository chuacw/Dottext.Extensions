#region Disclaimer/Info
///////////////////////////////////////////////////////////////////////////////////////////////////
//
// .Text is an open source weblog system started by Scott Watermasysk.
// This is an extension for .Text to support
// daily Atom/Rss and monthly Atom/Rss feeds
// Blog: http://chuacw.ath.cx/chuacw
// RSS: http://chuacw.ath.cx/chuacw/rss.aspx
// Email: chuacw@rightsecurity.biz
// Author: Chua Chee Wee, Singapore
//
///////////////////////////////////////////////////////////////////////////////////////////////////
#endregion

using System;
using System.Web;

namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for Class.
	/// </summary>
	public class Redirector: IHttpModule
	{
           public void Init(HttpApplication context)
           {
              context.BeginRequest += new EventHandler(this.RedirectRequest);
           }

           public void Dispose()
           {
           }

           public void RedirectRequest(object Sender, EventArgs e)
           {
              HttpApplication app = Sender as HttpApplication;
              string newURL = app.Request.QueryString["r"];
              if ((newURL!=null) && (newURL!=string.Empty))
                app.Response.Redirect(newURL);
           }
	}
}
