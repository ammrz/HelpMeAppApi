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
    public class AddCommentCommand : IRequest
    {
        public string Body { get; set; }

        public class AddCommentHandler : IRequestHandler<AddCommentCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Comment> _repository;
            public AddCommentHandler(IGenericRepository<HelpMeApp.Domain.Entities.Comment> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(AddCommentCommand request, CancellationToken cancellationToken)
            {
                HelpMeApp.Domain.Entities.Comment entity = new HelpMeApp.Domain.Entities.Comment
                {
                    Body = request.Body,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now
                };

                await _repository.Insert(entity);
                await _repository.Save();

                return Unit.Value;
            }
        }
    }
}
