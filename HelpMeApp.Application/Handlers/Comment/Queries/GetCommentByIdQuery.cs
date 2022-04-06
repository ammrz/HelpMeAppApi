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
    public class GetCommentByIdQuery : IRequest<CommentDto>
    {
        public Guid Id { get; set; }

        public class GetCommentByIdHandler : IRequestHandler<GetCommentByIdQuery, CommentDto>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Comment> _repository;
            public GetCommentByIdHandler(IGenericRepository<HelpMeApp.Domain.Entities.Comment> repository)
            {
                _repository = repository;
            }

            public async Task<CommentDto> Handle(GetCommentByIdQuery request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetById(request.Id);
                return ObjectMapper.Mapper.Map<CommentDto>(entity);
            }

        }
    }
}
