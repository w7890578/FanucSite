using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;

namespace SiteList
{
    public class souqi : BaseModel<souqi>
    {
        public ManualResetEvent eventX = new ManualResetEvent(false);
        protected int iCount = 0;
        public void Grab()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(Search), 1);
        }
        private void Search(object index)
        {
            //Thread.Sleep(100000);
            Interlocked.Increment(ref iCount);
            Console.WriteLine("搜企发出结束信号!");
            eventX.Set();
        }
    }

    public class test
    {
        public virtual void TestWrite()
        {
            Console.WriteLine("这是激烈函数");
        }
    }
    public class child : test
    {
        public override void TestWrite()
        {
            Console.WriteLine("这是子类函数");
        }
    }

    public class SingleClass
    {
        public static string names = "sdfs";
        protected static readonly string name ;
        protected SingleClass() { }
        private static readonly object locker = new object();
        private static volatile SingleClass _instance;
        public static SingleClass Instatnce
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        _instance = new SingleClass();
                    }
                }
                return _instance;
            }
        }

        public void Es()
        {
            Type type = typeof(int);
            int i = 1;
            i.GetType();

        }
    }
}

