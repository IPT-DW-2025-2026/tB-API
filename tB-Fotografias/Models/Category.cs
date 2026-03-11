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
        public string Name { get; set; } = string.Empty;
    }
}
