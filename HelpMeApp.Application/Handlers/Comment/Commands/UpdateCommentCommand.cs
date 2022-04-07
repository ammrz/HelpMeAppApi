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
    public class UpdateCommentCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public Guid RequestId { get; set; }

        public class UpdateCommentHandler : IRequestHandler<UpdateCommentCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Comment> _repository;
            public UpdateCommentHandler(IGenericRepository<HelpMeApp.Domain.Entities.Comment> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetById(request.Id);
                entity.Body = request.Body;
                entity.UpdateDate = DateTime.Now;
                entity.RequestId = request.RequestId;

                _repository.Update(entity);
                await _repository.Save();

                return Unit.Value;
            }
        }
    }
}
