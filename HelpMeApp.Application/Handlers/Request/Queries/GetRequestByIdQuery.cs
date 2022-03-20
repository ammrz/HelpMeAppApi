using HelpMeApp.Application.Dtos;
using HelpMeApp.Application.Mapper;
using HelpMeApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Request.Queries
{
    public class GetRequestByIdQuery : IRequest<RequestDto>
    {
        public Guid Id { get; set; }

        public class GetRequestByIdHandler : IRequestHandler<GetRequestByIdQuery, RequestDto>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Request> _repository;
            public GetRequestByIdHandler(GenericRepository<HelpMeApp.Domain.Entities.Request> repository)
            {
                _repository = repository;
            }

            public async Task<RequestDto> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetById(request.Id);
                return ObjectMapper.Mapper.Map<RequestDto>(entity);
            }

        }
    }
}
