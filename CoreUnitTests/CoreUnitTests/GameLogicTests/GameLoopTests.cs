using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Xunit;

namespace CoreUnitTests
{
    public class GameLoopTests
    {
        private IServiceProvider _testServices;


        public GameLoopTests()
        {
            _testServices = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    services.AddHostedService<Worker>()
                            .AddScoped<IMessageWriter, MessageWriter>());

        }

        [Fact]
        public void NormalRun_ProcessGameTick_ExpectedBehaviour()
        {

        }

    }
}
