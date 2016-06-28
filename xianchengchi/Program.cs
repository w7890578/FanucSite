using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace xianchengchi
{
    class Program
    {
        public static void Main()
        {
            //新建ManualResetEvent对象并且初始化为无信号状态
            ManualResetEvent eventX = new ManualResetEvent(false);
            ThreadPool.SetMaxThreads(3, 3);
            thr t = new thr(15, eventX);
            for (int i = 0; i < 15; i++)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(t.ThreadProc), i);
            }
            //等待事件的完成，即线程调用ManualResetEvent.Set()方法
            //eventX.WaitOne  阻止当前线程，直到当前 WaitHandle 收到信号为止。 
            eventX.WaitOne(Timeout.Infinite, true);
            Console.WriteLine("断点测试");
            //Thread.Sleep(10000);
            Console.WriteLine("运行结束");
            Console.ReadKey();
        }

        public class thr
        {
            public thr(int count, ManualResetEvent mre)
            {
                iMaxCount = count;
                eventX = mre;
            }

            public static int iCount = 0;
            public static int iMaxCount = 0;
            public ManualResetEvent eventX;
            public void ThreadProc(object i)
            {
                Console.WriteLine("Thread[" + i.ToString() + "]");
                //Thread.Sleep(2000);
                //Interlocked.Increment()操作是一个原子操作，作用是:iCount++ 具体请看下面说明 
                //原子操作，就是不能被更高等级中断抢夺优先的操作。你既然提这个问题，我就说深一点。
                //由于操作系统大部分时间处于开中断状态，
                //所以，一个程序在执行的时候可能被优先级更高的线程中断。
                //而有些操作是不能被中断的，不然会出现无法还原的后果，这时候，这些操作就需要原子操作。
                //就是不能被中断的操作。
                Interlocked.Increment(ref iCount);
                if (iCount == iMaxCount)
                {
                    Console.WriteLine("发出结束信号!");
                    //将事件状态设置为终止状态，允许一个或多个等待线程继续。
                    eventX.Set();
                }
            }
        }
    }
}
