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

namespace HelpMeApp.Application.Handlers.Comment.Queries
{
    public class GetAllCommentQuery : IRequest<List<CommentDto>>
    {
        public class GetAllCommentHandler : IRequestHandler<GetAllCommentQuery, List<CommentDto>>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Comment> _repository;
            public GetAllCommentHandler(IGenericRepository<HelpMeApp.Domain.Entities.Comment> repository)
            {
                _repository = repository;
            }

            public async Task<List<CommentDto>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
            {
                var entities = await _repository.GetAll();
                return ObjectMapper.Mapper.Map<List<CommentDto>>(entities);
            }
        }
    }
}
