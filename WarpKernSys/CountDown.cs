using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WarpKernSys
{
    internal class CountDown
    {
        Timer timer;
        public int countdown { get; set; }
        public CountDown(int countdown)
        {
            this.countdown = countdown;
        }

        public void StartTimer(CancellationTokenSource cts)
        {
            while (!cts.IsCancellationRequested)
            {
                timer = new Timer(WriteTime!, null, 3000, 1000);
                while (countdown > 0)
                {
                    countdown--;
                    Thread.Sleep(1000);
                }
                timer.Dispose();
            }
        
        }
        void WriteTime(object data)
        {
            if (countdown == 0)
            {
                Console.WriteLine("Time out");
            }
        }
    }
}

