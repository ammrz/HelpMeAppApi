using HelpMeApp.Infrastructure.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Handlers.Domain.Commands
{
    public class DeleteDomainCommand : IRequest
    {
        public Guid Id { get; set; }

        public class DeleteDomainHandler : IRequestHandler<DeleteDomainCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Domain> _repository;
            public DeleteDomainHandler(IGenericRepository<HelpMeApp.Domain.Entities.Domain> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(DeleteDomainCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetById(request.Id);

                _repository.Delete(entity);
                await _repository.Save();

                return Unit.Value;
            }
        }
    }
}
