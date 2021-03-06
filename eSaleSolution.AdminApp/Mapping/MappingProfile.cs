using eSaleSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eSaleSolution.ViewModels.DanhMuc.TenDonVis;
using eSaleSolution.ViewModels.DanhMuc.HangHoas;

namespace eSaleSolution.AdminApp.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TenDonViUpdateRequest, DanhMucTenDonVi>();
            CreateMap<TenDonViCreateRequest, DanhMucTenDonVi>();
            CreateMap<TenDonViVm, DanhMucTenDonVi>();
            CreateMap<List<TenDonViVm>, DanhMucTenDonVi[]>();


            CreateMap<HangHoaCreateRequest, DanhMucHangHoa>();
            CreateMap<HangHoaUpdateRequest, DanhMucHangHoa>();
            CreateMap<HangHoaVm, DanhMucHangHoa>();
        }
    }
}
