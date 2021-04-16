#region Imports

using Witcher.Value;

#endregion

// |---------DO-NOT-REMOVE---------|
//
//     Creator: Taiizor
//     Website: www.Soferity.com
//     Created: 12.Apr.2021
//     Changed: 16.Apr.2021
//     Version: 1.0.0.3
//
// |---------DO-NOT-REMOVE---------|

namespace Witcher
{
    #region Core

    /// <summary>
    /// 
    /// </summary>
    public class Witcher
    {
        #region Property

        /// <summary>
        /// 
        /// </summary>
        public class Property
        {
            /// <summary>
            /// 
            /// </summary>
            public static int MaxOpen
            {
                get => Values.Max;
                set => Values.Max = value;
            }

            /// <summary>
            /// 
            /// </summary>
            public static int DefaultTime => Values.Time;

            /// <summary>
            /// 
            /// </summary>
            public static string NotifyName
            {
                get => Values.NotifyName;
                internal set => Values.NotifyName = value;
            }
        }

        #endregion

        #region Witch

        /// <summary>
        /// 
        /// </summary>
        internal class Witch
        {
            //
        }

        #endregion
    }

    #endregion
}