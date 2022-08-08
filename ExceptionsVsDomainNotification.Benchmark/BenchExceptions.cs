using BenchmarkDotNet.Attributes;

namespace ExceptionsVsDomainNotification.Benchmark
{
    [MemoryDiagnoser]
    public class BenchExceptions
    {
        [Params("goodRequest", "badRequest")]
        public string Type { get; set; } = "goodRequest";

        [Benchmark]
        public bool Notification()
        {
            if (Type == "goodRequest")
            {
                return true;
            }

            return false;
        }

        [Benchmark]
        public bool ExceptionThrow()
        {
            if (Type == "goodRequest")
            {
                return true;
            }

            try
            {
                throw new Exception("Something went wrong.");
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
