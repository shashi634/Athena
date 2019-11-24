using System;
using System.Collections.Generic;

namespace Athena.Models
{
    public class QuestionOption
    {
        public QuestionOption()
        {
            UserAnswer = new HashSet<UserAnswer>();
        }

        public decimal Id { get; set; }
        public decimal QuestionId { get; set; }
        public string Qoption { get; set; }
        public bool IsCorrect { get; set; }

        public virtual Organization Question { get; set; }
        public virtual ICollection<UserAnswer> UserAnswer { get; set; }
    }
}
