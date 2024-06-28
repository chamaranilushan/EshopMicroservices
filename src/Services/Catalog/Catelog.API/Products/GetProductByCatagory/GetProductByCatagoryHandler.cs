
namespace Catelog.API.Products.GetProductByCatagory
{
    public record GetProductByCatagoryQuery(string Category) : IQuery<GetProductByCatagoryResult>;
    public record GetProductByCatagoryResult(IEnumerable<Product> Products);
    internal class GetProductByCatagoryQueryHandler(IDocumentSession session) 
        : IQueryHandler<GetProductByCatagoryQuery, GetProductByCatagoryResult>
    {
        public async Task<GetProductByCatagoryResult> Handle(GetProductByCatagoryQuery query, CancellationToken cancellationToken)
        {

            var products = await session.Query<Product>()
                        .Where(p => p.Category.Contains(query.Category))
                        .ToListAsync(cancellationToken);
            return new GetProductByCatagoryResult(products);
        }
    }
}
