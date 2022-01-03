using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartTests.Models
{
    public class UserFavoritTestModel
    {
        public int Id { get; set; }

        public int UserModelId { get; set; }
        [ForeignKey("UserModelId")]
        public virtual UserModel User { get; set; }

        public int TestQuizModelId { get; set; }
        [ForeignKey("TestQuizModelId")]
        public virtual TestQuizModel FavoritTest { get; set; }
    }
}
