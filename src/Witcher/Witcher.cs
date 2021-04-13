#region Imports

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using System.Windows.Interop;
using Witcher.Enum;
using Witcher.Notify.Manager;
using Witcher.Notify.Standard;
using Witcher.Notify.Test;
using Witcher.Struct;
using Witcher.Value;

#endregion

// |---------DO-NOT-REMOVE---------|
//
//     Creator: Taiizor
//     Website: www.Soferity.com
//     Created: 12.Apr.2021
//     Changed: 13.Apr.2021
//     Version: 1.0.0.2
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
            public static int ActiveOpen
            {
                get => Values.Active;
                internal set => Values.Active = value;
            }

            /// <summary>
            /// 
            /// </summary>
            public static int DeactiveOpen => Values.Datas.Count;

            /// <summary>
            /// 
            /// </summary>
            public static int TotalOpen => ActiveOpen + DeactiveOpen;

            /// <summary>
            /// 
            /// </summary>
            public static int MaxOpen
            {
                get => Values.Max;
                set => Values.Max = value;
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
                WitcherManagement M = new();
                M.Show();
            }

            /// <summary>
            /// 
            /// </summary>
            public static void ClearActive()
            {
                try
                {
                    if (Property.ActiveOpen > 0)
                    {
                        ClearNotify(Enums.NotifyType.Standard);
                        ClearNotify(Enums.NotifyType.Test);
                    }
                }
                catch
                {
                    ClearActive();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public static void ClearDeactive()
            {
                try
                {
                    if (Property.DeactiveOpen > 0)
                    {
                        Values.Datas.Clear();
                    }
                }
                catch
                {
                    ClearDeactive();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public static void ClearNotify(Enums.NotifyType Type)
            {
                try
                {
                    if (Property.ActiveOpen > 0)
                    {
                        switch (Type)
                        {
                            case Enums.NotifyType.Standard:
                                foreach (Form Form in System.Windows.Forms.Application.OpenForms)
                                {
                                    if (Form.Text.StartsWith(Values.StandardForm))
                                    {
                                        Form.Close();
                                        Form.Dispose();
                                    }
                                }
                                break;
                            case Enums.NotifyType.Test:
                                foreach (Window Window in System.Windows.Application.Current.Windows)
                                {
                                    if (Window.Title.StartsWith(Values.StandardForm))
                                    {
                                        Window.Close();
                                    }
                                }
                                break;
                        }
                    }
                }
                catch
                {
                    ClearNotify(Type);
                }
            }

            /// <summary>
            /// 
            /// </summary>
            public static void ClearAll()
            {
                try
                {
                    if (Property.TotalOpen > 0)
                    {
                        ClearDeactive();
                        ClearNotify(Enums.NotifyType.Standard);
                        ClearNotify(Enums.NotifyType.Test);
                    }
                }
                catch
                {
                    ClearAll();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Data"></param>
            public static void Show(Structs.Data Data)
            {
                if (Data.Font != null && Data.Time >= Values.Time)
                {
                    if (Property.ActiveOpen <= 0 || (Property.ActiveOpen < Property.MaxOpen && Values.Type == Data.Type && Values.Location == Data.Location))
                    {
                        Values.Type = Data.Type;
                        Values.Location = Data.Location;

                        switch (Data.Type)
                        {
                            case Enums.NotifyType.Standard:
                                Show(new WitcherStandard(Data));
                                break;
                            case Enums.NotifyType.Test:
                                Show(new WIDGET(Data));
                                break;
                        }
                    }
                    else
                    {
                        Values.Datas.Add(Data);
                    }
                }
                else
                {
                    if (Data.Font == null)
                    {
                        throw new Exception("The font cannot be empty!");
                    }
                    else
                    {
                        throw new Exception($"Time must be greater than or equal to {Values.Time}!");
                    }
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
            /// <param name="Window"></param>
            private static void Show(Window Window)
            {
                ElementHost.EnableModelessKeyboardInterop(Window);
                Window.Show();
            }
        }

        #endregion
    }

    #endregion
}