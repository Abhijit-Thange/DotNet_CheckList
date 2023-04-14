using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StopWatchProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            StopWatch sw=new StopWatch();
            Console.WriteLine("Press Any Ket to Start Stopwatch...");
            Console.ReadKey();

            sw.start();

            Console.WriteLine("Press Any Ket to Stop Stopwatch...");
            Console.ReadKey();

            sw.stop();
            Console.WriteLine("Total Time = "+ sw.ElapsedTime);
            Console.ReadLine();

        }
    }

    public class StopWatch
    {
        private DateTime _startTime;
        private DateTime _endTime;
        private bool _isRunning=false;

        public void start()
        {
           
                if (!_isRunning)
                {
                    _startTime = DateTime.Now;
                    _isRunning = true;
                   // Console.WriteLine("start Time s=" + s.ElapsedTime);
                }
            
            
        }

        public void stop()
        {
            if(_isRunning)
            {
                _endTime = DateTime.Now;
                _isRunning = false;
               // Console.WriteLine("Current Time=" + _endTime);
            }
        }
        public TimeSpan ElapsedTime
        {
            get
            {
                if(_isRunning)
                {
                    return DateTime.Now - _startTime;
                }
                else
                {
                    return _endTime - _startTime;
                }
            }
        }
    }
}
