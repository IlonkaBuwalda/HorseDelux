using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
namespace HorseDelux.Models
{
    public class Horse
    {
        public int HorseId { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }
        public float Height { get; set; }
        public float HeartGirth { get; set; }
        public float LengthToHip { get; set; }
        public float LengthOfHorse { get; set; }
    }
}