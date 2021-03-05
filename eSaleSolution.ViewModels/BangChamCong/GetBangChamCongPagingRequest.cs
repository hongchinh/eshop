using eSaleSolution.ViewModels.Common;

namespace eSaleSolution.ViewModels.Catalog.Products
{
    public class GetBangChamCongPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
 
    }
}