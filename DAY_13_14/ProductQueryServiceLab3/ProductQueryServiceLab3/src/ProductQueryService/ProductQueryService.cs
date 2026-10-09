namespace ProductQueryService;

public class ProductQueryService
{
    public IEnumerable<Product> GetActiveProducts(IEnumerable<Product> products)
    {
        ArgumentNullException.ThrowIfNull(products);

        return products
            .Where(product => !product.IsDiscontinued)
            .ToList();
    }

    public IEnumerable<Product> SortByPrice(IEnumerable<Product> products)
    {
        ArgumentNullException.ThrowIfNull(products);

        return products
            .OrderBy(product => product.Price)
            .ThenBy(product => product.Name)
            .ToList();
    }

    public IEnumerable<(string Name, decimal Price)> ProjectForListView(
        IEnumerable<Product> products)
    {
        ArgumentNullException.ThrowIfNull(products);

        return products
            .Select(product => (product.Name, product.Price))
            .ToList();
    }
}
