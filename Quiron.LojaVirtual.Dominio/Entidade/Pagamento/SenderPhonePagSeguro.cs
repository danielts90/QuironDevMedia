using System.Xml.Serialization;

namespace Quiron.LojaVirtual.Dominio.Entidade.Pagamento
{
    public class SenderPhonePagSeguro
    {
        [XmlElement(ElementName = "areaCode")]
        public string AreaCode { get; set; }
        [XmlElement(ElementName = "number")]
        public string Number { get; set; }
    }
}