using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RadixDlt.NetworkGateway.Endpoints;
using RadixGatewayApi.Generated.Model;

namespace RadixDlt.NetworkGateway.Configuration;

public static class EndpointRouteBuilderExtensions
{
    public static void MapNetworkGatewayApi(this IEndpointRouteBuilder endpoints)
    {
        // TODO make endpoints configurable?
        // TODO or maybe use fully-fledged MVC controllers and actions due to their superior capabilities?

        endpoints.MapPost("/test1", () => "test1");
        endpoints.MapPost("/test2", (GatewayEndpoint ge, [FromBody] TransactionBuildRequest request) => ge.Status(request));
        endpoints.MapPost("/test3", (GatewayEndpoint ge, [FromQuery] int? myInt, CancellationToken token) => ge.Status(myInt, token));
    }
}
