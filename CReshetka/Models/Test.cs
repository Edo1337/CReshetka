using System.ComponentModel.DataAnnotations;

namespace CReshetka.Models
{
    //если человек прошел тест, то информация об этом записывается в эту таблицу и к Studied прибавляется единица,
    //на сайте блокируется возможность проходить тест для этого человека снова
    public class Test
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public int? UserId { get; set; }
        [Required]
        public string? NameTest { get; set; }
        [Required]
        public bool? isCompleted { get; set; }
    }

}
