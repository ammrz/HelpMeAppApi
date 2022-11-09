using HelpMeApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Comment.Commands
{
    public class DeleteCommentCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteCommentHandler : IRequestHandler<DeleteCommentCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Comment> _repository;
            public DeleteCommentHandler(IGenericRepository<HelpMeApp.Domain.Entities.Comment> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
            {

                _repository.Delete(request.Id);
                await _repository.Save();

                return Unit.Value;
            }
        }
    }
}
