using SMS.Models;
using System.Collections.Generic;

namespace SMS.Contracts
{
    public interface IProductService
    {
        (bool created, string error) CreateProduct(CreateViewModel model);

        IEnumerable<ProductListViewModel> GetProducts();
    }
}