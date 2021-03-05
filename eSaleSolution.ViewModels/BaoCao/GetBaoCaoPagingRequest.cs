using eSaleSolution.ViewModels.Common;

namespace eSaleSolution.ViewModels.Catalog.Products
{
    public class GetBaoCaoPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
 
    }
}