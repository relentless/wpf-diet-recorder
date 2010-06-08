using System;
using System.Collections.Generic;
using DietRecorder.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using User = DietRecorder.Model.User; // as opposed to db4o user

namespace DietRecorder.DataAccess
{
    public class Repository: IRepository, IDisposable
    {
        private IObjectContainer _database;

        public Repository()
        {
            IEmbeddedConfiguration config = Db4oEmbedded.NewConfiguration();
            config.Common.ObjectClass(typeof(DietRecorder.Model.User)).CascadeOnUpdate(true);
            config.Common.ObjectClass(typeof(DietRecorder.Model.User)).CascadeOnDelete(true);
            _database = Db4oEmbedded.OpenFile(config, "DietDB.db4o");
        }

        public Repository(IObjectContainer Database)
        {
            this._database = Database;
        }

        public IList<User> LoadUserList()
        {
            IList<User> users = _database.Query<User>();

            if (users == null)
                return new List<User>();
            else
                return users;
        }

        public void SaveUserList(IEnumerable<User> Users)
        {
            foreach (User user in Users)
            {
                _database.Store(user);
            }
        }

        public void Delete(object obj)
        {
            _database.Delete(obj);
        }

        public void Dispose()
        {
            _database.Close();
        }
    }
}
