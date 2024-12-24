using G2.Blazor.DTO;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http.HttpResults;

namespace G2.Blazor.Components.Pages
{
    public partial class ProductListPage
    {
        [Parameter]
        public string CategoryName { set; get; }
        public string Search { set; get; } = string.Empty;
        public string FeatureFilter { set; get; } = "0";
        public string BusinessSizeFilter { set; get; } = "0";
        public string PriceFilter { set; get; } = "0";
        public string SortBy { set; get; } = "0";
        public int MaxCompare { set; get; } = 4;
        private bool isProcessing = false;

        public Category CurrentCategory { set; get; }
        public List<Product> Products { set; get; }
        public ProductDetail ProductDetail { set; get; }
        public List<Category> RelatedCategory { set; get; }
        public List<Product> CompareProductList { set; get; }

        public List<ProductDetail> ProductDetailStore = new List<ProductDetail>()
        {
            new ProductDetail
            {
                ProductId = 1,
                Name = "Microsoft Office",
                CategoryName = "Productivity Software",
                Rate = new RateGeneral
                {
                    ProductId = 1,
                    RateNumber = 4.6f,
                    Quantity = 3000
                },
                Description = "A suite of applications designed for productivity, including Word, Excel, and PowerPoint.",
                CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3HzdxgflSXqmsDm4BPPliul-XM5XL-U2qkg&s",
                Link = "https://www.microsoft.com/en-us/microsoft-365", // Đường dẫn tới trang sản phẩm
                ProsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "Comprehensive tools", Quantity = 150 },
                    new ProsCons { Id = 2, Name = "Industry standard", Quantity = 120 },
                    new ProsCons { Id = 3, Name = "Cloud integration", Quantity = 90 }
                },
                ConsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "Subscription-based pricing", Quantity = 50 },
                    new ProsCons { Id = 2, Name = "Resource intensive", Quantity = 30 }
                },
                UserSatisfactionList = new List<UserSatisfaction>
                {
                    new UserSatisfaction { Id = 1, Name = "Ease of use", RateNumber = 4.7f },
                    new UserSatisfaction { Id = 2, Name = "Value for money", RateNumber = 4.5f },
                    new UserSatisfaction { Id = 3, Name = "Feature set", RateNumber = 4.6f }
                }
            },
            new ProductDetail
            {
                ProductId = 2,
                Name = "Adobe Photoshop",
                CategoryName = "Graphic Design",
                Rate = new RateGeneral
                {
                    ProductId = 2,
                    RateNumber = 4.8f,
                    Quantity = 2500
                },
                Description = "The industry standard for photo editing and digital art creation.",
                CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3HzdxgflSXqmsDm4BPPliul-XM5XL-U2qkg&s",
                Link = "https://www.adobe.com/products/photoshop.html", // Đường dẫn tới trang sản phẩm
                ProsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "Professional tools", Quantity = 200 },
                    new ProsCons { Id = 2, Name = "Plugin support", Quantity = 150 },
                    new ProsCons { Id = 3, Name = "File compatibility", Quantity = 100 }
                },
                ConsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "High cost", Quantity = 70 },
                    new ProsCons { Id = 2, Name = "Steep learning curve", Quantity = 40 }
                },
                UserSatisfactionList = new List<UserSatisfaction>
                {
                    new UserSatisfaction { Id = 1, Name = "Ease of use", RateNumber = 4.4f },
                    new UserSatisfaction { Id = 2, Name = "Value for money", RateNumber = 4.3f },
                    new UserSatisfaction { Id = 3, Name = "Feature set", RateNumber = 4.9f }
                }
            },
            new ProductDetail
            {
                ProductId = 3,
                Name = "Slack",
                CategoryName = "Team Collaboration",
                Rate = new RateGeneral
                {
                    ProductId = 3,
                    RateNumber = 4.5f,
                    Quantity = 1800
                },
                Description = "A collaboration hub for messaging, file sharing, and integrations.",
                CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3HzdxgflSXqmsDm4BPPliul-XM5XL-U2qkg&s",
                Link = "https://slack.com/", // Đường dẫn tới trang sản phẩm
                ProsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "Intuitive interface", Quantity = 120 },
                    new ProsCons { Id = 2, Name = "Third-party integrations", Quantity = 100 },
                    new ProsCons { Id = 3, Name = "Custom notifications", Quantity = 80 }
                },
                ConsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "Expensive for teams", Quantity = 50 },
                    new ProsCons { Id = 2, Name = "Search limitations", Quantity = 30 }
                },
                UserSatisfactionList = new List<UserSatisfaction>
                {
                    new UserSatisfaction { Id = 1, Name = "Ease of use", RateNumber = 4.6f },
                    new UserSatisfaction { Id = 2, Name = "Value for money", RateNumber = 4.2f },
                    new UserSatisfaction { Id = 3, Name = "Feature set", RateNumber = 4.5f }
                }
            },
            new ProductDetail
            {
                ProductId = 4,
                Name = "Zoom",
                CategoryName = "Video Conferencing",
                Rate = new RateGeneral
                {
                    ProductId = 4,
                    RateNumber = 4.7f,
                    Quantity = 2200
                },
                Description = "A reliable platform for video conferencing and webinars.",
                CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3HzdxgflSXqmsDm4BPPliul-XM5XL-U2qkg&s",
                Link = "https://zoom.us/", // Đường dẫn tới trang sản phẩm
                ProsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "High-quality audio/video", Quantity = 140 },
                    new ProsCons { Id = 2, Name = "User-friendly", Quantity = 110 },
                    new ProsCons { Id = 3, Name = "Scalable meetings", Quantity = 90 }
                },
                ConsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "Privacy issues", Quantity = 60 },
                    new ProsCons { Id = 2, Name = "Free version limits", Quantity = 40 }
                },
                UserSatisfactionList = new List<UserSatisfaction>
                {
                    new UserSatisfaction { Id = 1, Name = "Ease of use", RateNumber = 4.8f },
                    new UserSatisfaction { Id = 2, Name = "Value for money", RateNumber = 4.6f },
                    new UserSatisfaction { Id = 3, Name = "Feature set", RateNumber = 4.7f }
                }
            },
            new ProductDetail
            {
                ProductId = 5,
                Name = "Adobe XD",
                CategoryName = "Design Tools",
                Rate = new RateGeneral { ProductId = 5, RateNumber = 4.2f, Quantity = 800 },
                Description = "A vector-based tool for designing and prototyping user experiences for web and mobile apps.",
                ProsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "User-friendly interface", Quantity = 300 },
                    new ProsCons { Id = 2, Name = "Excellent prototyping features", Quantity = 250 }
                },
                ConsList = new List<ProsCons>
                {
                    new ProsCons { Id = 1, Name = "Limited collaboration features", Quantity = 100 },
                    new ProsCons { Id = 2, Name = "Lack of advanced design tools", Quantity = 80 }
                },
                UserSatisfactionList = new List<UserSatisfaction>
                {
                    new UserSatisfaction { Id = 1, Name = "Designers", RateNumber = 4.5f },
                    new UserSatisfaction { Id = 2, Name = "Developers", RateNumber = 4.0f }
                },
                CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3HzdxgflSXqmsDm4BPPliul-XM5XL-U2qkg&s",
                Link = "https://www.adobe.com/products/xd.html"
            },
            new ProductDetail
            {
                ProductId = 6, // Thay đổi thành sản phẩm khác
                Name = "Figma",
                CategoryName = "Design Tools",
                Rate = new RateGeneral { ProductId = 6, RateNumber = 4.7f, Quantity = 1500 },
                Description = "A collaborative interface design tool for teams and individuals.",
                ProsList = new List<ProsCons>
                {
                    new ProsCons { Id = 3, Name = "Real-time collaboration", Quantity = 600 },
                    new ProsCons { Id = 4, Name = "Cross-platform availability", Quantity = 400 }
                },
                ConsList = new List<ProsCons>
                {
                    new ProsCons { Id = 3, Name = "Limited offline functionality", Quantity = 100 },
                    new ProsCons { Id = 4, Name = "Expensive for premium users", Quantity = 90 }
                },
                UserSatisfactionList = new List<UserSatisfaction>
                {
                    new UserSatisfaction { Id = 3, Name = "Designers", RateNumber = 4.8f },
                    new UserSatisfaction { Id = 4, Name = "Project Managers", RateNumber = 4.6f }
                },
                CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3HzdxgflSXqmsDm4BPPliul-XM5XL-U2qkg&s",
                Link = "https://www.figma.com/"
            },
            new ProductDetail
            {
                ProductId = 7,
                Name = "GitHub",
                CategoryName = "Version Control",
                Rate = new RateGeneral { ProductId = 7, RateNumber = 4.8f, Quantity = 2000 },
                Description = "A platform for version control and collaboration for developers around the world.",
                ProsList = new List<ProsCons>
                {
                    new ProsCons { Id = 5, Name = "Wide community support", Quantity = 800 },
                    new ProsCons { Id = 6, Name = "Seamless Git integration", Quantity = 700 }
                },
                ConsList = new List<ProsCons>
                {
                    new ProsCons { Id = 5, Name = "Complex for beginners", Quantity = 180 },
                    new ProsCons { Id = 6, Name = "Private repositories cost money", Quantity = 120 }
                },
                UserSatisfactionList = new List<UserSatisfaction>
                {
                    new UserSatisfaction { Id = 5, Name = "Developers", RateNumber = 4.9f },
                    new UserSatisfaction { Id = 6, Name = "Project Managers", RateNumber = 4.7f }
                },
                CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3HzdxgflSXqmsDm4BPPliul-XM5XL-U2qkg&s",
                Link = "https://github.com/"
            },
            new ProductDetail
            {
                ProductId = 8,
                Name = "Asana",
                CategoryName = "Project Management",
                Rate = new RateGeneral { ProductId = 8, RateNumber = 4.6f, Quantity = 1100 },
                Description = "A web and mobile application designed to help teams organize, track, and manage their work.",
                ProsList = new List<ProsCons>
                {
                    new ProsCons { Id = 7, Name = "User-friendly task management", Quantity = 400 },
                    new ProsCons { Id = 8, Name = "Great for remote teams", Quantity = 350 }
                },
                ConsList = new List<ProsCons>
                {
                    new ProsCons { Id = 7, Name = "Lacks time tracking features", Quantity = 140 },
                    new ProsCons { Id = 8, Name = "Expensive for premium features", Quantity = 110 }
                },
                UserSatisfactionList = new List<UserSatisfaction>
                {
                    new UserSatisfaction { Id = 7, Name = "Team Leaders", RateNumber = 4.6f },
                    new UserSatisfaction { Id = 8, Name = "Project Managers", RateNumber = 4.4f }
                },
                CoverImage = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ3HzdxgflSXqmsDm4BPPliul-XM5XL-U2qkg&s",
                Link = "https://asana.com/"
            }
        };


        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.CurrentCategory = new Category()
            {
                Id = 1,
                Name = "Diagramming Software",
                Description = "Diagramming software allows users to create detailed diagrams—such as flow charts and floor plans—out of data\r\n        and images. Diagramming tools often include templates for building diagrams in addition to enabling users to\r\n        create diagrams from scratch. Certain diagramming programs can integrate with other design tools, and may\r\n        offer collaborative platforms so multiple users can view and edit diagram files at the same time. To qualify\r\n        for inclusion in the Diagramming category, a product must: Offer specialized tools for designing one or more\r\n        types of diagrams, such as organizational charts and floorplans Provide industry-related shapes and elements\r\n        for use in diagrams and allow users to create or import custom diagram components Allow specified users to\r\n        view and interact with diagrams online during and after presentations"
                
            };

            this.Products = new List<Product>()
                {
                    new Product
                    {
                        Id = 1,
                        Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/0/0c/Microsoft_Office_logo_%282013%E2%80%932019%29.svg/54px-Microsoft_Office_logo_%282013%E2%80%932019%29.svg.png",
                        Name = "Microsoft Office",
                        Rate = new RateGeneral
                        {
                            ProductId = 1,
                            RateNumber = 4.6f,
                            Quantity = 3000
                        },
                        Description = "A productivity suite including Word, Excel, PowerPoint, and more for personal and business use."
                    },
                    new Product
                    {
                        Id = 2,
                        Logo = "https://upload.wikimedia.org/wikipedia/commons/a/af/Adobe_Photoshop_CC_icon.svg",
                        Name = "Adobe Photoshop",
                        Rate = new RateGeneral
                        {
                            ProductId = 2,
                            RateNumber = 4.8f,
                            Quantity = 2500
                        },
                        Description = "The industry-leading software for photo editing, graphic design, and digital art creation."
                    },
                    new Product
                    {
                        Id = 3,
                        Logo = "https://upload.wikimedia.org/wikipedia/commons/d/d5/Slack_icon_2019.svg",
                        Name = "Slack",
                        Rate = new RateGeneral
                        {
                            ProductId = 3,
                            RateNumber = 4.5f,
                            Quantity = 1800
                        },
                        Description = "A team collaboration tool offering real-time messaging, file sharing, and integrations with other services."
                    },
                    new Product
                    {
                        Id = 4,
                        Logo = "https://upload.wikimedia.org/wikipedia/commons/7/7b/Zoom_Communications_Logo.svg",
                        Name = "Zoom",
                        Rate = new RateGeneral
                        {
                            ProductId = 4,
                            RateNumber = 4.7f,
                            Quantity = 2200
                        },
                        Description = "A video conferencing software that supports meetings, webinars, and online events with ease."
                    }
                };
            this.ProductDetail = ProductDetailStore[0];
            this.RelatedCategory = Enumerable.Range(101, 8).Select(i => new Category
            {
                Id = i,
                Name = $"SubCategory {i} (Electronics)",
                Slug = $"https://example.com/SubCategories/electronics-{i}",
                Quantity = new Random().Next(50, 200),
                SubCategories = null
            }).ToList();

            this.CompareProductList = new List<Product>();
        }
        private void SearchProduct()
        {

        }

        private void ClearFilter()
        {
            Search = string.Empty;
            FeatureFilter = "0";
            BusinessSizeFilter = "0";
            PriceFilter = "0";
        }

        private void LoadProductDetail(int ProductId)
        {
            this.ProductDetail = this.ProductDetailStore.FirstOrDefault(pd => pd.ProductId == ProductId);
        }

        private void Showmore()
        {
            var newProducts = new List<Product>()
            {
                new Product
                {
                    Id = 5,
                    Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c2/Adobe_XD_CC_icon.svg/768px-Adobe_XD_CC_icon.svg.png",
                    Name = "Adobe XD",
                    Rate = new RateGeneral { ProductId = 5, RateNumber = 4.2f, Quantity = 800 },
                    Description = "A vector-based tool for designing and prototyping user experiences for web and mobile apps."
                },
                new Product
                {
                    Id = 6,
                    Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/33/Figma-logo.svg/600px-Figma-logo.svg.png",
                    Name = "Figma",
                    Rate = new RateGeneral { ProductId = 6, RateNumber = 4.7f, Quantity = 1500 },
                    Description = "A collaborative interface design tool for teams and individuals."
                },
                new Product
                {
                    Id = 7,
                    Logo = "https://github.githubassets.com/assets/GitHub-Mark-ea2971cee799.png",
                    Name = "GitHub",
                    Rate = new RateGeneral { ProductId = 7, RateNumber = 4.8f, Quantity = 2000 },
                    Description = "A platform for version control and collaboration for developers around the world."
                },
                new Product
                {
                    Id = 8,
                    Logo = "https://upload.wikimedia.org/wikipedia/commons/thumb/3/3b/Asana_logo.svg/1197px-Asana_logo.svg.png?20220315051729",
                    Name = "Asana",
                    Rate = new RateGeneral { ProductId = 8, RateNumber = 4.6f, Quantity = 1100 },
                    Description = "A web and mobile application designed to help teams organize, track, and manage their work."
                }
            };
            Products.AddRange(newProducts);
        }

        private int FindIndexOfCompareProductList(int productId) 
        {
            return CompareProductList.FindIndex(cp => cp.Id == productId);
        }

        private bool IsHaveCompareProduct(int productId)
        {
            return FindIndexOfCompareProductList(productId) != -1;
        }

        private void ToggleCompare(Product product)
        {
            if (isProcessing) return; // If processing, can not call again

            isProcessing = true;

            if (!IsHaveCompareProduct(product.Id))
            { 
                CompareProductList.Add(product);
            }
            else
            {
                var index = FindIndexOfCompareProductList(product.Id);
                CompareProductList.RemoveAt(index);
            }

            // Delay to fix second render to reset
            Task.Delay(200).ContinueWith(_ =>
            {
                isProcessing = false;
            });
        }

        private void ClearCompareList()
        {
            this.CompareProductList.Clear();
        }

        private void RemoveCompareProduct(int id)
        {
            var index = FindIndexOfCompareProductList(id);
            this.CompareProductList.RemoveAt(index);
        }

    }
}
