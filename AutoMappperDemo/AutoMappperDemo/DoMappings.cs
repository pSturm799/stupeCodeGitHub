using AutoMapper;
using AutoMappperDemo.Models;

namespace AutoMappperDemo
{
    public class DoMappings : Profile
    {
        /// <summary>
        /// </summary>
        public DoMappings()
        {
            ObjektModelToDisplayModelMapping();
        }

        public void ObjektModelToDisplayModelMapping()
        {
            CreateMap<ObjektModel, DisplayModel>()
                .ForMember(dispModel => dispModel.Kuerzel, objModel => objModel.MapFrom(temp => temp.Krzl))
                .ForMember(dispModel => dispModel.ParentObjektId, objModel => objModel.MapFrom(temp => temp.ParId))
                .ForMember(dispModel => dispModel.Hausnummer, objModel => objModel.MapFrom(temp => temp.Hnr))
                .ForMember(dispModel => dispModel.Korrekt, objModel => objModel.MapFrom(temp => temp.Krkt))
                .ForMember(dispModel => dispModel.ParentObjekt, objModel => objModel.MapFrom(temp => temp.ParObjModel))
                .ReverseMap()
                ;
        }
    }
}