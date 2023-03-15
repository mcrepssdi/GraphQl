using GraphQLTest;

namespace WorkerService1;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly OwnerConsumer _consumer;

    public Worker(ILogger<Worker> logger, OwnerConsumer consumer)
    {
        _logger = logger;
        _consumer = consumer;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            List<Carrier> carriers = await _consumer.GetCarriers();
            
            carriers.ForEach(p =>
            {
                _logger.LogInformation(p.ToString());
            });
            await Task.Delay(5000, stoppingToken);
            
            List<Amaster> accounts = await _consumer.GetAccounts("123456");
            
        }
    }
}