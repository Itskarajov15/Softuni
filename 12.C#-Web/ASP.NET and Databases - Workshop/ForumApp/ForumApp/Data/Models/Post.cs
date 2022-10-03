using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

using static ForumApp.Data.DataConstants.Post;

namespace ForumApp.Data.Models
{
    [Comment("Published posts")]
    public class Post
    {
        [Comment("Posts Identifier")]
        public int Id { get; init; }

        [Comment("Post Title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Content")]
        [Required]
        [MaxLength(ContentMaxLength)]
        public string Content { get; set; } = null!;

        [Comment("Marks record as deleted")]
        [Required]
        public bool IsDeleted { get; set; } = false;
    }
}