using System;

namespace OrderForm.Data
{
    internal static class DataFactory
    {
        public static T CreateDataMethod<T>()
        {
            if (typeof(T)  == typeof (IReadWriteRepository))
            {
                IReadWriteRepository _dbRepo = new DBRepository();
                return (T)_dbRepo;
            }
            else if (typeof(T) == typeof(IWriteRepository))
            {
                IWriteRepository _xmlRepo = new XMLRepository();
                return (T)_xmlRepo;
            }
            else
                return (T)Convert.ChangeType(null, typeof(T));
            
        }
    }
}

