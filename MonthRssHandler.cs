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

// web.config must be configured thus:
//      <HttpHandler pattern="^(?:/(\w|\s|\.)+/archive/\d{4}/\d{1,2}.aspx/rss)$" type="Dottext.Extensions.MonthRssHandler, Dottext.Extensions" handlerType="Direct"/>

using System;
using System.Web;
using Dottext.Common.Data;
using Dottext.Framework.Components;
using Dottext.Extensions;

namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for MonthRssHandler.
	/// </summary>
	public class MonthRssHandler: DateRssHandler
	{
                public MonthRssHandler()
                {
                  SupportedFormats.Syndication = SupportedFormats.Syndication | SupportedFormats.DateSyndication.MonthRss;
                }

                protected override EntryCollection GetDate(DateTime dt, CacheTime ct, HttpContext hc)
                {
                   return Cacher.GetMonth(dt, ct, hc);
                }
	}
}
