using HelpMeApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Request.Commands
{
    public class UpdateRequestCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public class UpdateRequestHandler : IRequestHandler<UpdateRequestCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Request> _repository;
            public UpdateRequestHandler(GenericRepository<HelpMeApp.Domain.Entities.Request> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetById(request.Id);
                entity.Subject = request.Subject;
                entity.Body = request.Body;
                entity.UpdateDate = DateTime.Now;

                _repository.Update(entity);
                await _repository.Save();

                return Unit.Value;
            }
        }
    }
}
