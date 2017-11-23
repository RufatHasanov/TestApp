
namespace Company.TestApp.Model
{
    /// <summary>
    /// InfoMessage class for exception and alert
    /// </summary>
    public class InfoMessage
    {
        /// <summary>
        /// The Message background Color, 
        /// </summary>
        public string BackgroundColor { get; set; }
        /// <summary>
        /// Message content
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Set visibility panel message 
        /// </summary>
        public bool Visible { get; set; }
    }
}
