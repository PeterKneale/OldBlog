using System;
using System.Collections.Generic;
using FriendlyDateTime.Code.Domain;

namespace FriendlyDateTime.Code.Services
{
    public class AuctionService
    {
        public static IEnumerable<Auction> GetAuctions()
        {
            var now = DateTime.Now;
            var twoSecondsAgo = now.AddSeconds(-2);
            var oneMinuteAgo = now.AddMinutes(-1);
            var fiveMinutesAgo = now.AddMinutes(-5);
            var fifteenMinutesAgo = now.AddMinutes(-15);

            var twoSeconds = now.AddSeconds(2);
            var oneMinute = now.AddMinutes(1);
            var fiveMinutes = now.AddMinutes(5);
            var fifteenMinutes = now.AddMinutes(15);

            yield return new Auction
            {
                CreatedAt = now,
                StartedAt = oneMinute,
                EndedAt = fiveMinutes            
            };

            yield return new Auction
            {
                CreatedAt = now,
                StartedAt = oneMinute,
                EndedAt = fifteenMinutes
            };

            yield return new Auction
            {
                CreatedAt = oneMinuteAgo,
                StartedAt = now,
                EndedAt = fifteenMinutes
            };
            yield return new Auction
            {
                CreatedAt = fiveMinutesAgo,
                StartedAt = now,
                EndedAt = twoSeconds
            };

            yield return new Auction
            {
                CreatedAt = fifteenMinutesAgo,
                StartedAt = fiveMinutesAgo,
                EndedAt = twoSeconds
            };

            yield return new Auction
            {
                CreatedAt = twoSecondsAgo,
                StartedAt = now,
                EndedAt = twoSeconds
            };
        }
    }
}
