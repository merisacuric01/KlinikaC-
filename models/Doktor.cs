namespace klinika.models
{
    public class Doktor
    {
        public int DoktorID { get; set; } 
        public string Ime { get; set; } = string.Empty; 
        public string Prezime { get; set; } = string.Empty;
        public string Kontact { get; set; } = string.Empty;
        public int OdeljenjeID { get; set; }
        public Odeljenje Odeljenje { get; set; }
       
    }
}
