using System.ComponentModel.DataAnnotations;

namespace tB_Fotografias.Models
{
    /// <summary>
    /// Categoria a que fotografias podem pertencer
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Id sequencial da tabela
        /// </summary> 
        public int Id { get; set; }

        /// <summary>
        /// Nome da Categoria
        /// </summary> 
        [Display(Name = "Nome da Categoria")]  // the name to show on screen
        [Required(ErrorMessage = "A {0} é de preenchimento obrigatório.")]
        [StringLength(32, ErrorMessage = "A {0} deve ter um máximo de {1} caracteres.")]
        public string Name { get; set; } = string.Empty;
    }
}
