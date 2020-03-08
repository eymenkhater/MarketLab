using DataCrawler.ResourceWorkers;

namespace DataCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            A101Worker.Start();
            // MigrosWorker.Start();
            // CarrefoursaWorker.Start();
        }
    }
}
