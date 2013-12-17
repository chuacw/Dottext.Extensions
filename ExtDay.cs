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
using Dottext.Framework.Components;


namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for ExtArchiveDay.
	/// </summary>
	public class ExtDay: Web.UI.Controls.Day
	{
		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			
			if (this.DayList.DataSource!=null)
			{
				string SyndicatedFormats = "";
				string AtomURL, RssURL;
				DateTime time1 = ((EntryDay)this.DayList.DataSource).BlogDay;
				if ((SupportedFormats.Syndication & SupportedFormats.DateSyndication.DayAtom)!=0)
				{
					AtomURL = string.Format("<a href=\"{0}\">Atom</a>",
						base.CurrentBlog.FullyQualifiedUrl + string.Format("archive/{0}.aspx/atom", time1.ToString("yyyy/MM/dd")));
					SyndicatedFormats = AtomURL;
				}
				if ((SupportedFormats.Syndication & SupportedFormats.DateSyndication.DayRss)!=0)
				{
					RssURL = string.Format("<a href=\"{0}\">RSS</a>",
						base.CurrentBlog.FullyQualifiedUrl + string.Format("archive/{0}.aspx/rss", time1.ToString("yyyy/MM/dd")));
					if (SyndicatedFormats != string.Empty)
						SyndicatedFormats = SyndicatedFormats + " ";
					SyndicatedFormats = SyndicatedFormats + RssURL;
				}
				if (SyndicatedFormats!=string.Empty)
					SyndicatedFormats = string.Format("</a>({0})<a href=\"\">", SyndicatedFormats);
				this.DateTitle.Text = this.DateTitle.Text + SyndicatedFormats;
			}

		}
	}
}
