using Mono.TextTemplating;

namespace tB_Fotografias.Models
{
    /// <summary>
    /// Compra que um utilizador faz de várias fotografias
    /// </summary>
    public class Purchase
    {
        /// <summary>
        /// Id sequencial da tabela
        /// </summary>        
        public int Id { get; set; }

        /// <summary>
        /// Data da compra
        /// </summary>  
        public DateTime Date { get; set; }

        /// <summary>
        /// Estado da compra
        /// </summary>
        public State State { get; set; }
    }

    public enum State
    {
        Pending,
        Paid,
        Sent,
        Delivered,
        Closed
    }

}
