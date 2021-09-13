using ApiRest.Model;
using ApiRest.Model.User;
using Core.Infrastructure.Exceptions;
using Core.Infrastructure.Token;
using Core.User.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IOptions<AuthSettings> _authSettings;
        private readonly IJwtGenerator _jwtGenerator;
        private readonly IGetUserByLogin _getUserByLogin;

        public AuthController(IOptions<AuthSettings> authSettings,
                              IJwtGenerator jwtGenerator,
                              IGetUserByLogin getUserByLogin)
        {
            _authSettings = authSettings;
            _jwtGenerator = jwtGenerator;
            _getUserByLogin = getUserByLogin;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserRequest data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (data == null)
                {
                    return BadRequest();
                }

                LoginResult userLogin = await _getUserByLogin.Execute(data);

                return Ok(Result.Create(userLogin, HttpStatusCode.OK, "Operação executada com sucesso!"));

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
