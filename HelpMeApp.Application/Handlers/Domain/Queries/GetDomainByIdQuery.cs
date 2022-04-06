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
    public class GetDomainByIdQuery :  IRequest<DomainDto>
    {
        public Guid Id { get; set; }

        public class GetDomainByIdHandler : IRequestHandler<GetDomainByIdQuery, DomainDto>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Domain> _repository;
            public GetDomainByIdHandler(IGenericRepository<HelpMeApp.Domain.Entities.Domain> repository)
            {
                _repository = repository;
            }

            public async Task<DomainDto> Handle(GetDomainByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetById(request.Id);
                return ObjectMapper.Mapper.Map<DomainDto>(entity);
            }

        }
    }
}
