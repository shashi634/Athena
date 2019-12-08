using System.Collections.Generic;

namespace Athena.Models.Dto
{
    public class GetQuestionDto
    {
        public string Question { get; set; }
        public List<Options> Options { get; set; }
    }
}