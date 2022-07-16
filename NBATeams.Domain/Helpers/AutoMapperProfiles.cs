using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Petfy.Domain.Extensions
{
    public class AutoMapperProfiles: Profile
    {
        public AutoMapperProfiles()
        {
            /*CreateMap<Pet, PetDTO>()
                .ForMember(
                    dest => dest.MainPhotoUrl,
                    opt => opt.MapFrom(
                                p => p.Photos.Where(p => p.IsMain).FirstOrDefault().URL
                            )
                    );*/
        }
    }
}
