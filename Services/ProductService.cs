using Inventory.Api.Data;
using Inventory.Api.Models;

namespace Inventory.Api.Services;

public class ProductService : IproductService
{
    private readonly InventoryDbContext _context;

    public ProductService(InventoryDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll()
    {
        return _context.Products.ToList();
    }

    public Product? GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public Product Create(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public void update(Product product)
    {
        var existingProduct = GetById(product.Id);
        if (existingProduct != null)
        {
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.Quantity = product.Quantity;
            _context.SaveChanges();
        }
    }

    public void delete(int id)
    {
        var product = GetById(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            _context.SaveChanges();
        }
    }
}
