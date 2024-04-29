namespace EmpowerCRMv2.Models
{
    public class OpportunityStage
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Opportunity> Opportunitites { get; set; }
    }
}
