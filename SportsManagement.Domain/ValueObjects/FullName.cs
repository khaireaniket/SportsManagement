using System;

namespace SportsManagement.Domain.ValueObjects
{
    public class FullName
    {
        public string First { get; }

        public string Last { get; }

        public FullName(string first, string last)
        {
            if (string.IsNullOrWhiteSpace(first)) throw new Exception("First name is invalid");
            if (string.IsNullOrWhiteSpace(last)) throw new Exception("Last name is invalid");

            First = first;
            Last = last;
        }
    }
}
