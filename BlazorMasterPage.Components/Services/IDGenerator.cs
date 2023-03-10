using System;
using System.Reflection.Emit;
using System.Threading;

namespace BlazorMasterPage.Components.Services
{
    public sealed class IDGenerator : IIDGenerator
    {
        private const string Encode32Chars = "0123456789ABCDEFGHIJKLMNOPQRSTUV";

        private static long LastId = DateTime.UtcNow.Ticks;

        private static readonly ThreadLocal<char[]> CharBufferThreadLocal = new(() => new char[13]);

        private static string GenerateImpl(long id)
        {
            var buffer = CharBufferThreadLocal.Value;

            buffer[0] = Encode32Chars[(int)(id >> 60) & 31];
            buffer[1] = Encode32Chars[(int)(id >> 55) & 31];
            buffer[2] = Encode32Chars[(int)(id >> 50) & 31];
            buffer[3] = Encode32Chars[(int)(id >> 45) & 31];
            buffer[4] = Encode32Chars[(int)(id >> 40) & 31];
            buffer[5] = Encode32Chars[(int)(id >> 35) & 31];
            buffer[6] = Encode32Chars[(int)(id >> 30) & 31];
            buffer[7] = Encode32Chars[(int)(id >> 25) & 31];
            buffer[8] = Encode32Chars[(int)(id >> 20) & 31];
            buffer[9] = Encode32Chars[(int)(id >> 15) & 31];
            buffer[10] = Encode32Chars[(int)(id >> 10) & 31];
            buffer[11] = Encode32Chars[(int)(id >> 5) & 31];
            buffer[12] = Encode32Chars[(int)id & 31];

            return new string(buffer, 0, buffer.Length);
        }

        public string Generate => GenerateImpl(Interlocked.Increment(ref LastId));
    }
}
