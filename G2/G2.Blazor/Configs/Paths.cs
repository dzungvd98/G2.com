using System.Diagnostics.Contracts;

namespace G2.Blazor.Configs
{
    public static class Paths
    {
        public static string HomePage = "/";
        public static string LoginPage = "/login";
        public static string CategoryListPage = "/category";
        public static string CategoryListOfSoftwarePage = "/category?category-type=software";
        public static string CategoryListOfServicePage = "/category?category-type=service";
        public static string CategoryPage = "/category/{categoryName}";
        public static string ProductDetailPage = "/products/{productName}";
        public static string ComparePage = "/compare";
        public static string CompareDetailPage = "/compare/{productNameList}";
        public static string BestSoftwareCompaniesPage = "/best-software-companies";
    }
}
