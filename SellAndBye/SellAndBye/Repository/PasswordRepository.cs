using MongoDB.Driver;
using MongoDB.Driver.Builders;
using SellAndBye.DataModel;
using SellAndBye.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SellAndBye.Repository
{
    public class PasswordRepository : IPasswordRepository
    {
        MongoServer mongoServer = null;
        MongoDatabase mDB = null;
        MongoCollection mCollection = null;
        public PasswordRepository()
        {
            try
            {
                mongoServer = MongoServer.Create();
                mongoServer.Connect();
                mDB = mongoServer.GetDatabase("SellAndBye");
                mCollection = mDB.GetCollection<User>("User");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public bool PassWordCheckByEmail(string email, string password)
        {
            var iQuery = Query.And(Query.EQ("Email", email), Query.EQ("Password", password));
            var UserCount = mCollection.FindAs(typeof(User), iQuery);
            if (Convert.ToInt32(UserCount.Count()) > 0)
            {
                return true;
            }
            else
                return false;
        }
        public bool Update(string email, string password)
        {
            try
            {
                UpdateBuilder updateBuilder = MongoDB.Driver.Builders.Update.Set("Password", password);
                mCollection.Update(Query.EQ("Email", email), updateBuilder);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}