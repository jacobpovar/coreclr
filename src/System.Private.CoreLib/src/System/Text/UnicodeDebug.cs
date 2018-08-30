// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace System.Text
{
    internal static class UnicodeDebug
    {
        [Conditional("DEBUG")]
        public static void AssertIsHighSurrogateCodePoint(uint codePoint)
        {
            Debug.Assert(UnicodeHelpers.IsHighSurrogateCodePoint(codePoint), $"The value {ToHexString(codePoint)} is not a valid UTF-16 high surrogate code point.");
        }

        [Conditional("DEBUG")]
        public static void AssertIsLowSurrogateCodePoint(uint codePoint)
        {
            Debug.Assert(UnicodeHelpers.IsLowSurrogateCodePoint(codePoint), $"The value {ToHexString(codePoint)} is not a valid UTF-16 low surrogate code point.");
        }

        [Conditional("DEBUG")]
        public static void AssertIsValidCodePoint(uint codePoint)
        {
            Debug.Assert(UnicodeHelpers.IsValidCodePoint(codePoint), $"The value {ToHexString(codePoint)} is not a valid Unicode code point.");
        }

        [Conditional("DEBUG")]
        public static void AssertIsValidScalar(uint scalarValue)
        {
            Debug.Assert(UnicodeHelpers.IsValidUnicodeScalar(scalarValue), $"The value {ToHexString(scalarValue)} is not a valid Unicode scalar value.");
        }

        /// <summary>
        /// Formats a code point as the hex string "U+XXXX".
        /// </summary>
        /// <remarks>
        /// The input value doesn't have to be a real code point in the Unicode codespace. It can be any integer.
        /// </remarks>
        private static string ToHexString(uint codePoint)
        {
            return FormattableString.Invariant($"U+{codePoint:X4}");
        }
    }
}