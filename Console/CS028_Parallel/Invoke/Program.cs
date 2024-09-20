using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Invoke
{
    class Program
    {
        //In thông tin, Task ID và thread ID đang chạy
        public static void PintInfo(string info) => 
        Console.WriteLine($"{info, 10}    task:{Task.CurrentId,3}    " + $"thread: {Thread.CurrentThread.ManagedThreadId}");
        
        public static async void RunTask(string s)  {
            PintInfo($"Start {s,10}"); 
            await Task.Delay(1);           
            PintInfo($"Finish {s,10}");   
        }

        public static void actionA() {
            PintInfo($"Finish {"ActionA",10}");  
        }

        public static void actionB() {
            Task.Delay(1000).Wait();          // Task dừng 1s - rồi mới chạy tiếp
            PintInfo($"Finish {"ActionB",10}");  
        }


        public static void ParallelInvoke() {
            Action action1  = () => {
                RunTask("Action1");
            };

            Parallel.Invoke(action1, actionA, actionB);
        }
        static void Main(string[] args)
        {
            ParallelInvoke();
            Console.WriteLine("Press any key ..."); 
            Console.ReadKey(); 
        }
    }
}
