using Odyssey.Liftoff;
using SpotifyWeb;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHttpClient<SpotifyService>();

builder
    .Services
    .AddGraphQLServer()
    .AddApolloFederationV2()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .RegisterService<SpotifyService>();

builder
    .Services
    .AddCors(options =>
    {
        options.AddDefaultPolicy(builder =>
        {
            builder
                .WithOrigins("https://studio.apollographql.com")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
    });

var app = builder.Build();

app.UseCors();

app.MapGraphQL();

app.Run();
