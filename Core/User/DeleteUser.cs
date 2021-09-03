using Core.Infrastructure.Exceptions;
using Core.User.Interfaces;
using DataAcess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.User
{
    public class DeleteUser : IDeleteUser
    {
        IUserRepository _UserRepository;

        public DeleteUser(IUserRepository UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<bool> Execute(Guid UserId)
        {
            var result = await _UserRepository.GetByIdAsync(UserId);

            if (result == null)
            {
                throw new ApiDomainException("Usuário não encontrado.");
            }

            return await _UserRepository.DeleteAsync(result);
        }
    }
}
