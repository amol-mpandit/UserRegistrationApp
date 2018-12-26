using AutoMapper;
using StructureMap;
using UserRegistrationApp.Mappers;

namespace UserRegistrationApp.DependencyResolution
{
    public class AutoMapperRegistry : Registry
    {
        public AutoMapperRegistry()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserViewModelMapperProfile>();
            });
        }
    }
}