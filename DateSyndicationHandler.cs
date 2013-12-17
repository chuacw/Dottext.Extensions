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
using Dottext.Common.Data;
using Dottext.Common.Syndication;
using Dottext.Framework;
using Dottext.Framework.Components;
using Dottext.Framework.Syndication;
using Dottext.Framework.Util;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for Class2.
	/// </summary>
	public abstract class DateSyndicationHandler: Dottext.Common.Syndication.EntryCollectionHandler
	{
        	
				public DateSyndicationHandler() {}
				protected abstract BaseSyndicationWriter GetWriter(EntryCollection ec);

				protected override CachedFeed BuildFeed()
				{
							CachedFeed cf = null;
							EntryCollection ec = GetFeedEntries();
							if ((ec != null) && (ec.Count > 0))
							{
								cf = new CachedFeed();
								BaseSyndicationWriter writer = GetWriter(ec);
								if (writer!=null)
								cf.Xml = writer.GetXml;
							}
							return cf;
				}

                protected static string CleanStartDateString(string uri, string archiveText)
                {
                  return uri.Remove(0, (uri.LastIndexOf(archiveText) + archiveText.Length) + 1);
                }

                protected static string CleanEndDateString(string uri, string suffix)
                {
                  string ReplacementStr = string.Format(@"(/|\.aspx\/{0})$", suffix);
                  uri = Regex.Replace(uri, ReplacementStr, string.Empty, RegexOptions.IgnoreCase);
				  ReplacementStr = string.Format(@"(/|\.aspx)$");
				  return Regex.Replace(uri, ReplacementStr, string.Empty, RegexOptions.IgnoreCase);
                }

                // protected abstract string GetSyndicationType();
				protected static string SyndicationType;

                public static DateTime GetDateFromRequest(string uri, string archiveText)
                {
                  uri = uri.ToLower();
                  uri = CleanStartDateString(uri, archiveText);
                  uri = CleanEndDateString(uri, SyndicationType);
                  return DateTime.ParseExact(uri, new string[6]{"yyyy/MM/d", "yyyy/MM/dd", "yyyy/M/dd", "yyyy/M/d", "yyyy/MM", "yyyy/M"},
                      new CultureInfo("en-US"), DateTimeStyles.None);
                }

                protected abstract EntryCollection GetDate(DateTime dt, CacheTime ct, HttpContext hc);

	     		protected override EntryCollection GetFeedEntries()
                {
                     DateTime Date = GetDateFromRequest(HttpContext.Current.Request.Path, "archive");
                     return GetDate(Date, CacheTime.Short, HttpContext.Current);
                }

				
	}
}
