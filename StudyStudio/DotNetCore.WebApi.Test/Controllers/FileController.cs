using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCore.WebApi.Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost()]
        public IActionResult UploadFiles([FromServices] IWebHostEnvironment environment, [FromForm] UploadFile request)
        {
            if (string.IsNullOrWhiteSpace(environment.WebRootPath))
                environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            string uploadPath = Path.Combine(environment.WebRootPath, "upload-file");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string uploadFileName = $"{request.Info.Name}{Path.GetExtension(request.File.FileName)}";
            string uploadFilePath = Path.Combine(uploadPath, uploadFileName);

            if (System.IO.File.Exists(uploadFilePath))
            {
                System.IO.File.Delete(uploadFilePath);
            }

            using FileStream fileStream = System.IO.File.Create(uploadFilePath);
            request.File.CopyTo(fileStream);
            fileStream.Flush();

            return Ok();
        }
    }

    public class UploadFile
    {
        public FileInfo Info { get; set; }
        public IFormFile File { get; set; }
    }

    public class FileInfo
    {
        public int No { get; set; }
        public string Name { get; set; }
    }
}
