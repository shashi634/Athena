using System;
using System.Collections.Generic;

namespace Athena.Models.Dto
{
    public class AddQuestionDto
    {
        public string Question { get; set; }
        public string SubjectId { get; set; }
        public List<Options> Options { get; set; }
    }

    public class Options {
        public Guid Id { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class QuestionsOnly
    {
        public string Question { get; set; }
        public string SubjectId { get; set; }
        public List<OptionsOnly> Options { get; set; }
    }
    public class OptionsOnly
    {
        public string Option { get; set; }
    }
}