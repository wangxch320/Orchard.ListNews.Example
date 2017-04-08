using System;
using System.IO;

namespace WebApplication2
{
    public partial class UploadFile : System.Web.UI.Page
    {
        Random rnd = new Random();                            //产生随机数  
        private string _directory = @"/File";      //目录 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Files.Count > 0 && Request.Files[0].ContentLength != 0)
            {
                //判断文件大小  
                int length = Request.Files[0].ContentLength;
                if (length > 2097152)
                {
                    Response.Write("文件大于2M，不能上传");
                    return;
                }

                string type = Request.Files[0].ContentType;
                string fileExt = Path.GetExtension(Request.Files[0].FileName).ToLower();
                //只能上传图片，过滤不可上传的文件类型  
                string fileFilt = ".gif|.jpg|.php|.jsp|.jpeg|.png|......";
                if (fileFilt.IndexOf(fileExt) <= -1)
                {
                    Response.Write("对不起！请上传图片,而不是" + fileExt.ToString());
                    return;
                }
                else
                {
                    string fileName = Server.MapPath(_directory) + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + rnd.Next(10, 99).ToString() + fileExt;
                    Request.Files[0].SaveAs(fileName);
                    Response.Write("上传成功！");

                }
            }
        }
    }
}