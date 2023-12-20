using Azure;
using Microsoft.EntityFrameworkCore;
using POS.Data;
using POS.Data.Entities;
using POS.Models.DTO;
using POS.Repositories.Abstract;
using ProductType = POS.Models.DTO.ProductType;

namespace POS.Repositories.Implementation
{
    public class ProductService(DataContext dataContext): IProductService
    {
        private readonly DataContext _dataContext = dataContext;

        public async Task<DataStatus<ProductModel>> Create(ProductModel model)
        {
            var response = new DataStatus<ProductModel>();
            try
            {
                Product product = new Product()
                {
                    Name = model.Name,
                    Price = model.Price,
                    ProductTypeId = (int)model.ProductType
                };

                _dataContext.Products.Add(product);
                _dataContext.SaveChanges();

                model.Id = product.Id;
                response.Data = model;
                response.status = true;
                response.Message = "Successfully Created";
            }
            catch (Exception)
            {
                response.status = false;
                response.Message = "Error while creating product";
            }

            return response;
        }

        public async Task<DataStatus<ProductModel>> Update(ProductModel model)
        {
            var response = new DataStatus<ProductModel>();
            try
            {
                var product = _dataContext.Products.Where(x => x.Id == model.Id).First();

                product.Name = model.Name;
                product.Price = model.Price;
                product.ProductTypeId = (int)model.ProductType;


                _dataContext.Products.Update(product);
                _dataContext.SaveChanges();

                response.Data = model;
                response.status = true;
                response.Message = "Successfully Updated";
            }
            catch (Exception)
            {
                response.status = false;
                response.Message = "Error while updating product";
            }

            return response;
        }


        public async Task<List<ProductModel>> Products()
        {
            var response = (from p in _dataContext.Products
                            select new ProductModel
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Price = p.Price,
                                ProductType = (ProductType)p.ProductTypeId
                            }).ToList();
            return response;
        }

        public async Task<OrderModel> Bill(List<OrderProductModel> model)
        {
            OrderModel response = new OrderModel();
            for(int i = 0; i < model.Count; i++)
            {
               var obj = await _dataContext.Products.Where(x => x.Id == model[i].ProductId).FirstAsync();
                model[i].Name  = obj.Name;
                model[i].UnitPrice = obj.Price;
            }

            Orders order = new Orders()
            {
                EnteredDate = DateTime.Now,
            };

            _dataContext.Orders.Add(order);

            foreach (var item in model) 
            {
                OrderDetail orderDetail = new OrderDetail()
                {
                    ProductName = item.Name,
                    Quantity = item.Quantity,
                    UnitPrice = item.UnitPrice.Value,
                    Orders = order
                };

                _dataContext.OrderDetails.Add(orderDetail);
            }

            _dataContext.SaveChanges();

            response.OrderProduct = model;
            response.OrderId = order.Id;
            return response;
        }

        public bool Delete(int id)
        {
            try
            {
                var obj = _dataContext.Products.Where(x => x.Id == id).First();
                _dataContext.Products.Remove(obj);
                _dataContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
