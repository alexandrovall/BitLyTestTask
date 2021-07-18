using AutoMapper;

namespace Alexandrovall.BitLyTestTask.Mapping.Profiles
{
    public class CommonProfile : Profile
    {
        public CommonProfile()
        {
            CreateMap<string, string>()
                .ConvertUsing(str => string.IsNullOrWhiteSpace(str) ? str : str.Trim());
        }
    }
}