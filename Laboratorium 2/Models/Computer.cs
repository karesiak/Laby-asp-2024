﻿using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_2.Models
{
    public class Computer
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę komputera!")]
        [StringLength(100, ErrorMessage = "Nazwa jest zbyt długa (maksymalnie 100 znaków).")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę procesora!")]
        public string Processor { get; set; }

        [Required(ErrorMessage = "Proszę podać wielkość pamięci RAM w GB!")]
        [Range(1, 128, ErrorMessage = "Pamięć RAM musi być w zakresie od 1 do 128 GB.")]
        public string Memory { get; set; }

        [Required(ErrorMessage = "Proszę podać model karty graficznej!")]
        public string GraphicsCard { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwę producenta!")]
        public string Manufacturer { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Proszę podać datę produkcji.")]
        public DateTime ProductionDate { get; set; }
    }
}
