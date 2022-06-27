using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicManagement.Models
{
    public class MedicinesHistory
    {
        public int MedicinesID { get; set; }
        [ForeignKey("MedicinesID")]
        public Medicines medicines{get;set;}

        public int PaymentHeaderID { get; set; }
        [ForeignKey("PaymentHeaderID")]
        public PaymentHeader PaymentHeader{get;set;}
    }
}