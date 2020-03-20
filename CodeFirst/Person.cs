using System;
using System.Collections.Generic;
using System.Text;

namespace CodeFirst
{
    public class Person
    {
        public System.Guid Id { get; set; }
        public string Name { get; set; }

        public List<PicturePerson> PicturePersons{ get; set; }
    }
}
