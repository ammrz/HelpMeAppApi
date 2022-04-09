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

namespace HelpMeApp.Application.Handlers.Request.Queries
{
    public class GetRequestsByDomainIdQuery : IRequest<List<RequestDto>>
    {
        public Guid DomainId { get; set; }
        public class GetRequestsByDomainIdHandler : IRequestHandler<GetRequestsByDomainIdQuery, List<RequestDto>>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Request> _repository;
            public GetRequestsByDomainIdHandler(IGenericRepository<HelpMeApp.Domain.Entities.Request> repository)
            {
                _repository = repository;
            }

            public async Task<List<RequestDto>> Handle(GetRequestsByDomainIdQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.Get(elt => elt.DomainId == request.DomainId);
                return ObjectMapper.Mapper.Map<List<RequestDto>>(entities);
            }
        }
    }
}
