﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBATeams.Domain.DTOs
{
    public class StatDTO
    {
        public double Height { get; set; }
        public double Weight { get; set; }
        public decimal PPG { get; set; }
        public decimal RPG { get; set; }
        public decimal APG { get; set; }
        public decimal PIE { get; set; }
        public int Assists { get; set; }
        public int Score { get; set; }
    }
}
