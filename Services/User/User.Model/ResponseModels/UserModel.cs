using System;

namespace User.Model.ResponseModels
{
    public class UserModel
    {
        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
