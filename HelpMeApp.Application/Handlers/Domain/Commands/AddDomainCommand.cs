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
    class AddDomainCommand : IRequest
    {
        public string Title { get; set; }
        public string Desciption { get; set; }

        public class AddDomainHandler : IRequestHandler<AddDomainCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Domain> _repository;
            public AddDomainHandler(GenericRepository<HelpMeApp.Domain.Entities.Domain> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(AddDomainCommand request, CancellationToken cancellationToken)
            {
                HelpMeApp.Domain.Entities.Domain entity = new HelpMeApp.Domain.Entities.Domain
                {
                    Title = request.Title,
                    Descripton = request.Desciption,
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
