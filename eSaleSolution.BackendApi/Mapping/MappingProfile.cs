using eSaleSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using eSaleSolution.ViewModels.DanhMuc.TenDonVis;
using eSaleSolution.ViewModels.DanhMuc.HangHoas;

namespace eSaleSolution.BackendApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DanhMucTenDonVi, TenDonViUpdateRequest>();
            CreateMap<DanhMucTenDonVi, TenDonViCreateRequest>();
            CreateMap<DanhMucTenDonVi, TenDonViVm>();
            CreateMap<TenDonViUpdateRequest,DanhMucTenDonVi >();
            CreateMap<TenDonViCreateRequest, DanhMucTenDonVi>();

            CreateMap<List<DanhMucTenDonVi>, List<TenDonViVm>>();

            CreateMap<DanhMucHangHoa, HangHoaCreateRequest>();
            CreateMap<DanhMucHangHoa, HangHoaUpdateRequest>();
            CreateMap<DanhMucHangHoa, HangHoaVm>();
        }
    }
}
