﻿using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Image : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
