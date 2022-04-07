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
    public class AddRequestCommand : IRequest<Guid>
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid DomainId { get; set; }

        public class AddRequestHandler : IRequestHandler<AddRequestCommand, Guid>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Request> _repository;
            public AddRequestHandler(IGenericRepository<HelpMeApp.Domain.Entities.Request> repository)
            {
                _repository = repository;
            }
            public async Task<Guid> Handle(AddRequestCommand request, CancellationToken cancellationToken)
            {
                HelpMeApp.Domain.Entities.Request entity = new HelpMeApp.Domain.Entities.Request
                {
                    Subject = request.Subject,
                    Body = request.Body,
                    CreationDate = DateTime.Now,
                    UpdateDate = DateTime.Now,
                    DomainId = request.DomainId
                };

                await _repository.Insert(entity);
                await _repository.Save();

                return entity.Id;
            }
        }
    }
}
