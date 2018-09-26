using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SimpleBot.Logic
{
    public class UserProfileSQLRepo : IUserProfileRepository
    {
        private DbContext _context;

        public UserProfileSQLRepo(string connectionString)
        {
            var db = new Context(connectionString);
            this._context = db;
        }

        public UserProfile GetProfile(string id)
        {
            var profile = _context.Set<UserProfileSQL>().FirstOrDefault(x => x.Id == id);

            return new UserProfile
            {
                Id = profile.Id,
                Visitas = profile.Visitas
            };
        }

        public void SetProfile(string id, UserProfile profile)
        {
            // Essa classe é a mesma que UserProfileSQL?
            _context.Set<UserProfile>().Add(profile);
            _context.SaveChanges();
        }
    }
}
