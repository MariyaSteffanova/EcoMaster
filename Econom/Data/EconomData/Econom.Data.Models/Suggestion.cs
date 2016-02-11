namespace Econom.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Contracts;

    public class Suggestion : AuditInfo
    {
        [Key]
        public int ID { get; set; }

        public string Notes { get; set; }

        public int RecipeID { get; set; } // TODO: Delete when aproved?

        public int SuggestionResponseID { get; set; }
        // TODO:  Recipe, noteID, aprroved or not, answer
    }
}
