using System;
using System.Collections.Generic;
using System.Text;

namespace MAMS_Models.Extenions
{
    public static class GuidExtensions
    {
        public static Guid ToGuid(this string text)
        {
            if (string.IsNullOrEmpty(text)) throw new ArgumentNullException(nameof(text));
            if (!Guid.TryParse(text, out var result)) throw new InvalidCastException ("Not a valid guid...");
            
            return result;
        }
    }
}
