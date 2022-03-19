using HelpMeApp.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Domain.Entities
{
    public class Comment : BaseEntity
    {
        public string Body { get; set; }
        [ForeignKey("Request")]
        public Guid RequestId { get; set; }
        public Request Request { get; set; }
    }
}
