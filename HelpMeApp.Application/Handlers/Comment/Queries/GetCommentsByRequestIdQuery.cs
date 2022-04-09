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

namespace HelpMeApp.Application.Handlers.Comment.Queries
{
    public class GetCommentsByRequestIdQuery : IRequest<List<CommentDto>>
    {
        public Guid RequestId { get; set; }

        public class GetCommentsByRequestIdHandler : IRequestHandler<GetCommentsByRequestIdQuery, List<CommentDto>>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Comment> _repository;
            public GetCommentsByRequestIdHandler(IGenericRepository<HelpMeApp.Domain.Entities.Comment> repository)
            {
                _repository = repository;
            }

            public async Task<List<CommentDto>> Handle(GetCommentsByRequestIdQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.Get(elt => elt.RequestId == request.RequestId);
                return ObjectMapper.Mapper.Map<List<CommentDto>>(entities);
            }
        }

    }
}
