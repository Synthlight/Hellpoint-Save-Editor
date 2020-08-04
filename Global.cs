using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Save_Editor {
    public static class Global {
        public static string ToHexString(byte[] bytes) {
            var hex = new StringBuilder(bytes.Length * 2);
            foreach (var b in bytes) {
                hex.AppendFormat("{0:x2}", b);
            }
            return hex.ToString();
        }

        public static byte[] StringToByteArray(string hex) {
            var numberChars = hex.Length;
            var bytes       = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2) {
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            }
            return bytes;
        }

        public static string FromHexStringToGuidString(this string hexString) {
            return new Guid(StringToByteArray(hexString.Replace(" ", "").Replace("-", ""))).ToString();
        }

        public static void CopyTo<K, V>(this IEnumerable<KeyValuePair<K, V>> source, Dictionary<K, V> dest) {
            source.ToList().ForEach(x => dest.Add(x.Key, x.Value));
        }
    }
}