//Write a program that replaces in a HTML document given as string all the tags <a href="…">…</a> with corresponding tags [URL=…]…/URL].

using System;
using System.Collections.Generic;
using System.Text;

class ReplaceTags
{
    static void Main()
    {
        string html = Console.ReadLine();
        string replaced = html.Replace(@"<a href=""", "[URL=");
        replaced = replaced.Replace(@""">", "]");
        replaced = replaced.Replace("</a>", "/URL]");

        Console.WriteLine(replaced);
    }
}