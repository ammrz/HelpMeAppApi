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
    public class UpdateDomainCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class UpdateDomainHandler : IRequestHandler<UpdateDomainCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Domain> _repository;
            public UpdateDomainHandler(IGenericRepository<HelpMeApp.Domain.Entities.Domain> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(UpdateDomainCommand request, CancellationToken cancellationToken)
            {
                var entity = await _repository.GetById(request.Id);
                entity.Title = request.Title;
                entity.Descripton = request.Description;
                entity.UpdateDate = DateTime.Now;

                _repository.Update(entity);
                await _repository.Save();

                return Unit.Value;
            }
        }
    }
}
