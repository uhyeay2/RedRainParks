using RedRainParks.Domain.Models.BaseModels;

namespace RedRainParks.Domain.Models.StateModels.Responses
{
    public class GetAllStateLookupResponse : BaseResponse
    {
        public IEnumerable<StateLookup> States { get; set; }

        public GetAllStateLookupResponse(IEnumerable<StateLookupDTO> states)
        {
            States = states.Select(s => new StateLookup(s.StateLookup_Abbreviation, s.StateLookup_EnglishDisplay, s.StateLookup_SpanishDisplay));
        }
    }
}
