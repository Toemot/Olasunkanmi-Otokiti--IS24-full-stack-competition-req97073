using System.ComponentModel.DataAnnotations;

namespace BCProviceApp.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; } = string.Empty;
        [Required]
        public string ScrumMaster { get; set; } = string.Empty;
        [Required]
        public string ProductOwner { get; set; } = string.Empty;
        [Required]
        public List<string> DeveloperName { get; set; } = new List<string>();
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public Methodology Methodology { get; set; }
    }
}