using AssessmentOne.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace AssessmentOne.Services
{
    public class UserService : IUserService
    {
        private readonly XDocument _document;
        private const string Path = @"Database/Users.xml";

        public UserService()
        {
            _document = XDocument.Load(Path);
        }

        public User Save(User user)
        {
            if (CheckIfUserExist(user))
                throw new ArgumentException("User already Exist");

            var xml = new XElement("user",
                new XElement("id", Guid.NewGuid()),
                new XElement("name", user.Name),
                new XElement("surname", user.Surname),
                new XElement("cellNumber", user.CellNumber));

            _document.Root?.Add(xml);

            _document.Save(Path, SaveOptions.None);

            return user;
        }

        public User Get(Guid id)
        {
            return _document.Descendants("user").Where(x =>
                new Guid(x.Element("id")!.Value) == id).Select(e =>
                new User
                {
                    Id = new Guid(e.Element("id")!.Value),
                    Name = e.Element("name")?.Value,
                    Surname = e.Element("surname")?.Value,
                    CellNumber = e.Element("cellNumber")?.Value
                }).FirstOrDefault();
        }

        public void Delete(Guid id)
        {
            var emp = _document.Descendants("user").FirstOrDefault(p => new Guid(p.Element("id")!.Value) == id);

            if (emp != null)
            {
                emp.Remove();
                _document.Save(Path, SaveOptions.None);
            }
        }

        public void Update(User user)
        {
            var node = _document.Descendants("user").FirstOrDefault(u => new Guid(u.Element("id")!.Value) == user.Id);

            if (CheckIfUserExist(user))
                throw new ArgumentException("User already Exist");

            if (node != null)
            {
                node.SetElementValue("id", user.Id);
                node.SetElementValue("name", user.Name);
                node.SetElementValue("surname", user.Surname);
                node.SetElementValue("cellNumber", user.CellNumber);
            }

            _document.Save(Path);
        }

        public IEnumerable<User> GetAll()
        {
            return _document.Descendants("user").Select(e =>
                new User
                {
                    Id = new Guid(e.Element("id")!.Value),
                    Name = e.Element("name")?.Value,
                    Surname = e.Element("surname")?.Value,
                    CellNumber = e.Element("cellNumber")?.Value
                });
        }

        private bool CheckIfUserExist(User user)
        {
            return _document.Descendants("user").Any(p =>
                string.Equals(p.Element("name")?.Value, user.Name, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(p.Element("surname")?.Value, user.Surname,
                    StringComparison.InvariantCultureIgnoreCase) &&
                new Guid(p.Element("id")!.Value) != user.Id);
        }
    }
}