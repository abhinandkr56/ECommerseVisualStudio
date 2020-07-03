using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductsWithTypesandBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithTypesandBrandsSpecification()
        {
            AddInclude(X => X.ProductType);
            AddInclude(X => X.ProductBrand);
        }
        public ProductsWithTypesandBrandsSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(X => X.ProductType);
            AddInclude(X => X.ProductBrand);
        }
    }
}
