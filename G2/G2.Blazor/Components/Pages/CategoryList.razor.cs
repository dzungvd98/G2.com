using G2.Blazor.DTO;
using G2.Blazor.Enum;
using Microsoft.AspNetCore.Components;
using System;

namespace G2.Blazor.Components.Pages
{
    public partial class CategoryList
    {
        public string Search { set; get; }
        public List<Category> Categories { get; set; }
        public SortByEnum SortBy { get; set; }
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Electronics",
                    Link = "https://example.com/SubCategories/electronics",
                    Quantity = 500,
                    SubCategories = Enumerable.Range(101, 15).Select(i => new Category
                    {
                        Id = i,
                        Name = $"SubCategory {i} (Electronics)",
                        Link = $"https://example.com/SubCategories/electronics-{i}",
                        Quantity = new Random().Next(50, 200),
                        SubCategories = null
                    }).ToList()
                },
                new Category
                {
                    Id = 2,
                    Name = "Fashion",
                    Link = "https://example.com/SubCategories/fashion",
                    Quantity = 600,
                    SubCategories = Enumerable.Range(201, 12).Select(i => new Category
                    {
                        Id = i,
                        Name = $"SubCategory {i} (Fashion)",
                        Link = $"https://example.com/SubCategories/fashion-{i}",
                        Quantity = new Random().Next(30, 150),
                        SubCategories = null
                    }).ToList()
                },
                new Category
                {
                    Id = 3,
                    Name = "Home Appliances",
                    Link = "https://example.com/SubCategories/home-appliances",
                    Quantity = 400,
                    SubCategories = Enumerable.Range(301, 10).Select(i => new Category
                    {
                        Id = i,
                        Name = $"SubCategory {i} (Home Appliances)",
                        Link = $"https://example.com/SubCategories/home-appliances-{i}",
                        Quantity = new Random().Next(20, 100),
                        SubCategories = null
                    }).ToList()
                },
                new Category
                {
                    Id = 4,
                    Name = "Sports",
                    Link = "https://example.com/SubCategories/sports",
                    Quantity = 450,
                    SubCategories = Enumerable.Range(401, 13).Select(i => new Category
                    {
                        Id = i,
                        Name = $"SubCategory {i} (Sports)",
                        Link = $"https://example.com/SubCategories/sports-{i}",
                        Quantity = new Random().Next(40, 160),
                        SubCategories = null
                    }).ToList()
                },
                new Category
                {
                    Id = 5,
                    Name = "Books",
                    Link = "https://example.com/SubCategories/books",
                    Quantity = 700,
                    SubCategories = Enumerable.Range(501, 11).Select(i => new Category
                    {
                        Id = i,
                        Name = $"SubCategory {i} (Books)",
                        Link = $"https://example.com/SubCategories/books-{i}",
                        Quantity = new Random().Next(10, 120),
                        SubCategories = null
                    }).ToList()
                }
            };

        }
        private void SearchCategopry(ChangeEventArgs s)
        {
            Categories = new List<Category>();
        }

        private void FilterCategories(ChangeEventArgs s)
        {

            if (s.Value.ToString() == nameof(SortByEnum.AZ))
            {
                
                foreach (var category in this.Categories) 
                {
                    category.SubCategories = category.SubCategories.OrderBy(sc => sc.Name).ToList();
                }

                this.Categories = this.Categories.OrderBy(c => c.Name).ToList();
            }

            if (s.Value.ToString() == nameof(SortByEnum.ZA))
            {
                foreach (var category in this.Categories)
                {
                    category.SubCategories = category.SubCategories.OrderByDescending(sc => sc.Name).ToList();
                }

                this.Categories = this.Categories.OrderByDescending(c => c.Name).ToList();
            }

        }
    }
}
