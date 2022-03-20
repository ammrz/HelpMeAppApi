using HelpMeApp.Application.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpMeApp.Application.Dtos
{
    public class DomainDto : DtoBase
    {
        public string Title { get; set; }
        public string Descripton { get; set; }
    }
}
