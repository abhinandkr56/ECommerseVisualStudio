using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductwithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductwithFiltersForCountSpecification(ProductSpecParams productSpecParams)
            : base(x => (!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) &&
             (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {

        }
    }
}
