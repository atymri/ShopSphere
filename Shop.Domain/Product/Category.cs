using System;
using System.Collections.Generic;

namespace Shop.Domain.Products
{
    public class Category
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid? ParentCategoryId { get; private set; }
        public List<Category> SubCategories { get; private set; }

        public Category(string name, Guid? parentCategoryId = null)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Id = Guid.NewGuid();
            Name = name;
            ParentCategoryId = parentCategoryId;
            SubCategories = new List<Category>();
        }

        public void Edit(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            Name = name;
        }

        public void AddSubCategory(Category subCategory)
        {
            if (subCategory == null) throw new ArgumentNullException(nameof(subCategory));
            SubCategories.Add(subCategory);
        }
    }
}
