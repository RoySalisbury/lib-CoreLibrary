using System.Reflection;
using System.Runtime.CompilerServices;

namespace System.Runtime.InteropServices
{
    /// <summary>
    /// 
    /// </summary>
    public static partial class RuntimeInformation
    {
        private static object s_osLock = new object();
        private static string s_osDescription = null;
        private static OSTarget s_osTarget = OSTarget.Unknown;

        private const string FrameworkName = "nanoFramework";
        private static string s_frameworkDescription;

        /// <summary>
        /// 
        /// </summary>
        public static string FrameworkDescription
        {
            get
            {
                if (s_frameworkDescription == null)
                {
                    int major = 0;
                    int minor = 0;
                    int build = 0;
                    int revision = 0;

                    Assembly.GetExecutingAssembly().GetVersion(ref major, ref minor, ref build, ref revision);
                    s_frameworkDescription = $"{FrameworkName} {major}.{minor}.{build}.{revision}";
                }

                return s_frameworkDescription;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string OSDescription
        {
            get
            {
                lock (s_osLock)
                {
                    if (null == s_osDescription)
                    {
                        // Call some common native call here 
                        s_osDescription = NativeOSDescription();
                    }
                }

                return s_osDescription;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static OSTarget OSTarget
        {
            get
            {
                lock (s_osLock)
                {
                    if (s_osTarget == OSTarget.Unknown)
                    {
                        // Call some common native call here 
                        var osTarget = NativeOSTarget();
                        switch (osTarget)
                        {
                            default:
                                s_osTarget = OSTarget.Unknown;
                                break;
                        }
                    }
                }

                return s_osTarget;
            }
        }


        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern string NativeOSDescription();

        [MethodImpl(MethodImplOptions.InternalCall)]
        private static extern int NativeOSTarget();
    }
}