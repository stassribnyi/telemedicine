using System.ComponentModel.DataAnnotations.Schema;

namespace Telemedicine.Domain.Core.Models
{
    [ComplexType]
    public class Pressure
    {
        public int Sys { get; set; }
        public int Dia { get; set; }
    }
}