using System.Xml.Serialization;

namespace Quiron.LojaVirtual.Dominio.Entidade.Pagamento
{
    public class SenderDocumentPagSeguro
    {
        [XmlElement(ElementName = "type")]
        public string Type { get { return "CPF"; } set { } }
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
    }
}