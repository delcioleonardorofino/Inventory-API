using Inventory.Api.Models;

namespace Inventory.Api.Services;

public interface IproductService
{
    List<Product> GetAll();
    Product? GetById(int id);
    Product Create(Product product);
    void update(Product product);
    void delete(int id);
}