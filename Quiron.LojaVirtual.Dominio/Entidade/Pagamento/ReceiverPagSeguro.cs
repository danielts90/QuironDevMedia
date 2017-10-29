using System.Xml.Serialization;

namespace Quiron.LojaVirtual.Dominio.Entidade.Pagamento
{
    public class ReceiverPagSeguro
    {
        [XmlElement(ElementName = "email")]
        public string Email { get { return "hmgasparotto@hotmail.com"; } set { } }
    }
}