using System;
using System.Collections.Generic;

namespace Athena.Models.Dto
{
    public class GetQuestionDto
    {
        public string Question { get; set; }
        public Guid Id   { get; set; }
        public List<GetOptions> Options { get; set; }
    }
    public class GetQuestionOnlyDto
    {
        public string Question { get; set; }
        public List<OptionsOnly> Options { get; set; }
    }
}