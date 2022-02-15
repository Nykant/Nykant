using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NykantAPI.Models
{
    public class Consent
    {
        [Key]
        public int Id { get; set; }
        public string IPAddress { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public ConsentType Type { get; set; }
        public string ConsentText { get; set; }
        public ConsentHow How { get; set; }
        public string ButtonText { get; set; }
        public DateTime Date { get; set; }
        public ConsentStatus Status { get; set; }
    }
    public enum ConsentType
    {
        Cookie,
        TermsAndConditions,
        PrivacyPolicy,
        Newsletter
    }
    public enum ConsentHow
    {
        Button,
        Checkbox
    }
    public enum ConsentStatus
    {
        Given,
        Retrieved
    }
}
