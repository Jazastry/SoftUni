using BlogSystem.Data;
using BlogSystem.Models;
using BlogSystem.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;

namespace BlogSystem.Client.Controllers
{
    [Authorize]
    [RoutePrefix("api/Users")]
    public class UsersController : BaseController
    {
        public UsersController()
            : this(new BlogSystemData(new BlogSystemDbContext()))
        {
        }
        public UsersController(IBlogSystemData data)
        {
            this.data = data;
        }
        // GET api/users
        [Route("GetAll")]
        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            var usersQuery = this.data.Users.AllAuthors();
            var usersResult = DeserializeUsersQuery(usersQuery);
            return usersResult;
        }

        // GET api/users?gender={int}  0 - Other, 1 - Male, 2- Female 
        [Route("GetByGender")]
        [HttpGet]
        public IEnumerable<User> GetUsersByGender(int gender)
        {
            Gender currentGender = Utilities.GetGender(gender);
            var resultQuery = this.Data.Users.AllByGender(currentGender);
            var resultUsers = DeserializeUsersQuery(resultQuery);
            return resultUsers;
        }

        // POST api/users?username={string}
        [Route("GetByUserName")]
        [HttpGet]
        public User GetByUsername([FromUri]string username)
        {
            var currentUser = this.Data.Users.GetUserByUsername(username);
            var result = new User()
            {
                UserName = currentUser.UserName,
                RegistrationDate = currentUser.RegistrationDate,
                PhoneNumber = currentUser.PhoneNumber,
                Gender = currentUser.Gender,
                FullName = currentUser.FullName,
                Email = currentUser.Email,
                ContactInfo = currentUser.ContactInfo,
                Birthday = currentUser.Birthday
            };
            return result;
        }

        private List<User> DeserializeUsersQuery(IQueryable<User> usersQuery)
        {
            List<User> resultUsers = new List<User>();
            foreach (var currentUser in usersQuery)
            {
                var cc = currentUser;
                resultUsers.Add(
                    new User()
                    {
                        UserName = currentUser.UserName,
                        RegistrationDate = currentUser.RegistrationDate,
                        PhoneNumber = currentUser.PhoneNumber,
                        Gender = currentUser.Gender,
                        FullName = currentUser.FullName,
                        Email = currentUser.Email,
                        ContactInfo = currentUser.ContactInfo,
                        Birthday = currentUser.Birthday
                    }
                );
            }
            return resultUsers;
        }
    }
}
