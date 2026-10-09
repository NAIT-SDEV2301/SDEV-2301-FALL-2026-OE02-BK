using ProductQueryService;

namespace ProductQueryService.Tests;

public class ProductQueryServiceTests
{
    private readonly ProductQueryService  _service = new();

    private static List<Product> CreateProducts() =>
    [
        new Product { Name = "Apples", Price = 3.50m, IsDiscontinued = false },
        new Product { Name = "Bananas", Price = 2.00m, IsDiscontinued = true },
        new Product { Name = "Oranges", Price = 3.50m, IsDiscontinued = false },
        new Product { Name = "Dates", Price = 1.25m, IsDiscontinued = false }
    ];

    [Fact]
    public void GetActiveProducts_WhenProductsMixed_ReturnsOnlyActiveProducts()
    {
        // Arrange
        var products = CreateProducts();

        // Act
        var result = _service.GetActiveProducts(products).ToList();

        // Assert
        Assert.Equal(new[] { "Apples", "Oranges", "Dates" },
            result.Select(product => product.Name).ToList());
        Assert.All(result, product => Assert.False(product.IsDiscontinued));
    }

    [Fact]
    public void GetActiveProducts_WhenNoProducts_ReturnsEmptyCollection()
    {
        var result = _service.GetActiveProducts(Array.Empty<Product>());

        Assert.Empty(result);
    }

    [Fact]
    public void GetActiveProducts_WhenProductsIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => _service.GetActiveProducts(null!));
    }

    [Fact]
    public void SortByPrice_SortsByPriceThenNameForDeterministicOrder()
    {
        var products = CreateProducts();

        var result = _service.SortByPrice(products).ToList();

        Assert.Equal(
            new[] { ("Dates", 1.25m), ("Bananas", 2.00m),
                    ("Apples", 3.50m), ("Oranges", 3.50m) },
            result.Select(product => (product.Name, product.Price)).ToList());
    }

    [Fact]
    public void SortByPrice_WhenProductsIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => _service.SortByPrice(null!));
    }

    [Fact]
    public void ProjectForListView_ReturnsNameAndPriceTuplesInInputOrder()
    {
        var products = new List<Product>
        {
            new() { Name = "Apples", Price = 3.50m },
            new() { Name = "Bananas", Price = 2.00m }
        };

        var result = _service.ProjectForListView(products).ToList();

        Assert.Equal(
            new[] { ("Apples", 3.50m), ("Bananas", 2.00m) },
            result);
    }

    [Fact]
    public void ProjectForListView_WhenProductsIsNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(
            () => _service.ProjectForListView(null!));
    }

    [Fact]
    public void QueryMethods_DoNotMutateInputCollection()
    {
        var products = CreateProducts();
        var originalNames = products.Select(product => product.Name).ToList();

        _service.GetActiveProducts(products);
        _service.SortByPrice(products);
        _service.ProjectForListView(products);

        Assert.Equal(originalNames, products.Select(product => product.Name).ToList());
    }
}
