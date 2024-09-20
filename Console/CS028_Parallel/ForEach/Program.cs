using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace ForEach
{
    class Program
    {
        //In thông tin, Task ID và thread ID đang chạy
        public static void PintInfo(string info) => 
        Console.WriteLine($"{info, 10}    task:{Task.CurrentId,3}    " + $"thread: {Thread.CurrentThread.ManagedThreadId}");
        
        public static async void RunTask(string s)  {
            PintInfo($"Start {s,10}"); 
            await Task.Delay(1);                 // Task.Delay là một async nên có thể await, RunTask chuyển điểm gọi nó tại đây 
            PintInfo($"Finish {s,10}");   
        }

        public static void ParallelFor() {
            
            string[] source = new string[] {"xuanthulab1","xuanthulab2","xuanthulab3",
                                            "xuanthulab4","xuanthulab5","xuanthulab6",
                                            "xuanthulab7","xuanthulab8","xuanthulab9"};
            // Dùng List thì khởi tạo
            // List<string> source = new List<string>();
            // source.Add("xuanthulab1");
 

            ParallelLoopResult result = Parallel.ForEach(
                source, RunTask
            ); 

            Console.WriteLine($"All task started: {result.IsCompleted}"); 
        }

        // Parallel.ForEach(_profilesDriver, (profile, state, index) =>
        // {
        //     Console.WriteLine("Start Close profile: " + index);
        //     profile.Dispose();
        //     Console.WriteLine("End Close profile: " + index);
        // });

        // Parallel.ForEach(profileModels, profile => 
        // {
        //     // Start the asynchronous method within a task.
        //     Task.Run(() => StartProfile(profile)).Wait();
        // });
        static void Main(string[] args)
        {
            ParallelFor();
            Console.WriteLine("Press any key ..."); 
            Console.ReadKey(); 
        }
    }
}
