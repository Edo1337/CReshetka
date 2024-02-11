using CReshetka.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CReshetka.Models
{
    //Если человек прошел тест, то информация об этом записывается в эту таблицу и к Studied прибавляется единица,
    //на сайте блокируется возможность проходить тест для этого человека снова (кнопка не кликабельна)

    [Table("TestResult")]
    public class TestResult
    {
        [Required]
        public int? Id { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        [Required]
        // Внешний ключ
        public string? UserId { get; set; }
        [Required]
        public string NameTest { get; set; }
        [Required]
        public bool IsCompleted { get; set; }

        // Навигационное свойство для связи с AspNetUsers
        [NotMapped]
        public ApplicationUser User { get; set; }
    }
}
