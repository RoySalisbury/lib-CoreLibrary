using System.Runtime.CompilerServices;

namespace System
{
    /// <summary>
    /// 
    /// </summary>
    public static class Environment
    {
        /// <summary>
        /// 
        /// </summary>
        public static uint ProcessorCount
        {
            get
            {
                try
                {
                    return NativeProcessorCount();
                }
                catch
                {
                    // Not implemented? We know we have at least 1.
                    return 1;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static ulong TickCount
        {
            get
            {
                try
                {
                    return NativeUptimeTickCount();
                }
                catch
                {
                    // Not implemented? Just return 0.
                    return 0;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static Version Version => new Version(1, 0);


        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern uint NativeProcessorCount();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern ulong NativeUptimeTickCount();
    }
}
