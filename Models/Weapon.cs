namespace PocBTG.Models
{
    public class Weapon
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Mod { get; set; }
        public string Attr { get; set; }
        public bool Equipped { get; set; }
    }
}
