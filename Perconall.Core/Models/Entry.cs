namespace Perconall.Core.Models
{
    public class Entry
    {
        public string Id { get; set; }
        public string Date { get; set; }
        
        public string Notes { get; set; }
        public float Kg { get; set; }
        public bool OnWakeup { get; set; }
        public bool OnSleep { get; set; }
        
    }
}