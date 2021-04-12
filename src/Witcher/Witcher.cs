#region Imports

using System.Timers;
using System.Windows.Forms;
using Witcher.Struct;
using Witcher.Value;

#endregion

// |---------DO-NOT-REMOVE---------|
//
//     Creator: Taiizor
//     Website: www.Soferity.com
//     Created: 12.Apr.2021
//     Changed: 13.Apr.2021
//     Version: 1.0.0.1
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

        public class Property
        {
            /// <summary>
            /// 
            /// </summary>
            internal static int ActiveOpen
            {
                get => Values.Active;
                set => Values.Active = value;
            }
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
            public static int Time
            {
                get => Values.Time;
                set
                {
                    Values.Time = value;
                    Notify.Notification.Interval = value;
                }
            }
        }

        #endregion

        #region Notify

        public class Notify
        {
            internal static System.Timers.Timer Notification = new()
            {
                Interval = Property.Time,
                Enabled = true,
            };

            static Notify()
            {
                Notification.Elapsed += new ElapsedEventHandler(NotificationTick);
            }

            public static void Show(Structs.Data Data)
            {
                if (Property.ActiveOpen < Property.MaxOpen)
                {
                    //ShowNotify2(Text, Type, Tema, Zaman);
                }
                else
                {
                    Values.Datas.Add(Data);
                }
            }

            private static void Show(Form Form)
            {

            }

            private static void NotificationTick(object source, ElapsedEventArgs e)
            {
                Notification.Stop();

                Notification.Start();
            }
        }

        #endregion
    }

    #endregion
}