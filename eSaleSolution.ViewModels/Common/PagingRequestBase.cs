using System;
using System.Collections.Generic;
using System.Text;

namespace eSaleSolution.ViewModels.Common
{
    public class PagingRequestBase : BaseRequest
    {
        public int PageIndex { get; set; }

        public int PageSize { get; set; }

        
    }
}