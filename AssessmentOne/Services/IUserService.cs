using AssessmentOne.Model;
using System;
using System.Collections.Generic;

namespace AssessmentOne.Services
{
    public interface IUserService
    {
        User Save(User user);

        User Get(Guid id);

        void Delete(Guid id);

        void Update(User user);

        IEnumerable<User> GetAll();
    }
}