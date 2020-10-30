using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadingExamples
{
    class Program
    {

        static void Main(string[] args)
        {
            (new ThreadCreation()).CreateSomeThreads();
        }


    }
}
