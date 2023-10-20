using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BookReadingApp.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime  Date { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartTime { get; set; }
        [Required]
        public EventType EventType{ get; set; }
        [Display(Name ="Duration In Hours")]
        [Range(0,4,ErrorMessage ="Duration must be 0 to 4 hours only")]
        public int Duration { get; set; }
        public string Discription { get; set; }
        public string Others { get; set; }
        [Display(Name ="Invite Others")]
        [NotMapped]
        public string InviteByEmail { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Invitation> Invitation { get; set; }
        public ICollection<Comment> Comment { get; set; }

    }
}
