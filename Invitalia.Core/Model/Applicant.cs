namespace Invitalia.Core.Model
{
    public class Applicant
        : Entity
    {
        public string Name { get; set; }
        public string TaxCode { get; set; }
        public string VatNumber { get; set; }
        public string Email { get; set; }
    }
}
