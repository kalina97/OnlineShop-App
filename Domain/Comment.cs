using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Comment : BaseEntity
    {
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public string CommentDesc { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }

    }
}
