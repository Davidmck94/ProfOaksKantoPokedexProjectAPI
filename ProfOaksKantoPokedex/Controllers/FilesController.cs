using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace ProfOaksKantoPokedex.Controllers
{
    [Route("api/files")]
    [Authorize]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly FileExtensionContentTypeProvider _fileExtensionContentTypeProvider;

        public FilesController(FileExtensionContentTypeProvider fileExtensionContentTypeProvider)
        {
            _fileExtensionContentTypeProvider = fileExtensionContentTypeProvider
            ?? throw new System.ArgumentNullException(nameof(fileExtensionContentTypeProvider));
        }

        /// <summary>
        /// Get a file
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns>An ActionResult as a PDF file for download</returns>
        [HttpGet("{fileId}")]
        public ActionResult GetFile(string fileId)
        {
            // Look up the file with the fileid
            // For demo purposes 
            var pathToFile = "An Overview of the Kanto Region.pdf";

            // Check if the file exists
            if (!System.IO.File.Exists(pathToFile))
            {
                return NotFound();
            }

            if (!_fileExtensionContentTypeProvider.TryGetContentType(
                pathToFile, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = System.IO.File.ReadAllBytes(pathToFile);
            return File(bytes, contentType, Path.GetFileName(pathToFile));
        }
    }
}
