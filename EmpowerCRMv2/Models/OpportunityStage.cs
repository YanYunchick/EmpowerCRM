﻿using System.ComponentModel.DataAnnotations;

namespace EmpowerCRMv2.Models
{
    public class OpportunityStage
    {
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        public List<Opportunity> Opportunitites { get; set; }
    }
}
