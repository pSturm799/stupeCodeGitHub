using System;
using AutoMapper;

namespace AutoMappperDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new DoMappings());
                    //cfg.CreateMap<ObjektModel, DisplayModel>();
                    //cfg.CreateMap<DisplayModel, ObjektModel>();
                }
            );

            var mapper = config.CreateMapper();
            var starting = new Start(mapper);
            starting.Go();
        }
    }
}