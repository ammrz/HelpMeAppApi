using HelpMeApp.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Dtos
{
    public class RequestDto : DtoBase
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public Guid DomainId { get; set; }
        public List<CommentDto> Comments { get; set; }
    }
}
