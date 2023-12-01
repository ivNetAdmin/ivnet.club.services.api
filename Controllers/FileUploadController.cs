using ivnet.club.services.api.Models;
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ivnet.club.services.api.Controllers
{
    public class FileUploadController : ApiController
    {
        public FileUploadController()
        {

        }

        [Route("fileupload/{content}")]
        [HttpPost]
        public IHttpActionResult Post(string content)
        {
            try
            {
                var file = HttpContext.Current.Request.Files.Count > 0 ? HttpContext.Current.Request.Files[0] : null;
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);

                    var path = Path.Combine(
                        HttpContext.Current.Server.MapPath($"~/uploads/{content}"),
                        "fixtures.csv"
                    );
                    file.SaveAs(path);

                    path = Path.Combine(
                        HttpContext.Current.Server.MapPath($"~/uploads/{content}/archive"),
                        $"{fileName}_{DateTime.Now:yyyy-MM-dd_HH-mm-ss-fff}"
                    );

                    file.SaveAs(path);
                }
                return Ok($"/uploads/{file.FileName}");
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}