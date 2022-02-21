using System;

namespace StreamingService.Models
{
    public class Subscription
    {
        public Guid Id { get; set; }
        public Packages Package { get; set; }
        public double Price { get; set; }
    }
}
