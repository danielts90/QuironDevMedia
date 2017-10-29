using System.Xml.Serialization;

namespace Quiron.LojaVirtual.Dominio.Entidade.Pagamento
{
    public class ShippingPagSeguro
    {
        [XmlElement(ElementName = "address")]
        public ShippingAddressPagSeguro Address { get; set; }
        [XmlElement(ElementName = "type")]
        public int Type { get; set; } // 1- PAC, 2 - SEDEX, 3 - Não especificado

        private decimal cost;
        [XmlElement(ElementName = "cost")]
        public string Cost
        {
            get { return cost.ToString("n2"); }
            set { cost = decimal.Parse(value); }
        }
    }
}