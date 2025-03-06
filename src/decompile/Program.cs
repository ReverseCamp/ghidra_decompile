using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace decompile
{
    internal class Program
    {
        private static DataUnderlyingPipeManager _manager;
        private static Stream _in = Console.OpenStandardInput();
        private static Queue<TaskCommand> taskqueue { get; set; } = new Queue<TaskCommand>();
        private static FileStream _fs = new FileStream("d:\\Desktop\\decompile.log", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        private static void init()
        {
            if(_manager == null)
            {
                _manager = new DataUnderlyingPipeManager();
            }
        }
        
        static void Main(string[] args)
        {
            init();
            Task.Run(() =>
            {
                while (true) 
                {
                    Thread.Sleep(1000);
                    var tc = taskqueue.Dequeue();
                    if (tc != null)
                    {

                    }
                }
            });

            while (true)
            {
                Doread();
            }

            Console.ReadLine();
        }

        static async void Doread()
        {
            byte[] buffer = new byte[1024];
            await _in.ReadAsync(buffer, 0, 1024);

            taskqueue.Enqueue(new TaskCommand(
                buffer,
                false,
                0,
                0
                ));
            _fs.Write(buffer, 0, buffer.Length);
            _fs.Flush();
        }

        static async void DoIt(int i)
        {
            ITaskReuslt result = await _manager.RunAsync(new IRPContext(i.ToString()));
            Console.WriteLine(result);
        }
    }
}
