using Microsoft.Azure.WebJobs;

namespace WebApp.WebJob
{
    class Program
    {
        static void Main(string[] args)
        {
            JobHost host = new JobHost();
            host.RunAndBlock();
        }
    }
}
