// See https://aka.ms/new-console-template for more information
using System.Text.RegularExpressions;

Console.WriteLine("Hello, World!");
var searchString = "obj";
var entries = Directory.GetFileSystemEntries(@"F:\Git", "*", SearchOption.AllDirectories).ToList();
var dirs = entries.Where(str => str.EndsWith(searchString)).ToList();
Console.WriteLine(dirs.Count);
var i = 0;
foreach(var dir in dirs)
{
	Console.WriteLine($"{i++} {dir}");
	var info = new DirectoryInfo(dir);
	var count = Regex.Matches(dir, searchString).Count;
	if (count == 1 && !dir.Contains("DeleteFolders") && info.Exists)
	{
		info.Delete(true);
	}
}