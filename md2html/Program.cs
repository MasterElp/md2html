using System;
using System.IO;
using Aspose.Html.Converters;
using Aspose.Html;

namespace md2html
{
    class Program
    {
        static void Main(string[] args)
        {
            string md_filename = "changelog.md";
            string html_filename = "changelog.html";
            string data_dir = "D:/git/KSE-Firmware-Upgrade/2release/";
            string output_dir = "D:/git/KSE-Firmware-Upgrade/2release/";

            string[] arguments = Environment.GetCommandLineArgs();

            if (arguments.Length > 1)
            {
                data_dir = arguments[1];
            }

            if (arguments.Length > 2)
            {
                output_dir = arguments[2];
            }

            if (arguments.Length > 3)
            {
                md_filename = arguments[3];
            }

            if (arguments.Length > 4)
            {
                html_filename = arguments[4];
            }

            string source_path = Path.Combine(data_dir, md_filename);
            string temp_path = Path.Combine(data_dir, "temp.html");
            string save_path = Path.Combine(output_dir, html_filename);


            // Convert Markdown to HTML document
            Converter.ConvertMarkdown(source_path, temp_path);

            using (HTMLDocument document = new HTMLDocument(temp_path))
            {
                var meta = document.CreateElement("meta");
                meta.SetAttribute("charset", "utf-8");
                document.GetElementsByTagName("head")[0].AppendChild(meta);

                //Console.WriteLine(document.DocumentElement.OuterHTML);

                document.Save(save_path);
            }

            File.Delete(temp_path);
        }

    }

}
