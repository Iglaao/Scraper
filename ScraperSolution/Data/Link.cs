﻿using System;

namespace Scraper.Data
{
    public class Link : IEquatable<Link>
    {
        public int Id { get; set; }
        public string Url { get; set; } = "";
        public bool IsFound { get; set; } = false;
        public int Counter { get; set; } = 0;

        public bool Equals(Link other)
        {
            if (other is null) return false;
            return this.Id == other.Id && this.Url == other.Url && this.IsFound == other.IsFound;
        }
        public override bool Equals(object obj) => Equals(obj as Link);
        public override int GetHashCode() => (Id, Url, IsFound).GetHashCode();
    }
}
