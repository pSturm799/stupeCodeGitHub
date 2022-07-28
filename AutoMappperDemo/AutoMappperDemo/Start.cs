using AutoMapper;
using AutoMappperDemo.Models;

namespace AutoMappperDemo
{
    public class Start
    {
        private readonly IMapper _mapper;

        /// <summary>
        /// </summary>
        public Start(IMapper mapper)
        {
            _mapper = mapper;
        }

        public void Go()
        {
            var objektModel = new ObjektModel
                              {
                                  Id = "001",
                                  Krzl = "stupe",
                                  ParId = "0",
                                  Hnr = 3,
                                  Krkt = true,
                                  ParObjModel = new ObjektModel
                                                {
                                                    Id = "002",
                                                    Krzl = "stja",
                                                    Hnr = 9
                                                }
                              };


            var displayModel = _mapper.Map<ObjektModel, DisplayModel>(objektModel);
            var objektModel2 = _mapper.Map<DisplayModel, ObjektModel>(displayModel);
        }
    }
}