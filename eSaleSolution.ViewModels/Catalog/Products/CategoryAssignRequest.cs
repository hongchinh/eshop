using eSaleSolution.ViewModels.Common;
using System.Collections.Generic;

namespace eSaleSolution.ViewModels.Catalog.Products
{
    public class CategoryAssignRequest
    {
        public int Id { get; set; }
        public List<SelectItem> Categories { get; set; } = new List<SelectItem>();
    }
}