using System;

namespace FriendlyDateTime.Code.Domain
{
    public class Auction
    {
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime EndedAt { get; set; }
    }
}