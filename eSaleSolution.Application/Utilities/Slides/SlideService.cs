using eSaleSolution.Application.System.Roles;
using eSaleSolution.Data.EF;
using eSaleSolution.Data.Entities;
using eSaleSolution.ViewModels.System.Roles;
using eSaleSolution.ViewModels.Utilities.Slides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eSaleSolution.Application.Utilities.Slides
{
    public class SlideService : ISlideService
    {
        private readonly ESaleDbContext _context;

        public SlideService(ESaleDbContext context)
        {
            _context = context;
        }

        public async Task<List<SlideVm>> GetAll()
        {
            var slides = await _context.Slides.OrderBy(x => x.SortOrder)
                .Select(x => new SlideVm()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    Url = x.Url,
                    Image = x.Image
                }).ToListAsync();

            return slides;
        }
    }
}