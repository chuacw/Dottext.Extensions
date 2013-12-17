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
using Dottext.Framework.Components;
using Dottext.Framework.Syndication;
using Dottext.Common.Syndication;
using Dottext.UpdatedRSSHandler;

namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for DateRssHandler.
	/// </summary>
	public abstract class DateRssHandler: DateSyndicationHandler
	{
        protected override BaseSyndicationWriter GetWriter(EntryCollection ec)
        {
            return new UpdatedRSSHandler.MyRssWriter(ec);
        }
                
		static DateRssHandler() 
		{
			SyndicationType = "rss";
		}
				
	}
}
