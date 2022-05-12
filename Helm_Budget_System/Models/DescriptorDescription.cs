using System.ComponentModel.DataAnnotations;

namespace Helm_Budget_System.Models
{
    public class DescriptorDescription
    {
        public int ID { get; set; }

        [Display(Name = "Descriptor Description")][Required] public string DescriptorDescriptionName { get; set; }

        public ICollection<DescriptorDesignation> DescriptorDesignations { get; set; }

    }
}
