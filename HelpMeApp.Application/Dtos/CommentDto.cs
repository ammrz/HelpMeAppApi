using HelpMeApp.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Dtos
{
    public class CommentDto : DtoBase
    {
        public string Body { get; set; }
        public Guid RequestId { get; set; }
}
}
