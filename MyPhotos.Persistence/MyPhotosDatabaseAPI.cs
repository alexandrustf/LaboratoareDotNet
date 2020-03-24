using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyPhotos.Persistence
{
    public class MyPhotosDatabaseAPI
    {
        private readonly ModelMyPhotosContainer context ;
        public MyPhotosDatabaseAPI()
        {

            this.context = new ModelMyPhotosContainer();

        }

        public Guid CreatePhoto(string path, string name, string @event, string place, ICollection<string> persons)
        {
            var people = FindExistingPeople(persons);
            var photo = new Photo
            {
                Id = Guid.NewGuid(),
                Name = name,
                CreatedAt = DateTime.Now,
                Deleted = false,
                Event = @event,
                Path = path,
                Place = place,
                People = people,
                Properties = new List<Property>()
            };
            context.Photos.Add(photo);
            context.SaveChanges();
            return photo.Id;
        }

        public IEnumerable<string> GetAllPropertiesAsStrings()
        {
            var props = typeof(Photo).GetProperties().Select(p => p.Name).ToList();
            props.AddRange(context.Properties.ToList().Select(p => p.Name));
            return props.ToList();
        }

        public IEnumerable<Photo> GetAllPhotos() => context.Photos.ToList();

        public void AddCustomProperty(string id, string name, string value)
        {
            var property = new Property
            {
                Id = Guid.NewGuid(),
                Name = name,
                Value = value
            };
            var photo = context.Photos.FirstOrDefault(p => p.Id == new Guid(id));
            photo.Properties.Add(property);
            context.SaveChanges();
        }


        public IEnumerable<Photo> GetFilteredPhotos(string property, string value)
        {
            var props = typeof(Photo).GetProperties().Select(p => p.Name);
            var foundProperty = props.FirstOrDefault(p => p.Equals(property));
            var filteredPhotos = new List<Photo>();
            if (foundProperty != default(string))
            {
                if (foundProperty == "Id")
                {
                    filteredPhotos = context.Photos.Where(p => p.Id.ToString() == value).ToList();
                }
                if (foundProperty == "Name")
                {
                    filteredPhotos = context.Photos.Where(p => p.Name.Contains(value)).ToList(); ;
                }
                if (foundProperty == "Place")
                {
                    filteredPhotos = context.Photos.Where(p => p.Place.Contains(value)).ToList();
                }
                if (foundProperty == "Event")
                {
                    filteredPhotos = context.Photos.Where(p => p.Event.Contains(value)).ToList();
                }
                if (foundProperty == "People")
                {
                    var person = context.People.FirstOrDefault(p => p.Name.Contains(value));
                    filteredPhotos = context.Photos.Where(p => p.People.Contains(person)).ToList();
                }
            }
            else
            {
                var propertyFound = context.Properties.FirstOrDefault(p => p.Name == property);
                var allPhotos = context.Photos.ToList();
                filteredPhotos = allPhotos.Where(p => p.Properties.Contains(propertyFound)).ToList();
                return filteredPhotos;
            }

            return filteredPhotos;
        }

        public void SendResultsToEmail(IEnumerable<string> ids, string email)
        {

        }

        public string CheckIfPhotoDeleted()
        {
            return "id photo deleted";
        }

        public void ConfirmPhotoDeleted(string idPhoto)
        {

        }
        private ICollection<Person> FindExistingPeople(ICollection<string> persons)
        {
            return persons.Select(s =>
                {
                    var person = context.People.FirstOrDefault(p => p.Name == s);
                    if (person != default(Person))
                    {
                        return person;
                    }
                    return new Person() { Id = Guid.NewGuid(), Name = s };
                }
            ).ToList();
        }

        private void CheckIfFileExists()
        {

            //File.Exists()
        }
    }
}
