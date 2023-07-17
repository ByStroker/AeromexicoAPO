namespace AeromexicoAPO.Models
{
    public class vuelo
    {
        public int id { get; set; }

        public string numero_vuelo { get; set; }

        public string origen { get; set; }

        public string destino { get; set; }

        public DateTime? fecha_salida { get; set; }

    }
}
