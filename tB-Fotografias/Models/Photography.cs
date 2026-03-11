namespace tB_Fotografias.Models
{
    /// <summary>
    /// Fotografias que podem ser vendidas, e que pertencem a uma categoria
    /// </summary>
    public class Photography
    {
        /// <summary>
        /// Id sequencial da tabela
        /// </summary> 
        public int Id { get; set; }
        
        /// <summary>
        /// Titulo da Fotografia
        /// </summary> 
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// Descricao Fotografia
        /// </summary> 
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Ficheiro da Fotografia
        /// </summary>
        public string File { get; set; } = string.Empty;

        /// <summary>
        /// Data em que a Fotografia foi tirada
        /// </summary> 
        public DateTime Date { get; set; }

        /// <summary>
        /// Preço de compra da Fotografia
        /// </summary> 
        public decimal Price { get; set; }

    }
}
