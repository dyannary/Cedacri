using Microsoft.AspNetCore.Identity;
using NotesApp.Domain.Enums;
using System.Data;

namespace NotesApp.Domain.Entities
{
    public class User : IdentityUser<int>
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public Role Role { get; set; }

        public DateTime CreateDateTime { get; set; } = DateTime.Now;

        public DateTime UpdateDateTime { get; set; } = DateTime.Now;
        public virtual ICollection<Note>? Notes { get; set; }
        public virtual ICollection<Event>? Events { get; set; }
        public virtual ICollection<Entities.Task>? Tasks { get; set; }



    }
}
