using AdventureWorks.DbModel;
using AdventureWorksApiService.Model;
using AdventureWorksApiService.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Serilog;

namespace AdventureWorkWebApi.Controllers
{
    public class ProductController : ApiController
    {
        private ILogger _logger;
        public ProductController()
        {
            _logger = new LoggerConfiguration()
    .WriteTo.File(System.Web.Hosting.HostingEnvironment.MapPath("~/Logs/log.txt"))
    .CreateLogger();
            _logger.Information("It is working333!!");
        }
        public List<ProductDto> GetAll()
        {
            try
            {
                ProductService prodServ = new ProductService();
                var allproducts = prodServ.GetAllProducts();
                _logger.Information("Get all products");
                return allproducts;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public ProductDto GetById(int id)
        {
            try
            {
                ProductService prodServ = new ProductService();
                var allproducts = prodServ.GetById(id);
                _logger.Information("Get by id");
                return allproducts;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        [Route("api/product/create")]
        public void Create(ProductDto productDto)
        {
            try
            {
                ProductService prodServ = new ProductService();
                prodServ.Create(productDto);
                _logger.Information("New product created");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw ex;
            }
        }

        [Route("api/product/update")]
        public void Update(ProductDto productDto)
        {
            try
            {
                ProductService prodServ = new ProductService();
                prodServ.Update(productDto);
                _logger.Information("Product updated");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw ex;
            }
        }

        [Route("api/product/delete")]
        public void Delete(int prodId)
        {
            try
            {
                ProductService prodServ = new ProductService();
                prodServ.Remove(prodId);
                _logger.Information("Product deleted");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw ex;
            }
        }


    }
}
