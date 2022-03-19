using HelpMeApp.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Domain.Entities
{
    public class Domain : BaseEntity
    {
        public string Title { get; set; }
        public string Descripton { get; set; }
        public List<Request> Requests { get; set; }
    }
}
