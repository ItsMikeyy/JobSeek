using JobSeek.Data;

namespace JobSeek.Web.Models.DTO
{
    public class StateDTO
    {
        public StateDTO(State state)
        {
            StateID = state.StateID;
            Name = state.Name;
        }
        public int StateID { get; set; }
        public string Name { get; set; }
    }
}
