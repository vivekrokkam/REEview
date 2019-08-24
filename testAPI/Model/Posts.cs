using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace testAPI.Model
{
    public partial class Posts
    {
        public int PostsId { get; set; }
        public int? BlogId { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Content { get; set; }

        [ForeignKey("BlogId")]
        [InverseProperty("Posts")]
        public virtual Blogger Blog { get; set; }
    }
}
