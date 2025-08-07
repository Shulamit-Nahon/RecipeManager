using System.ComponentModel.DataAnnotations;

namespace RecipeFrontend.DTOs
{
    public class StepDto
    {
        public int Order { get; set; }
        [Required(ErrorMessage = "Step instruction is required.")]
        public string Instruction { get; set; } = string.Empty;
    }
}
