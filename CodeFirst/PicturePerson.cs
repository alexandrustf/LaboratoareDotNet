using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst
{
    public class PicturePerson
    {
        public Guid PersonId { get; set; }
        public Person Person { get; set; }
        public Guid PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}
