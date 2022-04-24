using AutoMapper;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Repositories;
using NLayer.Core.Services;
using NLayer.Core.UnitOfWorks;

namespace NLayer.Service.Services
{
    public class EventDataService : Service<EventData>,IEventDataService
    {
        private readonly IEventDataRepository _eventDataRepository;
        private readonly IMapper _mapper;

        public EventDataService(IGenericRepository<EventData> repository, IUnitOfWork unitOfWork, IEventDataRepository eventDataRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _eventDataRepository = eventDataRepository;
            _mapper = mapper;
        }
    }
}
