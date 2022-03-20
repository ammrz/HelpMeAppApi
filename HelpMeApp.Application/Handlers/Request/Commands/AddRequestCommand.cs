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
    public class AddRequestCommand : IRequest
    {
        public string Subject { get; set; }
        public string Body { get; set; }

        public class AddRequestHandler : IRequestHandler<AddRequestCommand, Unit>
        {
            private IGenericRepository<HelpMeApp.Domain.Entities.Request> _repository;
            public AddRequestHandler(GenericRepository<HelpMeApp.Domain.Entities.Request> repository)
            {
                _repository = repository;
            }
            public async Task<Unit> Handle(AddRequestCommand request, CancellationToken cancellationToken)
            {
                HelpMeApp.Domain.Entities.Request entity = new HelpMeApp.Domain.Entities.Request
                {
                    Subject = request.Subject,
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
