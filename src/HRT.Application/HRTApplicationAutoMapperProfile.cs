using AutoMapper;
using HRT.Candidates;
using Volo.Abp.AutoMapper;

namespace HRT;

public class HRTApplicationAutoMapperProfile : Profile
{
    public HRTApplicationAutoMapperProfile()
    {
        CreateMap<CreateUpdateCandidateDto, Candidate>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
        //CreateMap<CreateUpdateCandidateDto, Candidate>().IgnoreFullAuditedObjectProperties().Ignore(x => x.ExtraProperties).Ignore(x => x.ConcurrencyStamp).Ignore(x => x.Id);
        CreateMap<Candidate, CandidateDto>();

        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
