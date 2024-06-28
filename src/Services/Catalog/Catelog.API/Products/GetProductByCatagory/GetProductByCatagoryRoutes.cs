using OpenTelemetry.Trace;

namespace Catelog.API.Products.GetProductByCatagory
{
    public record GetProductByCatagoryResponse(IEnumerable<Product> Products);
    public class GetProductByCatagoryRoutes : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/products/category/{category}", async (string category, ISender sender) =>
            {
                var result = await sender.Send(new GetProductByCatagoryQuery(category));
                var response = result.Adapt<GetProductByCatagoryResponse>();
                return Results.Ok(response);
            }).
            WithName("GetProductByCatagory")
            .Produces<GetProductByCatagoryResponse>(StatusCodes.Status200OK)
            .ProducesProblem(StatusCodes.Status400BadRequest)
            .WithSummary("Get Product By Catagory")
            .WithDescription("Get Product By Catagory"); ;
        }
    }
}
