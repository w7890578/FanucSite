using System;
using Microsoft.Practices.EnterpriseLibrary.Data;
using ORM;

namespace FanucSite.DAL
{
    public static class ORMDAL
    {
        #region DB
        private static object _readLock = new object();
        private static volatile Database _read;
        internal static Database Read
        {
            get
            {
                if (_read == null)
                {
                    lock (_readLock)
                    {
                        return _read ?? (_read = DatabaseFactory.CreateDatabase("Fanuc_Reader"));
                    }
                }
                return _read;
            }
        }
        private static object _writeLock = new object();
        private static volatile Database _write;
        internal static Database Write
        {
            get
            {
                if (_write == null)
                {
                    lock (_writeLock)
                    {
                        return _write ?? (_write = DatabaseFactory.CreateDatabase("Fanuc_Reader"));
                    }
                }
                return _write;
            }
        }


        private static object _adminLock = new object();
        private static volatile Database _admin;
        internal static Database Admin
        {
            get
            {
                if (_admin == null)
                {
                    lock (_adminLock)
                    {
                        return _admin ?? (_admin = DatabaseFactory.CreateDatabase("Fanuc_Reader"));
                    }
                }
                return _admin;
            }
        }

        public static GetDb GetNormal = delegate() { return Admin; };
        public static GetDb GetRead = delegate() { return Read; };
        public static GetDb GetWrite = delegate() { return Write; };
        #endregion
    }
}
