using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using SellAndBye.DataModel;
using SellAndBye.Interface;
using SellAndBye.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SellAndBye.Repository
{
    public class UserRepository : IUserRepository
    {
        MongoServer mongoServer = null;
        MongoDatabase mDB = null;
        MongoCollection mCollection = null;
        public UserRepository()
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
        public bool UserCheckByEmailAndPassword(string email, string password)
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
        public bool UserEmailCheck(string email)
        {
            var iQuery = Query.And(Query.EQ("Email", email));
            var UserCount = mCollection.FindAs(typeof(User), iQuery);
            if (Convert.ToInt32(UserCount.Count()) > 0)
            {
                return true;
            }
            else
                return false;
        }
        public User UserInfoByEmail(string email) {
            var iQuery = Query.And(Query.EQ("Email", email));
            var UserCount = mCollection.FindAs(typeof(User), iQuery);
            User user = new User();
            foreach (User objUser in UserCount)
            {
                user = objUser;
            }
            return user;
        }
        public User Add(User user)
        {
            if (string.IsNullOrEmpty(user.Id))
            {
                user.Id = Guid.NewGuid().ToString();
            }
            mCollection.Save(user);
            return user;
        }
        public bool Update(string objectId, User user)
        {
            try
            {
                UpdateBuilder updateBuilder = MongoDB.Driver.Builders.Update.Set("Name", user.Name)
                .Set("Mobile", user.Mobile);
                mCollection.Update(Query.EQ("_id", objectId), updateBuilder);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        public bool ImageUpdate(string email, string imagePath)
        {
            UpdateBuilder updateBuilder = MongoDB.Driver.Builders.Update.Set("ImagePath", imagePath);
            mCollection.Update(Query.EQ("Email", email), updateBuilder);
            return true;
        }
        public bool Delete(string objectId)
        {
            try
            {
                mCollection.Remove(Query.EQ("_id", objectId));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}