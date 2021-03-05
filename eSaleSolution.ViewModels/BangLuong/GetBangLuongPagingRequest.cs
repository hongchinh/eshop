using eSaleSolution.ViewModels.Common;

namespace eSaleSolution.ViewModels.Catalog.Products
{
    public class GetBangLuongPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
 
    }
}