using System.Collections.Generic;

namespace Athena.Models.Dto
{
    public class GetQuestionDto
    {
        public string Question { get; set; }
        public List<Options> Options { get; set; }
    }
    public class GetQuestionOnlyDto
    {
        public string Question { get; set; }
        public List<OptionsOnly> Options { get; set; }
    }
}