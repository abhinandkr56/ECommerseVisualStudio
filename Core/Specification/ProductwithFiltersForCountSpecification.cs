﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Specification
{
    public class ProductwithFiltersForCountSpecification : BaseSpecification<Product>
    {
        public ProductwithFiltersForCountSpecification(ProductSpecParams productSpecParams)
            : base(x => (string.IsNullOrEmpty(productSpecParams.Search) || x.Name.ToLower().Contains(productSpecParams.Search))&&(!productSpecParams.BrandId.HasValue || x.ProductBrandId == productSpecParams.BrandId) &&
             (!productSpecParams.TypeId.HasValue || x.ProductTypeId == productSpecParams.TypeId))
        {

        }
    }
}
