program TestWebPath;

{$APPTYPE CONSOLE}

{%DelphiDotNetAssemblyCompiler 'd:\webblog3\dottextweb\bin\Dottext.Common.dll'}
{%DelphiDotNetAssemblyCompiler 'd:\webblog3\dottextweb\bin\Dottext.Framework.dll'}

uses
  SysUtils, Dottext.Framework.Util, System.Text.RegularExpressions;

function CleanStartDate(const uri, archiveText: string): string;
begin
  Result := uri.Remove(0, (uri.LastIndexOf(archiveText) + archiveText.Length) + 1);
end;

function CleanEndDate(const uri: string): string;
begin
  Result := Regex.Replace(uri, '(/|\.aspx\/rss)$', &System.string.Empty, RegexOptions.IgnoreCase);
end;

var
  Path: string;
  dt: DateTime;
begin
  Path := 'http://blogs.msdn.com/oldnewthing/archive/2003/07/30/54600.aspx#FeedBack';
  Path := CleanStartDate(Path, 'archive');
  Path := CleanEndDate(Path);
  WriteLn(Path);
end.
