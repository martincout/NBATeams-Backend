using AutoMapper;
using NBATeams.Data.Models;
using NBATeams.Domain.DTOs;
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
            CreateMap<Player, PlayerDTO>()
                .ForMember(
                    dest => dest.Stats,
                    opt => opt.MapFrom(
                            p => p.Stats
                        )
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(
                            p => p.Age()
                        )
                );
            CreateMap<Team, TeamRegisterPlayerDTO>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Name));

            CreateMap<Stat, StatDTO>()
                .ForMember(
                    dest => dest.Average,
                    opt => opt.MapFrom(
                            p => p.AveragePoints()
                        )

                );
            CreateMap<Team, TeamDTO>();
            CreateMap<Game, GameDTO>();
            CreateMap<Court, CourtDTO>()
                .ForMember(
                    dest => dest.City,
                    opt => opt.MapFrom(
                            p => p.Location.City
                        )
                )
                .ForMember(
                    dest => dest.Street,
                    opt => opt.MapFrom(
                            p => p.Location.Street
                        )
                );
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
