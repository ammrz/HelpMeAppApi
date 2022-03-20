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
    public class GetAllRequestQuery : IRequest<List<RequestDto>>
    {
        public class GetProductsHandler : IRequestHandler<GetAllRequestQuery, List<RequestDto>>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Request> _repository;
            public GetProductsHandler(GenericRepository<HelpMeApp.Domain.Entities.Request> repository)
            {
                _repository = repository;
            }

            public async Task<List<RequestDto>> Handle(GetAllRequestQuery request, CancellationToken cancellationToken)
            {
                var entities =  await _repository.GetAll();
                
                return ObjectMapper.Mapper.Map<List<RequestDto>>(entities);
            }
        }
    }
}
