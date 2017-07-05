using AutoMapper;
using BT.TS360.BLL.Entities;
using POCDemo.Entities.SP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POCDemo
{
    public static class MapperConfig
    {
        public static void InitializeMap()
        {
            Mapper.Initialize(map =>
            {
                map.CreateMap<StagingeList, EList>()
                 .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                 .ForMember(dest => dest.EListCategory, opts => opts.MapFrom(src => src.eListCategory.LookupValue))
                 .ForMember(dest => dest.EListSubCategory, opts => opts.MapFrom(src => src.eListSubcategory.LookupValue));

                map.CreateMap<StagingeListCategory, EListCategory>()
                 .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                 .ForMember(dest => dest.Path, opts => opts.MapFrom(src => src.FileDirRef));

                map.CreateMap<StagingeListSubcategory, EListSubCategory>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Path, opts => opts.MapFrom(src => src.FileDirRef));

               // map.CreateMap<StagingPromotion, Promotion>()
               //.ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               //.ForMember(dest => dest.Path, opts => opts.MapFrom(src => src.FileDirRef));

                map.CreateMap<StagingPublication, Publication>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.IconImageUrl, opts => opts.MapFrom(src => src.IconImageUrl.Url))
               .ForMember(dest => dest.Path, opts => opts.MapFrom(src => src.FileDirRef));

                map.CreateMap<StagingPublicationCategory, PublicationCategory>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.PublicationIssue, opts => opts.MapFrom(src => src.PublicationIssue.LookupValue))
               .ForMember(dest => dest.Path, opts => opts.MapFrom(src => src.FileDirRef));

                map.CreateMap<StagingPublicationIssue, PublicationIssue>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.Publication, opts => opts.MapFrom(src => src.Publication.LookupValue))
               .ForMember(dest => dest.Path, opts => opts.MapFrom(src => src.FileDirRef));

                map.CreateMap<StagingPublicationSubCategory, PublicationSubCategory>()
               .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
               .ForMember(dest => dest.PublicationCategory, opts => opts.MapFrom(src => src.PublicationCategory.LookupValue))
               .ForMember(dest => dest.Path, opts => opts.MapFrom(src => src.FileDirRef));

            });
        }
    }
}
