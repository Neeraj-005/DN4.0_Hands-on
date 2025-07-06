using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RetailInventory.Data;
using RetailInventory.Models;
using System.Threading.Tasks;


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var connectionString = configuration.GetConnectionString("DefaultConnection");

var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
optionsBuilder.UseSqlServer(connectionString);

using var context = new AppDbContext(optionsBuilder.Options);
await UpdateDataAsync(context);




static async Task SeedDataAsync(AppDbContext context)
{
        var electronics = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Electronics");
        var groceries = await context.Categories.FirstOrDefaultAsync(c => c.Name == "Groceries");

        var product1 = new Product
        {
            Name = "Mechanical Keyboard",
            Price = 5000,
            StockQuantity = 37,
            Category = electronics
        };
        var product2 = new Product
        {
            Name = "Butter",
            Price = 600,
            StockQuantity=200,
            Category = groceries
        };

        await context.Products.AddRangeAsync(product1, product2);
        await context.SaveChangesAsync();

        Console.WriteLine("Products inserted successfully.");
    }




static async Task RetriveDataAsync(AppDbContext context)
{
    var products = await context.Products.ToListAsync();
    foreach (var p in products)
        Console.WriteLine($"{p.Name} - {p.Price}");

    var product = await context.Products.FindAsync(1);
    Console.WriteLine($"Found: {product?.Name}");

    var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
    Console.WriteLine($"Expensive: {expensive?.Name}");

}

static async Task UpdateDataAsync(AppDbContext context)
{
    var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Ghee");
    if (product != null)
        {
            product.StockQuantity = 800;
            await context.SaveChangesAsync();
        }
}
static async Task DeleteDataAsync(AppDbContext context)
{
    var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Electronics");
    if (toDelete != null)
        {
            context.Products.Remove(toDelete);
            await context.SaveChangesAsync();
        }

}

static async Task LinqQueriesAsync(AppDbContext context)
{
    var filtered = await context.Products
    .Where(p => p.Price > 1000)
    .OrderByDescending(p => p.Price)
    .ToListAsync();
    Console.WriteLine("Filtered Product Based on thier Price");
    foreach(var p in filtered)
        Console.WriteLine($"{p.Name} - {p.Price}");
    Console.WriteLine("\n");
    var productDTOs = await context.Products
    .Select(p => new { p.Name, p.Price })
    .ToListAsync();
    Console.WriteLine("DTO Examples");
    foreach (var dto in productDTOs)
    {
        Console.WriteLine($"{dto.Name} - {dto.Price}");
    }

}