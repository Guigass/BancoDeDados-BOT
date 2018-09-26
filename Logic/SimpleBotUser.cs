    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimpleBot.Logic;

namespace SimpleBot
{
    public static class SimpleBotUser
    {
        static IUserProfileRepository _userProfile;

        static SimpleBotUser()
        {
            // Voce testou esse código?
            _userProfile = new UserProfileSQLRepo("mongodb://127.0.0.1");
        }

        public static string Reply(Message message)
        {
            var id = message.Id;

            var profile = _userProfile.GetProfile(id);

            profile.Visitas += 1;

            _userProfile.SetProfile(id, profile);

            return $"{message.User} disse '{message.Text} e mandou {profile.Visitas} mensagens'";
        }

        //public static void SalvarHistorico(Message message)
        //{
        //    var client = new MongoClient("mongodb://localhost:27017");

        //    var doc = new BsonDocument
        //    {
        //        { "id", message.Id },
        //        { "texto", message.Text},
        //        { "app", "teste"}
        //    };

        //    var db = client.GetDatabase("db01");
        //    var col = db.GetCollection<BsonDocument>("tabela01");
        //    col.InsertOne(doc);
        //}

    }
}
