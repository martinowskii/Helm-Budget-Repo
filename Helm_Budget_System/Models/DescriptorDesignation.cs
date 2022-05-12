using System.ComponentModel.DataAnnotations;

namespace Helm_Budget_System.Models
{
    public class DescriptorDesignation
    {
        public int DescriptorDesignationID { get; set; }
        [Display(Name = "Transaction Descriptor")] public int TransactionDescriptorID { get; set; }
        [Display(Name = "Descriptor Description")] public int DescriptorDescriptionID { get; set; }

        [Display(Name = "Transaction Descriptor")] public TransactionDescriptor TransactionDescriptor { get; set; }
        [Display(Name = "Descriptor Description")] public DescriptorDescription DescriptorDescription { get; set; }
    }
}
