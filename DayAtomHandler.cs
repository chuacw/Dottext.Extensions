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
//      <HttpHandler pattern="^(?:/(\w|\s|\.)+/archive/\d{4}/\d{1,2}/\d{1,2}\.aspx/atom)$" type="Dottext.Extensions.DayAtomHandler, Dottext.Extensions" handlerType="Direct"/>

using System;
using System.Web;
using Dottext.Common.Data;
using Dottext.Framework.Components;

namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for DayAtomHandler.
	/// </summary>
	public class DayAtomHandler: DateAtomHandler
	{
                public DayAtomHandler()
                {
                  SupportedFormats.Syndication = SupportedFormats.Syndication | SupportedFormats.DateSyndication.DayAtom;
                }
                protected override EntryCollection GetDate(DateTime dt, CacheTime ct, HttpContext hc)
                {
                   return Cacher.GetDay(dt, ct, hc);
                }
	}
}
