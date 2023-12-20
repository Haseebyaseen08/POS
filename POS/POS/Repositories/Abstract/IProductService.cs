using POS.Models.DTO;

namespace POS.Repositories.Abstract
{
    public interface IProductService
    {
        Task<List<ProductModel>> Products();

        Task<DataStatus<ProductModel>> Create(ProductModel model);

        Task<DataStatus<ProductModel>> Update(ProductModel model);

        Task<List<OrderProductModel>> Bill(List<OrderProductModel> model);

        bool Delete(int id);
    }
}
