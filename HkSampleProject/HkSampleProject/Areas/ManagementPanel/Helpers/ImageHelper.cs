using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace HkSampleProject.Areas.ManagementPanel.Helpers
{
    public class ImageHelper
    {
        public const string ImageMapPath = "/Content/imgUpload";
        public static string ServerImgMapPath { get => HttpContext.Current.Server.MapPath(ImageMapPath); }
        public static string SaveImage(HttpPostedFileBase file)
        {
            string date = DateTime.Now.ToString().Replace('/', '-').Replace('.', '-').Replace(@"\", "-").Replace(':', '-').Replace(' ', '-');
            string ImagePath = Path.GetFileName(file.ContentType.Split('/')[0] + "-" + date + file.FileName.ToLower().Trim());
            var uploadPath = Path.Combine(ServerImgMapPath, ImagePath);
            file.SaveAs(uploadPath);
            return ImageMapPath + "/" + ImagePath;
        }
        public static bool DeleteImage(string path)
        {
            try
            {
                if (path != null || path != "")
                {
                    FileInfo fileInfo = new FileInfo(HttpContext.Current.Server.MapPath(path));
                    if (fileInfo.Exists)
                    {
                        fileInfo.Delete();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}