namespace Bridge
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            var cleverUmpire = new Umpire();
            
            cleverUmpire.SaySomething();
            
            cleverUmpire.ReadWhiteCards();
            
            cleverUmpire.ReadBlackCards();
            
            cleverUmpire.AnnounceTheWinner();
        }
    }
}