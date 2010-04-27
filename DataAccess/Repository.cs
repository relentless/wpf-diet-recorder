using System;
using System.Collections.Generic;
using DietRecorder.Model;
using Db4objects.Db4o;
using Db4objects.Db4o.Config;
using User = DietRecorder.Model.User;

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

        public IEnumerable<User> Load()
        {
            return database.Query<User>();
        }

        public void Save(IEnumerable<User> Users)
        {
            foreach (User user in Users)
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
