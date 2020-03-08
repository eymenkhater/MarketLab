using DataCrawler.ResourceWorkers;

namespace DataCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            MigrosWorker.Start();
            // CarrefoursaWorker.Start();
        }
    }
}
