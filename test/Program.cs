using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using DataHelper;
using SiteList;
namespace test
{

    public class Tempentity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Set()
        {
            string ss = string.Empty;
            return 1 * Get(1, ref ss);
        }
        public static int Get(int i, ref string s)
        {

            return 2;
        }

    }

    class Program
    {
        //public static int Compare(Tempentity a, Tempentity b)
        //{
        //    if (a.Name == null && b.Name == null)
        //    {
        //        return 0;
        //    }
        //    else if (a.Name == null)
        //    {
        //        return -1;
        //    }
        //    else if (b.Name == null)
        //    {
        //        return 1;
        //    }
        //    if (a.Name.CompareTo(b.Name) == 0)
        //    {
        //        return a.Id.CompareTo(b.Id);
        //    }
        //    else
        //    {
        //        return 0 - a.Name.CompareTo(b.Name);
        //    }
        //}
        //public delegate int jisuan(Tempentity a, Tempentity b);
        // public delegate int Call(int num1, int num2);//第一步：定义委托类型

        public static void Main()
        {
            int max = 0;
            int[] arr = { 10, 234, 2, 9, 58 };
            //for (int i = 0; i < arrays.Length - 1; i++)
            //{
            //    max = i;
            //    for (int j = i + 1; j < arrays.Length; j++)
            //    {
            //        if (arrays[j] < arrays[max])
            //        {
            //            max = j;
            //        }
            //    }
            //    int temp = arrays[max];
            //    arrays[max] = arrays[i];
            //    arrays[i] = temp;
            //}
            for (int i = 1; i < arr.Length; i++)
            {
                int t = arr[i];
                int j = i;
                while ((j > 0) && (arr[j - 1] > t))
                {
                    arr[j] = arr[j - 1];//交换顺序    
                    --j;
                }
                arr[j] = t;
            }    
            //int max = 0;
            //for (int i = 0; i < arrays.Length - 1;i++ )
            //{
            //    max = i;
            //    for (int j = i + 1; j < arrays.Length;j++ )
            //    { 
            //        if(arrays[j]>arrays[max])
            //        {
            //            max = j;
            //        }
            //    }
            //    int temp = arrays[max];
            //    arrays[max] = arrays[i];
            //    arrays[i] = temp;
            //}

            //for (int i = 0; i < arrays.Length - 1; ++i)
            //{
            //    max = i;
            //    for (int j = i + 1; j < arrays.Length; ++j)
            //    {
            //        if (arrays[j] < arrays[max])
            //            max = j;
            //    }
            //    int t = arrays[max];
            //    arrays[max] = arrays[i];
            //    arrays[i] = t;
            //}


            //foreach (var item in arrays)
            //{
            //    Console.WriteLine(item);
            //}
            Console.ReadKey();



            new child().TestWrite();
            Console.ReadKey();

            int[] array = new int[100];
            List<int> resultList = new List<int>();
            Random r = new Random();

            //while (array.Length < 100)
            //{

            //    int temp = r.Next(1, 101);
            //    //if (!resultList.Contains(temp))
            //    //{
            //    //    resultList.Add(temp);
            //    //}
            //    array[100 - array.Length] = temp;
            //}
            //resultList.Sort();
            //array = resultList.ToArray();

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }
            Console.ReadKey();

            byte a = 234;
            long abc = 23;
            string ab = "sdf";
            switch (a)
            {
                case 234:
                    Console.WriteLine("aa");
                    break;
            }
            switch (abc)
            {
                case 23:
                    Console.WriteLine("aa");
                    break;
            }
            switch (ab)
            {
                case "sdf":
                    Console.WriteLine("aa");
                    break;
            }

            //int i = System.Text.Encoding.Default.GetBytes("abcdefg 某 某某").Length;
            //i = "abcdefg 某 某某".Length;
            //Console.WriteLine(i);
            //new Tempentity().test(11);
            Console.ReadKey();

            //for (int i = 1; i <= 9; i++)//总行数
            //{
            //    for (int j = 1; j <= i; j++)//总列数 
            //    {
            //        Console.Write(j + "*" + i + "=" + j * i + "  ");
            //    }
            //    Console.WriteLine();
            //}
            //Console.ReadKey();
            Tempentity x, y;
            x = new Tempentity();
            x.Id = 50;
            y = new Tempentity();
            y.Id = 30;
            y = x;
            Console.WriteLine(y.Id);
            y.Id = 70;
            Console.WriteLine(x.Id);
            Console.ReadKey();



            List<Tempentity> asd = new List<Tempentity>() { 
                new Tempentity(){Id=1,Name="aaa"},
                new Tempentity(){Id=2,Name="bbb"},
                new Tempentity(){Id=3,Name="ccc"},
                new Tempentity(){Id=4,Name="ddd"},
                new Tempentity(){Id=7,Name="ddd"},

                new Tempentity(){Id=5 },
            };
            //jisuan s = new jisuan(Compare);
            //int result = s(new Tempentity() { Id = 1, Name = "aaa" }, new Tempentity() { Id = 2, Name = "bbb" });
            //asd.Sort();
            //foreach (var item in asd)
            //{
            //    Console.WriteLine(item.Id + "|" + item.Name);
            //}
            //Console.ReadKey();
            //List<int> asd = new List<int>() { 3, 32, 5, 34, 6, };
            //asd.Sort(delegate(int x, int y)
            //{
            //    return   x.CompareTo(y);
            //});
            //foreach(var item in asd)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadKey();



            // Create a list of parts.
            List<Part> parts = new List<Part>();

            // Add parts to the list.
            parts.Add(new Part() { PartName = "regular seat" });
            parts.Add(new Part() { PartName = "crank arm", PartId = 1234 });
            parts.Add(new Part() { PartName = "shift lever", PartId = 1634 }); ;
            // Name intentionally left null.
            parts.Add(new Part() { PartId = 1334 });
            parts.Add(new Part() { PartName = "banana seat", PartId = 1444 });
            parts.Add(new Part() { PartName = "cassette", PartId = 1534 });


            // Write out the parts in the list. This will call the overridden 
            // ToString method in the Part class.
            Console.WriteLine("\nBefore sort:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }


            // Call Sort on the list. This will use the 
            // default comparer, which is the Compare method 
            // implemented on Part.
            parts.Sort();


            Console.WriteLine("\nAfter sort by part number:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart);
            }

            // This shows calling the Sort(Comparison(T) overload using 
            // an anonymous method for the Comparison delegate. 
            // This method treats null as the lesser of two values.
            //parts.Sort(delegate(Part x, Part y)
            //{
            //    if (x.PartId == null && y.PartId == null) return 0;
            //    else if (x.PartId == null) return -1;
            //    else if (y.PartId == null) return 1;
            //    else return 0 - x.PartId.CompareTo(y.PartId);
            //});

            Console.WriteLine("\nAfter sort by name:");
            foreach (Part aPart in parts)
            {
                Console.WriteLine(aPart.PartId + " " + aPart.PartName);
            }
            Console.ReadKey();
            /*

                Before sort:
                ID: 1434   Name: regular seat
                ID: 1234   Name: crank arm
                ID: 1634   Name: shift lever
                ID: 1334   Name: chain ring
                ID: 1444   Name: banana seat
                ID: 1534   Name: cassette

               After sort by part number:
                ID: 1234   Name: crank arm
                ID: 1334   Name: chain ring
                ID: 1434   Name: regular seat
                ID: 1444   Name: banana seat
                ID: 1534   Name: cassette
                ID: 1634   Name: shift lever

             */

        }


        public static string temp;
        //public static void Main()
        //{
        //    //List<int> resultList = new List<int>();
        //    ////string resultStr = string.Empty;
        //    //int result = calculate(10, resultList);
        //    //string resultStr = string.Empty;
        //    //foreach (var item in resultList)
        //    //{
        //    //    resultStr += (item > 0 ? "+" + item : item.ToString());
        //    //}
        //    ////  Console.WriteLine(result);
        //    //Console.WriteLine(resultStr + "=" + result);
        //    //Console.ReadKey();
        //    Sort();
        //    //Console.WriteLine(SetValue(9));
        //    //Console.ReadKey();
        //    //DataHelper.Btest b = new DataHelper.Btest();
        //    //Console.ReadKey();
        //    //            string callingDomainName = Thread.GetDomain().FriendlyName;

        //    //            string exeAssembly = Assembly.GetEntryAssembly().FullName;
        //    //            // 设置一个新的应用程序域 
        //    //            AppDomainSetup a = new AppDomainSetup();
        //    //            a.ApplicationBase =
        //    //                System.Environment.CurrentDirectory;
        //    //            a.DisallowBindingRedirects = false;
        //    //            a.DisallowCodeDownload = true;
        //    //            a.ConfigurationFile =
        //    //                AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
        //    //            // 创建新的应用程序域

        //    //           // AppDomain b = AppDomain.CreateDomain("b", null, new  { name="sdf" });
        //    ////            MarshalByRefType mbrt =
        //    ////        (MarshalByRefType)b.CreateInstanceAndUnwrap(
        //    ////            exeAssembly,
        //    ////typeof(MarshalByRefType).FullName
        //    //       // );
        //    //            //mbrt.SomeMethod(callingDomainName);
        //    //            // 关闭应用程序域

        //    //           // AppDomain.Unload(ad2);
        //    //            try
        //    //            {
        //    //                // Call the method again. Note that this time it fails 
        //    //                // because the second AppDomain was unloaded. 
        //    //              //  mbrt.SomeMethod(callingDomainName);
        //    //                Console.WriteLine("Sucessful call.");
        //    //            }
        //    //            catch (AppDomainUnloadedException)
        //    //            {
        //    //                Console.WriteLine("Failed call; this is expected.");
        //    //            }
        //}
        // delegate bool doit(string value);
        //static void Main(string[] args)
        //{
        //    //DataHelper.SqlserverHelper<User>.Insert(new User() { ID = 1, Name = "bbb" });
        //    //DataHelper.SqlserverHelper<User>.GetListAll(new User() { ID = 1, Name = "bbb" });
        //    IData<User> user = AbstractFactory<User>.GetData();
        //    user.GetListAll();
        //    //string s = string.Empty;
        //    // s.TrimEnd(',');
        //    //Console.ReadKey();
        //    //DataHelper.OpUser u = new DataHelper.OpUser();
        //    //u.GetModel("User");
        //    //DataOp<User>.InSert(new User() { companyid="aa",username="bb"});
        //    //doit d1 = new doit(SetValue);
        //    // var d1 = new Predicate<string>(SetValue);

        //    //var s = new Func<string, bool>(SetValue);
        //    ////Print("ab", d1);

        //    //Action c = new Action(Abc);
        //    //Action<int, int> b = new Action<int, int>(Ceshi);
        //    //Console.ReadKey();
        //    ////souqi s = new souqi();
        //    ////s.Grab();
        //    ////s.eventX.WaitOne(Timeout.Infinite, true);

        //    //////设置同时处于活动状态的线程池的请求数目
        //    ////ThreadPool.SetMaxThreads(50, 50);
        //    //////执行主要函数
        //    ////HuiCong.Instance.Grab();
        //    //////阻止当前线程，等收到信号灯后再放行
        //    ////HuiCong.Instance.eventX.WaitOne(Timeout.Infinite, true);
        //    ////Console.WriteLine("执行完了");
        //    ////Console.ReadKey();
        //    ////匿名方法
        //    //var s1 = new Predicate<string>(delegate(string item)
        //    //{
        //    //    return string.IsNullOrEmpty(item);
        //    //});

        //    //var s2 = new Predicate<string>((string item) =>
        //    //{
        //    //    return string.IsNullOrEmpty(item);
        //    //});

        //    //var sdf = new Action<string>((string item) =>
        //    //{

        //    //});
        //    //var sdfsdf = new Action<string>(a => Console.WriteLine(a));
        //    //var sdfsdf1 = new Action(() => Console.WriteLine("sd"));
        //    //"aaa".Print();
        //    // Abc();
        //}
        //求 以下表达式的值，写出您想到的一种或几种实现方法： 1-2+3-4+……+m
        static void calculate()
        {
            //int m = 10;
            //int result = 0;
            //string resultStr = string.Empty;
            //for (int i = 1; i <= m; i++)
            //{

            //    if (i % 2 == 1)//奇数
            //    {
            //        result += i;
            //        resultStr += "+" + i;

            //    }
            //    else
            //    {
            //        result -= i;
            //        resultStr += "-" + i;
            //    }
            //}
            //Console.WriteLine(resultStr + "=" + result);
            //Console.ReadKey();


            int m = 10;
            int result = 0;
            string resultStr = string.Empty;
            for (int i = m; i >= 1; i--)
            {
                if (i % 2 == 1)//奇数
                {
                    result += i;
                    resultStr += "+" + i;

                }
                else
                {
                    result -= i;
                    resultStr += "-" + i;
                }
            }
            Console.WriteLine(resultStr + "=" + result);
            Console.ReadKey();
        }
        //5-4+3-2+1
        //1-2+3-4+5
        static int calculate(int m, List<int> resultList)
        {
            if (m <= 0) //递归出口
            {
                return 0;
            }
            if (m % 2 == 0)//偶数则减
            {
                m = 0 - m;
            }
            resultList.Add(m);
            return m + calculate(Math.Abs(m) - 1, resultList);
        }

        //一列数的规则如下: 1 、1 、2 、3 、5 、8 、13 、21 、34......   求 第30 位数是多少，  
        static int SetValue(int digit)
        {
            if (digit <= 0)
            {
                return 0;
            }
            else if (digit <= 2)
            {
                return 1;
            }
            else
            {
                return SetValue(digit - 1) + SetValue(digit - 2);
            }
        }
        static void Sort()
        {
            int[] array = { 23, 345, 23, 55, 76, 3, 4, 7, 54 };
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[i])
                    {
                        array[i] = array[i] + array[j]; //将两者和给一个变量
                        array[j] = array[i] - array[j]; //变量值交换
                        array[i] = array[i] - array[j]; //此时arry[j]已经是arry[i]的值，所以总和-现在arry[j]的值=old array[j]
                        //int temp = array[i];
                        //array[i] = array[j];
                        //array[j] = temp;
                    }
                }
            }
            foreach (var item in array)
            {
                Console.Write(item + ",");
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="list"></param>
        public void SelectionSorter(ArrayList list)
        {

            //List<int>
            int min;
            for (int i = 0; i < list.Count - 1; i++)
            {
                min = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (Convert.ToInt32(list[j]) < Convert.ToInt32(list[min]))
                        min = j;
                }

                int t = Convert.ToInt32(list[min]);
                list[min] = Convert.ToInt32(list[i]);
                list[i] = t;
            }
        }



        //public void Sort(int [] list)  {  
        //     for(int i=1;i＜list.Length;i++)  
        // {   
        //     int t=list[i];  
        //     int j=i; 
        //     while((j＞0)&&(list[j-1]＞t))  
        // {   
        //     list[j]=list[j-1];  --j;  
        // }   
        //     list[j]=t;
        // } 
        //}




        //static void SetValue(int Digit)
        //{
        //    int result = 0;
        //    for (int i = 1; i <= Digit;i++ )
        //    {
        //        if (i <= 2)
        //        {
        //            result += 1;
        //        }
        //        else
        //        { 

        //        }
        //    }
        //}


        static void Print(string a, Predicate<string> dl)
        {
            if (dl(a))
            {
                Console.WriteLine(temp);
            }
        }

        static bool SetValue(string text)
        {
            temp += text;
            return true;
        }
        static void Ceshi(int a, int b)
        {

        }
        static void Abc()
        {
            //    List<int> arr = new List<int>() { 1, 3, 4, 6, 23, 3 };
            //    arr.Where(new Func<int, bool>((a) => { return a > 3; })).Sum();
            //    arr.OfType<int>();
            //    IEnumerable<string> sss = (List<string>)arr.Select<int, string>(a => a.ToString());
            //    arr.SelectMany<int, string>(a => { return new List<string>() { "a", a.ToString() }; });
            //  List<string> companys = new List<string>() { "asd","ddds","sdfds"};
            //    // List<string> users=new List<string> ()
            List<Company> companys = new List<Company>() { };
            companys.Add(new Company() { id = "aa", name = "sdfsdf" });
            //    List<User> users = new List<User>() { 
            //        new User(){username="sdfsdf",companyid="aa"}
            //    };
            //    var s = from c in companys
            //            join b in users on c.id equals b.companyid into results
            //            select new
            //            {
            //                c.id,
            //                c.name
            //            };

            //from a into 集合A join b into 集合B on a.字段 equals b.字段 into 结果集
            //selec new{ c.字段,c.字段}
            //var s2 = from a in companys
            //         let ba = Convert.ToString(a.id)
            //         where a.id.Equals("aa") && !string.IsNullOrEmpty(a.id) && ba.Equals("aa")
            //         select a;
            //foreach(var iten in s2)
            //{}
            var sss = from p in companys
                      select new
                      {
                          id = p.id
                      }
                          into resultlist
                          orderby resultlist.id ascending
                          select resultlist;
            // Linq、线程池、正则表达式

        }

        //public static void Print(this String val)
        //{
        //    Console.WriteLine(val);
        //}
        static IEnumerable<int> GetIterator()
        {
            Console.WriteLine("sdfsdf");
            yield return 1;
        }
    }

    public static class SomeOneFactory<T> where T : class,new()
    {
        public static T InitInstance(T obj)
        {
            if ("1" == "2")
            {
                return obj;
            }
            return default(T);
        }
    }
    public class Company
    {
        public string id { get; set; }
        public string name { get; set; }
    }
    //public class User
    //{
    //    public string username { get; set; }
    //    public string companyid { get; set; }
    //}
}
