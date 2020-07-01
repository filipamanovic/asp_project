using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class LogDto
    {
        public string Actor { get; set; }
        public string UseCaseName { get; set; }
        public string Data { get; set; }
        public DateTime Date { get; set; }
    }
}
