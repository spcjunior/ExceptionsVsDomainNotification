using BenchmarkDotNet.Attributes;
using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http.Json;

namespace ExceptionsVsDomainNotification.Benchmark
{
    [MemoryDiagnoser]
    public class BenchExceptionsApi
    {
        private const double ChangeOfFailure = 0.5;
        private readonly Random _exceptionRandom = new(420);
        private readonly Random _notificationRandom = new(420);

        private static readonly WebApplicationFactory<ExceptionApi.Startup> ExceptionFactory = new();
        private static readonly WebApplicationFactory<NotificationApi.Startup> NotificationFactory = new();

        private static readonly HttpClient ExceptionHttpClient = ExceptionFactory.CreateClient();
        private static readonly HttpClient NotificationHttpClient = NotificationFactory.CreateClient();

        private static readonly ExceptionApi.Models.UserRequest GoodException = new("mario@gmail.com", "123456");
        private static readonly ExceptionApi.Models.UserRequest BadException = new("mario@gmail", "123456");

        private static readonly NotificationApi.Models.UserRequest GoodNotification = new("mario@gmail.com", "123456");
        private static readonly NotificationApi.Models.UserRequest BadNotification = new("mario@gmail", "123456");

        [Benchmark]
        public async Task<HttpResponseMessage> ExceptionVersion()
        {            
            if (_exceptionRandom.NextDouble() >= ChangeOfFailure)
            {
                return await ExceptionHttpClient.PostAsJsonAsync("/User/login", BadException);
            }
            return await ExceptionHttpClient.PostAsJsonAsync("/User/login", GoodException);
        }

        [Benchmark]
        public async Task<HttpResponseMessage> NotificationVersion()
        {            
            if (_notificationRandom.NextDouble() >= ChangeOfFailure)
            {
                return await NotificationHttpClient.PostAsJsonAsync("/User/login", BadNotification);
            }
            return await NotificationHttpClient.PostAsJsonAsync("/User/login", GoodNotification);
        }
    }
}
