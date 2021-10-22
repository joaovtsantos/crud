using ApiRest.Model;
using ApiRest.Model.Files;
using Core.Files.Interfaces;
using Core.Infrastructure.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UploadController : ControllerBase
    {
        const String folderName = "files";
        readonly String folderPath = Path.Combine(Directory.GetCurrentDirectory(), folderName);
        private readonly IFileUpload _fileUpload;
        private readonly IGetFileByName _getFileByName;
        
        public UploadController(IFileUpload fileUpload, IGetFileByName getFileByName)
        {
            _fileUpload = fileUpload;
            _getFileByName = getFileByName;

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
        }

        [HttpPost]
        [Route("/{userId}")]
        public async Task<IActionResult> UploadDocument(Guid userId,
        [FromForm(Name = "myFile")] IFormFile myFile)
        {
            try
            {
                using (var fileContentStream = new MemoryStream())
                {
                    await myFile.CopyToAsync(fileContentStream);
                    await System.IO.File.WriteAllBytesAsync(Path.Combine(folderPath, myFile.FileName), fileContentStream.ToArray());
                    var files = await _fileUpload.Execute(userId, myFile.FileName, myFile.ContentDisposition);
                    var result = CreatedAtRoute(routeName: "myFile", routeValues: new { filename = myFile.FileName }, value: null);

                    return Ok(Result.Create(files, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
                }
            }

            catch (ApiDomainException domainException)
            {
                return BadRequest(Result.Create(domainException.Errors, HttpStatusCode.BadRequest, "Erro ao executar a operação"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }

        }

        [HttpGet("{filename}", Name = "myFile")]
        public async Task<IActionResult> Get(Guid userId, [FromRoute] String filename)
        {
            try
            {
                var result = await _getFileByName.Execute(userId, filename);
                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
            }

            catch (ApiDomainException domainException)
            {
                return NotFound(Result.Create(domainException.ErrorMessage, HttpStatusCode.NotFound, "Erro ao executar a operação"));
            }
            catch (ArgumentException e)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, e.Message);
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}
