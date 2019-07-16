using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Threading;

using System.IO;
namespace oop15
{
    class Program
    {
        public static object o = new object();
        public static void Thread1()//2
        {
            using (StreamWriter st = new StreamWriter(@"C:/Users/veranikalabovich/source/repos/Thread1.txt", true, System.Text.Encoding.Default))
            {
                for (int i = 1; i <= 10; i++)    
                {
                    Console.WriteLine(i);
                    st.WriteLine(i);
                    if (i == 2) Console.WriteLine("Name " + Thread.CurrentThread.Name);
                    if (i == 4) Console.WriteLine("Id " + Thread.CurrentThread.ManagedThreadId);
                    if (i == 6) Console.WriteLine("Status " + Thread.CurrentThread.ThreadState);
                    if (i == 8) Console.WriteLine("Priority " + Thread.CurrentThread.Priority);
                    Thread.Sleep(1000);
                }
            }
        }
        public static void Thread2()//нечетные
        {
            lock (o)
            {
                using (StreamWriter st = new StreamWriter(@"C:/Users/veranikalabovich/source/repos/Thread2.txt", true, System.Text.Encoding.Default))
                {
                    for (int i = 1; i <= 10; i += 2)
                    {
                        Console.WriteLine(i);
                        st.WriteLine(i);

                        Thread.Sleep(1000);
                    }
                }
            }
        }
        public static void Thread3()//вывод четныйх знач
        {
            lock (o)
            {
                using (StreamWriter st = new StreamWriter(@"C:/Users/veranikalabovich/source/repos/Thread2.txt", true, System.Text.Encoding.Default))
                {
                    for (int i = 2; i <= 10; i += 2)
                    {
                        Console.WriteLine(i);
                        st.WriteLine(i);

                        Thread.Sleep(1000);
                    }
                }
            }
        }
        public static void Thread4()//4
        {



            for (int i = 1; i <= 10; i += 2)
            {
                lock (o)
                {
                    using (StreamWriter st = new StreamWriter(@"C:/Users/veranikalabovich/source/repos/Thread3.txt", true, System.Text.Encoding.Default))
                    {
                        Console.WriteLine(i);
                        st.WriteLine(i);

                        Thread.Sleep(1000);
                    }
                }
            }


        }
        public static void Count(object obj)
        {
            int x = (int)obj;
            for (int i = 1; i < 2; i++, x++)
            {
                Console.WriteLine("Timer rabotaet");
            }
        }
        public static void Thread5()
        {



            for (int i = 2; i <= 10; i += 2)
            {
                lock (o)
                {
                    using (StreamWriter st = new StreamWriter(@"C:/Users/veranikalabovich/source/repos/Thread3.txt", true, System.Text.Encoding.Default))
                    {
                        Console.WriteLine(i);
                        st.WriteLine(i);

                        Thread.Sleep(1000);
                    }
                }
            }


        }
        static void Main(string[] args)
        {
            Process[] p = Process.GetProcesses();
            try
            {
                foreach (Process x in p)//1
                {
                    Console.WriteLine("Id: " + x.Id);
                    Console.WriteLine("Name: " + x.ProcessName);
                    Console.WriteLine("Priority: " + x.BasePriority);
                    Console.WriteLine("Timeto start: " + x.StartTime);
                    Console.WriteLine("Sostoianie: " + x.Responding);

                }
            }
            catch
            {

            }
            finally
            {
                AppDomain a = AppDomain.CurrentDomain;
                Console.WriteLine("Name: " + a.FriendlyName);
                Assembly[] asm = a.GetAssemblies();
                foreach (Assembly x in asm)
                {
                    Console.WriteLine(x.FullName);
                }
                a = AppDomain.CreateDomain("MyDomain");
                a.Load(asm[0].FullName);
                AppDomain.Unload(a);
                Thread th1 = new Thread(new ThreadStart(Thread1));
                th1.Start();
                Thread.Sleep(9000);
                Thread th2 = new Thread(new ThreadStart(Thread2));
                Thread th3 = new Thread(new ThreadStart(Thread3));
                th3.Priority = ThreadPriority.Highest;
                th2.Start();
                th3.Start();
                Thread.Sleep(9000);
                Thread th4 = new Thread(new ThreadStart(Thread4));
                Thread th5 = new Thread(new ThreadStart(Thread5));
                th4.Start();
                th5.Start();

            }

            Console.WriteLine("Timer");
            int num = 0;
            // устанавливаем метод обратного вызова
            TimerCallback tm = new TimerCallback(Count);
            // создаем таймер
            Timer timer = new Timer(tm, num, 0, 5000);

            Console.ReadKey();
        }

    }

}
