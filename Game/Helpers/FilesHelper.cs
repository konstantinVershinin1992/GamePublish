using System;
using System.Collections.Generic;
//using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace TestProData.Helpers
{
    public static class FilesHelper
    {//<img src="@Url.Content(item.Link)" style="width: 150px; height: 120px;" />

        public static String SaveFile(this HttpPostedFileBase file, String directory, HttpServerUtilityBase server)
        {
            if (file.ContentLength > 0)
            {
                Regex regex = new Regex(@"[\#\s+\$\!\@\%\&\\\/]+");

                var fileName = Path.GetFileName(file.FileName) ?? "file";
                fileName = regex.Replace(fileName, "_");

                var path = Path.Combine(server.MapPath(directory), fileName);

                if (File.Exists(path))
                {
                    var suffix = Guid.NewGuid().ToString("N").Substring(0, 10);
                    var match = Regex.Match(fileName, "^(?<Name>.+)[.](?<Extension>.*)$");
                    fileName = "{0}{1}.{2}".F(match.Groups["Name"].Value, suffix, match.Groups["Extension"].Value);
                    fileName = regex.Replace(fileName, "_");
                    path = Path.Combine(server.MapPath(directory), fileName);
                }
                file.SaveAs(path);

                var url = Path.Combine(directory, fileName);
                return url;
            }
            return "";
        }

 
        private static bool ThumbnailCallback() { return false; }
    }
}
