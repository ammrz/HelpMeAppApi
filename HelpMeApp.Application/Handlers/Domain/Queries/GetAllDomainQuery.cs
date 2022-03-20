using AutoMapper.Internal.Mappers;
using HelpMeApp.Application.Dtos;
using HelpMeApp.Application.Mapper;
using HelpMeApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Domain.Queries
{
    public class GetAllDomainQuery : IRequest<List<DomainDto>>
    {
        public class GetAllDomainHandler : IRequestHandler<GetAllDomainQuery, List<DomainDto>>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Domain> _repository;
            public GetAllDomainHandler(GenericRepository<HelpMeApp.Domain.Entities.Domain> repository)
            {
                _repository = repository;
            }

            public async Task<List<DomainDto>> Handle(GetAllDomainQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAll();
                return ObjectMapper.Mapper.Map<List<DomainDto>>(entities);
            }
        }
    }
}
