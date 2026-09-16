using System.ComponentModel.DataAnnotations.Schema;

namespace DBOperationsWithEFCore.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description {  get; set; }
        public int NoOfPages { get; set; }  
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }

        public int LanguageId { get; set; } // Foreign Key Language+Id , EF core Automatically recognizes it
        [ForeignKey("LanguageId")]
        public Language Language { get; set; } // Navigational property , lets you get data from Language Book.language.Title


    }
}
