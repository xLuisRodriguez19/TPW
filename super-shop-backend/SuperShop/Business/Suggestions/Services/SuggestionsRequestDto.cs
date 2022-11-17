using SuperShop.Models.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SuperShop.Business.Suggestions.Services
{
public partial class SuggestionsRequestDto
    {
        public string Email { get; set; }
        public string Asunto { get; set; }
        public string Descripcion { get; set; }
    }
}
