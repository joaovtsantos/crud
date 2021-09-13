using ApiRest.Model;
using ApiRest.Model.UserRecovery;
using Core.Infrastructure.Exceptions;
using Core.User.UserRecovey.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRecoveryController : ControllerBase
    {
        private readonly INewPassowordUserRecovery _newPassowordUserRecovery;

        public UserRecoveryController(INewPassowordUserRecovery newPassowordUserRecovery)
        {
            _newPassowordUserRecovery = newPassowordUserRecovery;
        }

        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] UserRecoveryPasswordRequest user)
        {
            try
            {
                var result = await _newPassowordUserRecovery.Execute(user);

                return Ok(Result.Create(result, HttpStatusCode.OK, " Operação executado com sucesso!"));
            }
            catch (ApiDomainException domainException)
            {
                return UnprocessableEntity(Result.Create(domainException.Errors, HttpStatusCode.UnprocessableEntity, "Erro ao executar a operação"));
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
