using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst
{
    public class Picture
    {
        public Picture()
        {
            this.PicturePersons = new HashSet<PicturePerson>();
        }

        public System.Guid Id { get; set; }
        public string Path { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public DateTime? CreatedAt { get; set; }

        public virtual ICollection<PicturePerson> PicturePersons { get; set; }
    }
}
