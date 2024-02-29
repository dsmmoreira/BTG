using System;
using System.Collections.Generic;

namespace PocBTG.Models
{
    // Model class for Knight
    public class Knight
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public DateTime Birthday { get; set; }
        public List<Weapon> Weapons { get; set; }
        public Attributes Attributes { get; set; }
        public string KeyAttribute { get; set; }
               
    }
}
