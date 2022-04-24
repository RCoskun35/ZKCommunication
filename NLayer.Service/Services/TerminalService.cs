using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class TerminalService : Service<Terminal>,ITerminalService
    {
        private readonly ITerminalRepository _terminalRepository;
        private readonly IMapper _mapper;

        public TerminalService(IGenericRepository<Terminal> repository, IUnitOfWork unitOfWork, ITerminalRepository terminalRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _terminalRepository = terminalRepository;
            _mapper = mapper;
        }
    }
}
