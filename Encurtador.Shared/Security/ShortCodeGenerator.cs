using System;
using System.Collections.Generic;
using System.Text;

namespace Encurtador.Shared.Security
{
    public class ShortCodeGenerator
    {
        public static string GenerateFromGuid(int length = 8)
        {
            var guid = Guid.NewGuid().ToString("N"); // Remove hífens
            return guid.Substring(0, length);
        }
    }
}
