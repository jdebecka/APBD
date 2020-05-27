using System.Collections.Generic;

namespace CodeFirstWebApplication.Entities
{
    public class Medicament
    {
        public int IdMedicament { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        
        public ICollection<Prescription_Medicament> Prescription_Medicament { get; set; }

    }
}