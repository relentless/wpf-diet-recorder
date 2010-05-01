using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DietRecorder.Client.Common
{
    public static class CollectionExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
                return null;
                //throw new NullReferenceException("ToObservableCollection() cannot be called on a null object");

            ObservableCollection<T> observableCollection = new ObservableCollection<T>();

            foreach (T item in collection)
            {
                observableCollection.Add(item);
            }

            return observableCollection;
        }
    }
}
