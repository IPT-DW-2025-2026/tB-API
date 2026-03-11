namespace tB_Fotografias.Models
{
    /// <summary>
    /// Utilizador da aplicação
    /// </summary>
    public class MyUser
    {
        /// <summary>
        /// Id sequencial da tabela
        /// </summary> 
        public int Id { get; set; }
        
        /// <summary>
        /// Nome do Utilizador
        /// </summary> 
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Endereço do Utilizador
        /// </summary> 
        public string Address { get; set; } = string.Empty;
        
        /// <summary>
        /// Código Postal do Utilizador
        /// </summary>
        public string PostalCode { get; set; } = string.Empty;

        /// <summary>
        /// País do Utilizador
        /// </summary>
        public string Country { get; set; } = string.Empty;

        /// <summary>
        /// NIF do Utilizador
        /// </summary>
        public string TaxNumber { get; set; } = string.Empty;

        /// <summary>
        /// Telemóvel do Utilizador
        /// </summary>
        public string CellPhone { get; set; } = string.Empty;

    }
}
