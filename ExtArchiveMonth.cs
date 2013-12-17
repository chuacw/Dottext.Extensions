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
using Dottext.Web.UI.Controls;
using Dottext.Web.UI;

namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for ExtArchiveMonth.
	/// </summary>
	public class ExtArchiveMonth: ArchiveMonth
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
            string SyndicatedFormats = "";
			string AtomURL, RssURL;
			DateTime time1 = DateSyndicationHandler.GetDateFromRequest(base.Request.Path, "archive");
			if ((SupportedFormats.Syndication & SupportedFormats.DateSyndication.MonthAtom)!=0)
			{
				AtomURL = string.Format("<a href=\"{0}\">Atom</a>",
					base.CurrentBlog.FullyQualifiedUrl + string.Format("archive/{0}.aspx/atom", time1.ToString("yyyy/MM")));
				SyndicatedFormats = AtomURL;
			}
			if ((SupportedFormats.Syndication & SupportedFormats.DateSyndication.MonthRss)!=0)
			{
				RssURL = string.Format("<a href=\"{0}\">RSS</a>",
					base.CurrentBlog.FullyQualifiedUrl + string.Format("archive/{0}.aspx/rss", time1.ToString("yyyy/MM")));
				if (SyndicatedFormats != string.Empty)
					SyndicatedFormats = SyndicatedFormats + " ";
				SyndicatedFormats = SyndicatedFormats + RssURL;
			}
			if (SyndicatedFormats!=string.Empty)
				SyndicatedFormats = string.Format("({0})", SyndicatedFormats);
			this.Days.EntryListTitle = string.Format("{0}{1} Entries", time1.ToString("MMMM yyyy"), SyndicatedFormats);

		}
	}
}
