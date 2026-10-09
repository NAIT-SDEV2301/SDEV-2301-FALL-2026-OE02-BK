# SDEV2301 — Lab Activity 3: LINQ Query Service + xUnit (TDD-lite)

This .NET 8 solution demonstrates the concepts in the supplied Lab 3 support material:

- A `Product` domain model.
- Moving LINQ logic into a `ProductQueryService`.
- `GetActiveProducts` filtering discontinued products.
- Deterministic sorting with `OrderBy` and `ThenBy`.
- Tuple projection for a list view.
- Guard rails using `ArgumentNullException.ThrowIfNull`.
- xUnit tests using Arrange–Act–Assert (AAA), value/collection assertions, list comparisons, and `Assert.Throws`.
- Avoiding mutation of the input collection.

## Solution structure

```text
ProductQueryServiceLab3/
├── ProductQueryServiceLab3.sln
├── src/
│   └── ProductQueryService/
│       ├── Product.cs
│       ├── ProductQueryService.cs
│       └── ProductQueryService.csproj
└── tests/
    └── ProductQueryService.Tests/
        ├── ProductQueryServiceTests.cs
        └── ProductQueryService.Tests.csproj
```

## Run in Visual Studio

1. Extract the ZIP file.
2. Open `ProductQueryServiceLab3.sln`.
3. Allow NuGet packages to restore.
4. In **Test Explorer**, select **Run All Tests**.

## Run from a terminal

Install the .NET 8 SDK, open a terminal in this folder, and run:

```bash
dotnet restore
dotnet test
```

## Teaching walkthrough

1. **Arrange:** create a known list of `Product` objects.
2. **Act:** call one service method.
3. **Assert:** compare the result with the expected behavior.
4. **RED → GREEN:** temporarily change an expected result in a test and run the tests to see it fail (RED); restore the correct expectation and run again (GREEN). Do not leave the intentionally failing assertion in the final version.
5. **Guard rails:** pass `null!` in a test to verify that each public method fails fast with `ArgumentNullException`.
6. **Deterministic sorting:** `ThenBy(product => product.Name)` ensures products with the same price have a predictable order.
7. **Tuple projection:** the method returns only `(Name, Price)` rather than full `Product` objects.

## Test coverage checklist

- [x] Active products only
- [x] Empty input
- [x] Null guard for active products
- [x] Price sorting with name tie-breaker
- [x] Null guard for sorting
- [x] Tuple projection
- [x] Null guard for tuple projection
- [x] Input collection is not mutated

Note: The solution targets `net8.0`. Tests have not been executed in this environment because the .NET SDK is not installed here; run `dotnet test` locally to verify.
