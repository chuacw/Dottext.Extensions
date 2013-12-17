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

namespace Dottext.Extensions
{
	/// <summary>
	/// Summary description for SupportedFormats.
	/// </summary>
	public class SupportedFormats
	{
		public enum DateSyndication 
		{
			DayRss,
			MonthRss,
			DayAtom,
			MonthAtom
		}
		
		public static DateSyndication Syndication = DateSyndication.DayRss | 
			DateSyndication.MonthRss | DateSyndication.DayAtom | 
			DateSyndication.MonthAtom;
	}
}
