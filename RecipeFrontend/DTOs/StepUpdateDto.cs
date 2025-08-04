namespace RecipeFrontend.DTOs
{
    public class StepUpdateDto
    {
        public int? Id { get; set; }
        public string Instruction { get; set; } = string.Empty;
        public int Order { get; set; }
    }
}
