using System.Collections.Generic;

namespace DogGo.Models.ViewModels
{
    public class DogFormViewModel
    {
        public Owner Owner { get; set; }
        public List<Dog> Dogs { get; set; }
    }
}

