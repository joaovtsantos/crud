﻿using ApiRest.Model;
using ApiRest.Model.User;
using Core.Infrastructure.Exceptions;
using Core.User.Interfaces;
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
    public class UserController : ControllerBase
    {
        private readonly ICreateUser _createUser;
        private readonly IDeleteUser _deleteUser;
        private readonly IGetAllUser _getAllUser;
        private readonly IGetUserByEmail _getUserByEmail;
        private readonly IGetUserById _getUserById;
        private readonly IGetUserByName _getUserByName;
        private readonly IGetUserBySocialNumber _getUserBySocialNumber;
        private readonly IUpdateUser _updateUser;

        public UserController(ICreateUser createUser,
                              IDeleteUser deleteUser, 
                              IGetAllUser getAllUser,
                              IGetUserByEmail getUserByEmail,
                              IGetUserById getUserById, 
                              IGetUserByName getUserByName, 
                              IGetUserBySocialNumber getUserBySocialNumber, 
                              IUpdateUser updateUser)
        {
            _createUser = createUser;
            _deleteUser = deleteUser;
            _getAllUser = getAllUser;
            _getUserByEmail = getUserByEmail;
            _getUserById = getUserById;
            _getUserByName = getUserByName;
            _getUserBySocialNumber = getUserBySocialNumber;
            _updateUser = updateUser;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserRequest createUserRequest)
        {
            try
            {
                var result = await _createUser.Execute(createUserRequest);

                return Ok(Result.Create(result, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
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

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UpdateUserRequest updateUserRequest)
        {
            try
            {
                var result = await _updateUser.Execute(updateUserRequest);

                return Ok(Result.Create(result, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
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

        [HttpDelete]
        public IActionResult Delete(Guid userId)
        {
            try
            {
                _deleteUser.Execute(userId);

                return Ok(Result.Create(userId, System.Net.HttpStatusCode.OK, "Operação executada com sucesso!"));
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

        [HttpPost("GetAll")]
        public async Task<IActionResult> Get([FromBody] PaginationRequest paginationRequest)
        {
            try
            {
                var model = await _getAllUser.Execute(paginationRequest.PageSize, paginationRequest.PageIndex, paginationRequest.Sort, paginationRequest.Direction);

                return Ok(Result.Create(model, HttpStatusCode.OK, "Operação executada com sucesso!"));
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

        [HttpGet]
        [Route("filterByUserId/{userId}")]
        public async Task<IActionResult> GetId(Guid userId)
        {
            try
            {
                var result = await _getUserById.Execute(userId);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
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

        [HttpGet]
        [Route("filterByName/{userByName}")]
        public async Task<IActionResult> GetName(string userByName)
        {
            try
            {
                var result = await _getUserByName.Execute(userByName);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
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

        [HttpGet]
        [Route("filterBySocialNumber/{userBySocialNumber}")]
        public async Task<IActionResult> GetSocialNumber(string userBySocialNumber)
        {
            try
            {
                var result = await _getUserBySocialNumber.Execute(userBySocialNumber);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
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

        [HttpGet]
        [Route("filterByEmail/{userByEmail}")]
        public async Task<IActionResult> GetEmail(string userByEmail)
        {
            try
            {
                var result = await _getUserByEmail.Execute(userByEmail);

                return Ok(Result.Create(result, HttpStatusCode.OK, "Operação executada com sucesso!"));
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