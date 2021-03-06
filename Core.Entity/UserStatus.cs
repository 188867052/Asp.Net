﻿using System.Collections.Generic;

namespace Core.Entity
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            this.User = new HashSet<User>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
