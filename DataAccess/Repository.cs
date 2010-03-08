using System;
using System.Collections.Generic;
using DietRecorder.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;

namespace DietRecorder.DataAccess
{
    public class Repository: IRepository, IDisposable
    {
        private IObjectContainer database;

        public Repository()
        {
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ObjectClass(typeof(DietRecorder.Model.User)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(DietRecorder.Model.User)).CascadeOnDelete(true);
            database = Db4oEmbedded.OpenFile(config, "DietDB.db4o");
        }

        public UserList Load()
        {
            IList<DietRecorder.Model.User> users = database.Query<DietRecorder.Model.User>();

            if (users.Count == 0)
            {
                return null;
            }
            else
            {
                UserList userList = new UserList();

                foreach (DietRecorder.Model.User user in users)
                {
                    userList.Add(user);
                }

                return userList;
            }
        }

        public void Save(UserList userList)
        {
            foreach (DietRecorder.Model.User user in userList)
            {
                database.Store(user);
            }
        }

        public void Delete(object obj)
        {
            database.Delete(obj);
        }

        public void Dispose()
        {
            database.Close();
        }
    }
}
