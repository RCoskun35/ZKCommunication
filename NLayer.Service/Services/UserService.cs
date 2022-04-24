using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class UserService : Service<User>,IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IUserRepository userRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
    }
}
