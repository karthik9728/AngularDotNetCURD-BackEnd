﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inspections.Model.Model
{
    public class Status
    {
        public int Id { get; set; }

        [StringLength(30)]
        public string statusOption { get; set; } = string.Empty;
    }
}
