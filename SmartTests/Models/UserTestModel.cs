using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class UserTestModel
    {
      
        public int Id { get; set; }

        public int UserModelId { get; set; }
        public virtual UserModel UserModel { get; set; }

        public int TestQuizModelId { get; set; }

        public virtual TestQuizModel Test { get; set; }

    }
}
