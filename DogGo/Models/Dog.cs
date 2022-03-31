using System.ComponentModel.DataAnnotations;

namespace DogGo.Models
{
    public class Dog
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Hmmm... You should really add a Name...")]
        [MaxLength(35)]
        public string Name { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        [Required(ErrorMessage = "Hmmm... You should really add a breed...")]
        [MaxLength(35)]
        public string Breed { get; set; }
        public string Note { get; set; }
        public string ImageUrl { get; set; }
    }
}
