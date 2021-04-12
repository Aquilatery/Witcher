#region Imports

using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Timers;
using System.Windows.Forms;
using Witcher.Notify.Standard;
using Witcher.Struct;
using Witcher.Value;
using static Taskbar.Enum.Enums;

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

        /// <summary>
        /// 
        /// </summary>
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
            internal static int ControlTime
            {
                get => (int)Notify.Control.Interval;
                set => Notify.Control.Interval = value;
            }

            /// <summary>
            /// 
            /// </summary>
            internal static int NotificationTime
            {
                get => (int)Notify.Notification.Interval;
                set => Notify.Notification.Interval = value;
            }
        }

        #endregion

        #region Notify

        /// <summary>
        /// 
        /// </summary>
        public class Notify
        {
            /// <summary>
            /// 
            /// </summary>
            static Notify()
            {
                Control.Elapsed += new ElapsedEventHandler(ControlTick);
                Notification.Elapsed += new ElapsedEventHandler(NotificationTick);
            }

            /// <summary>
            /// 
            /// </summary>
            internal static System.Timers.Timer Control = new()
            {
                Interval = 50,
                Enabled = true
            };

            /// <summary>
            /// 
            /// </summary>
            internal static System.Timers.Timer Notification = new()
            {
                Interval = 50,
                Enabled = true
            };

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Data"></param>
            public static void Show(Structs.Data Data)
            {
                Values.Data.Location = Data.Location;
                if (Property.ActiveOpen < Property.MaxOpen)
                {
                    switch (Data.Type)
                    {
                        default:
                            Show(new NYB(Data));
                            break;
                    }
                }
                else
                {
                    Values.Datas.Add(Data);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Form"></param>
            private static void Show(Form Form)
            {
                Form.Show();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="source"></param>
            /// <param name="e"></param>
            private static void ControlTick(object source, ElapsedEventArgs e)
            {
                Control.Stop();

                foreach (Form OpenForm in Application.OpenForms)
                {
                    if (OpenForm.Text.Contains("NYS"))
                    {
                        int ID1 = Convert.ToInt32(OpenForm.Text.Replace("NYS", ""));

                        if (ID1 >= 1)
                        {
                            bool State = true;

                            foreach (Form CheckForm in Application.OpenForms)
                            {
                                if (CheckForm.Text.Contains("NYS"))
                                {
                                    int ID2 = ID1 - 1;
                                    if (CheckForm.Text == "NYS" + ID2)
                                    {
                                        State = false;
                                        break;
                                    }
                                }
                            }

                            if (State)
                            {
                                if (Values.Data.Location == EdgeLocationType.BotRight || Values.Data.Location == EdgeLocationType.BotLeft)
                                {
                                    OpenForm.Location = new Point(OpenForm.Location.X, OpenForm.Location.Y + OpenForm.Height);
                                }
                                else
                                {
                                    OpenForm.Location = new Point(OpenForm.Location.X, OpenForm.Location.Y - OpenForm.Height);
                                }

                                OpenForm.Text = "NYS" + (ID1 - 1);
                                break;
                            }
                        }
                    }
                }

                Control.Start();
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="source"></param>
            /// <param name="e"></param>
            private static void NotificationTick(object source, ElapsedEventArgs e)
            {
                Notification.Stop();

                if (Values.Datas.Any() && Property.ActiveOpen < Property.MaxOpen)
                {
                    foreach (Structs.Data Data in Values.Datas)
                    {
                        Show(Data);
                        Values.Datas.Remove(Data);
                        break;
                    }
                }

                Notification.Start();
            }
        }

        #endregion
    }

    #endregion
}