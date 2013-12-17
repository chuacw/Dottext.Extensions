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
using Dottext.Common.Syndication;
using Dottext.Framework.Components;
using Dottext.Framework.Syndication;

namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for DateAtomHandler.
	/// </summary>
	public abstract class DateAtomHandler: DateSyndicationHandler
	{
                protected override BaseSyndicationWriter GetWriter(EntryCollection ec)
                {
                  return new AtomWriter(ec);
                }
        //        protected override string GetSyndicationType() {
        //          return "atom";
        //        }
		static DateAtomHandler() 
		{
			SyndicationType = "atom";
		}
	}
}
