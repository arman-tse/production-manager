using AdventureWorks.DbModel;
using AdventureWorksApiService.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksApiService.Services
{
    public class ProductService
    {
        private readonly AdventureWorks.DbModel.Entities _entities = new AdventureWorks.DbModel.Entities();
        public ProductService()
        {
        }
        public List<ProductDto> GetAllProducts()
        {
            var query = from d in _entities.Products
                        select new ProductDto
                        {
                            ProductID = d.ProductID,
                            Name = d.Name,
                            ProductNumber = d.ProductNumber
                        };

            return query.ToList();
        }

        public ProductDto GetById(int paramId)
        {
            var query = from d in _entities.Products
                        where d.ProductID == paramId
                        select new ProductDto
                        {
                            ProductID = d.ProductID,
                            Name = d.Name,
                            ProductNumber = d.ProductNumber,
                            SellStartDate = d.SellStartDate,
                            rowguid = d.rowguid,
                            SafetyStockLevel = d.SafetyStockLevel,
                            ReorderPoint = d.ReorderPoint,
                            StandardCost = d.StandardCost,
                            ListPrice = d.ListPrice,
                            DaysToManufacture = d.DaysToManufacture
                        };

            return query.FirstOrDefault();
        }

        public void Create(ProductDto newProd)
        {
            var newProdEntity = new Product
            {
                ProductID = newProd.ProductID,
                Name = newProd.Name,
                ProductNumber = newProd.ProductNumber,
                MakeFlag = newProd.MakeFlag,
                FinishedGoodsFlag = newProd.FinishedGoodsFlag,
                Color = newProd.Color,
                SellStartDate = newProd.SellStartDate,
                rowguid = System.Guid.NewGuid(),
                ModifiedDate = DateTime.Now,
                SafetyStockLevel = newProd.SafetyStockLevel,
                ReorderPoint = newProd.ReorderPoint,
                StandardCost = newProd.StandardCost,
                ListPrice = newProd.ListPrice,
                DaysToManufacture = 2


            };
            using (var ctx = new AdventureWorks.DbModel.Entities())
            {
                ctx.Products.Add(newProdEntity);
                ctx.SaveChanges();
            }
        }

        public void Update(ProductDto updProd)
        {
            using (var ctx = new AdventureWorks.DbModel.Entities())
            {
                var updItem = ctx.Products.FirstOrDefault(o => o.ProductID == updProd.ProductID);
                if (updItem != null)
                {
                    updItem.Name = updProd.Name;
                    updItem.ProductNumber = updProd.ProductNumber;
                    updItem.MakeFlag = updProd.MakeFlag;
                    updItem.FinishedGoodsFlag = updProd.FinishedGoodsFlag;
                    updItem.Color = updProd.Color;
                    updItem.SellStartDate = updProd.SellStartDate;
                    updItem.ModifiedDate = DateTime.Now;
                    updItem.SafetyStockLevel = updProd.SafetyStockLevel;
                    updItem.ReorderPoint = updProd.ReorderPoint;
                    updItem.StandardCost = updProd.StandardCost;
                    updItem.ListPrice = updProd.ListPrice;
                    updItem.DaysToManufacture = 2;
                }

                ctx.SaveChanges();
            }
        }

        public void Remove(int id)
        {
            using (var ctx = new AdventureWorks.DbModel.Entities())
            {
                var updItem = ctx.Products.FirstOrDefault(o => o.ProductID == id);
                if (updItem != null)
                {
                    ctx.Products.Remove(updItem);
                    ctx.SaveChanges();
                }

                
            }

        }
    }
}
