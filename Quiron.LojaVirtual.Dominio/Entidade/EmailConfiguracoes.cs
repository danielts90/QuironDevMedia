namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class EmailConfiguracoes
    {
        public bool UsarSsl = false;
        public string ServidorSmtp = "meusmtp";
        public int ServidorPorta = 587;
        public string Usuario = "quiron";
        public bool EscreverArquivo = false;
        public string PastaArquivo = @"C:\envioEmail";
        public string De = "quiron@quiron.com.br";
        public string Para = "pedido@pedido.com.br";
    }
}