using System;

namespace AguiarGames.Api.Entity
{
    public class Game
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public DateTime Release { get; set; }
        public bool Offer { get; set; }
        public decimal Price { get; set; }
    }
}