using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace TaskExamples
{
    class TaskCreation
    {

        public void CreateSomeTasks()
        {

            Console.WriteLine("CreateSomeTasks" + ": " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));

            // method
            Task.Run(MyMethod);


            // static method
            Task.Run(MyStaticMethod);


            // anonymous method
            Task.Run(() =>
            {
                Console.WriteLine("Anonymous method: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
            });


            // method with parameter
            Task task = new Task(MyMethodWithParameter, "Yo");
            task.Start();


            // background worker
            BackgroundWorker worker = new BackgroundWorker();
            worker.DoWork += Worker_DoWork;
            worker.RunWorkerAsync();
        }
       

        void MyMethod()
        {
            Console.WriteLine("MyMethod: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
        }

        static void MyStaticMethod()
        {
            Console.WriteLine("MyStaticMethod: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
        }

        void MyMethodWithParameter(object o)
        {
            Console.WriteLine("MyMethodWithParameter: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-") + ", parameter: " + (o != null ? o.ToString() : "null"));
        }

        void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("BackgroundWorker: " + (Task.CurrentId.HasValue ? Task.CurrentId.Value.ToString() : "-"));
        }

    }
}
