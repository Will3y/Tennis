namespace Tennis.Model
{
    public class Data : Player
    {
        public int Rank { get; set; }
        public int Points { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public int Age { get; set; }
        public int[] Last { get; set; }
    }
}
