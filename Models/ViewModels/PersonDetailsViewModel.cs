namespace Miniprojekt_API.Models.ViewModels
{
    public class PersonDetailsViewModel
    {
        public PersonViewModel PersonInfo { get; set; }
        public List<InterestPersonViewModel> Interests { get; set; }
        public List<InterestLinkViewModel> InterestUrls { get; set; }
    }
}
