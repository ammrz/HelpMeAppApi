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
    public class DeleteRequestCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteRequestHandler : IRequestHandler<DeleteRequestCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Request> _repository;
            public DeleteRequestHandler(IGenericRepository<HelpMeApp.Domain.Entities.Request> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(DeleteRequestCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetById(request.Id);

                _repository.Delete(entity);
                await _repository.Save();

                return Unit.Value;
            }
        }
    }
}
