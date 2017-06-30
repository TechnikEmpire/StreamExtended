﻿using System.Collections.Concurrent;

namespace SslStreamExtended.Helpers
{
    internal static class BufferPool
    {
        private static readonly ConcurrentQueue<byte[]> buffers = new ConcurrentQueue<byte[]>();

        internal static byte[] GetBuffer(int bufferSize)
        {
            byte[] buffer;
            if (!buffers.TryDequeue(out buffer) || buffer.Length != bufferSize)
            {
                buffer = new byte[bufferSize];
            }

            return buffer;
        }

        internal static void ReturnBuffer(byte[] buffer)
        {
            if (buffer != null)
            {
                buffers.Enqueue(buffer);
            }
        }
    }
}
