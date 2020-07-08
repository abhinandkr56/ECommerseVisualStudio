using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductsWithTypesandBrandsSpecification:BaseSpecification<Product>
    {
        public ProductsWithTypesandBrandsSpecification(string sort)
        {
            AddInclude(X => X.ProductType);
            AddInclude(X => X.ProductBrand);
            AddOrderBy(x => x.Name);
            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDes":
                        AddOrderByDesc(p => p.Price);
                        break;
                    default:
                        AddOrderBy(n => n.Name);
                        break;
                }
            }
        }
        public ProductsWithTypesandBrandsSpecification(int id):base(x=>x.Id==id)
        {
            AddInclude(X => X.ProductType);
            AddInclude(X => X.ProductBrand);
        }
    }
}
