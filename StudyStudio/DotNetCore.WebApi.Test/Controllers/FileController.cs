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
        public IActionResult UploadFiles([FromServices] IWebHostEnvironment environment, [FromForm] File request)
        {
            if (string.IsNullOrWhiteSpace(environment.WebRootPath))
                environment.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");

            string uploadPath = Path.Combine(environment.WebRootPath, "upload-file");

            if (!Directory.Exists(uploadPath))
                Directory.CreateDirectory(uploadPath);

            string uploadFileName = $"{request.Name}{Path.GetExtension(request.FormFile.FileName)}";
            string uploadFilePath = Path.Combine(uploadPath, uploadFileName);

            if (System.IO.File.Exists(uploadFilePath))
            {
                System.IO.File.Delete(uploadFilePath);
            }

            using FileStream fileStream = System.IO.File.Create(uploadFilePath);
            request.FormFile.CopyTo(fileStream);
            fileStream.Flush();

            return Ok();
        }
    }

    public class File
    {
        public string Name { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
