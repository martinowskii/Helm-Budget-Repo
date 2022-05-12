using System.ComponentModel.DataAnnotations;

namespace Helm_Budget_System.Models
{
    public class TransactionDescriptor
    {
        public int ID { get; set; }
        [Display(Name = "Transaction Descriptor")]
        [Required]
        public string TransactionDescriptorName { get; set; }
        [Display(Name = "School")] public int SchoolID { get; set; }
        public School School { get; set; }

        public ICollection<DescriptorDesignation> DescriptorDesignations { get; set; }
    }
}
