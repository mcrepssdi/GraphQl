using GraphQL.Client.Abstractions;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQLTest;
using WorkerService1;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        IHostEnvironment hostEnv = hostContext.HostingEnvironment;
        string url = hostContext.Configuration["GraphQLURI"] ?? string.Empty;
        
        services.AddSingleton<IGraphQLClient>(s => new GraphQLHttpClient( url, new NewtonsoftJsonSerializer()));
        services.AddSingleton<OwnerConsumer>();

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();