﻿using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICatalogBrandRepository
    {
        Task<int> Create(string title);
        Task<int> Update(int id, string title);
        Task<int> Delete(int id);
        Task<IEnumerable<CatalogBrand>> GetBrandsAsync();
    }
}
