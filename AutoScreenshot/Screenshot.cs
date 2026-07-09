using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace AutoScreenshot
{
    public class Screenshot
    {
        /// <param name="fileName">A file name to append to the current date time as the file name.</param>
        /// <param name="folderPath">The folder to save the screenshot to within the configured Screenshot Folder.</param>
        public static void TakeScreenshot(string fileName = "", string folderPath = "")
        {
            if (Plugin.Instance.ConfigEnabled.Value)
            {
                var now = DateTime.Now;
                string finalFileName = now.ToString("yyyy-MM-dd HH-mm-ss");

                if (fileName != "")
                {
                    finalFileName += "_" + fileName;
                }
                finalFileName += ".png";

                string finalFolderPath = Plugin.Instance.ConfigScreenshotFolder.Value;

                if (folderPath != "")
                {
                    finalFolderPath = Path.Combine(finalFolderPath, folderPath);
                }

                if (!Directory.Exists(finalFolderPath))
                {
                    Directory.CreateDirectory(finalFolderPath);
                }
                ScreenCapture.CaptureScreenshot(Path.GetFullPath(Path.Combine(finalFolderPath, finalFileName)));
            }
        }
    }
}
