using HelpMeApp.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Domain.Entities
{
    public class Request : BaseEntity
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        [ForeignKey("Domain")]
        public Guid DomainId { get; set; }
        public Domain Domain { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
