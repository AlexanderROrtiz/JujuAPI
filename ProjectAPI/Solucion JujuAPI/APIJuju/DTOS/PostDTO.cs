using System;
using System.Collections.Generic;
using System.Text;

namespace DTOS
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public int Type { get; set; }
        public string Category { get; set; }
        public int CustomerId { get; set; }
    }
}
