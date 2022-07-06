using DAL.Base;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Slider : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string  Body { get; set; }


        public int ImageIdc { get; set; }
        public Image Image { get; set; }
    }
}
