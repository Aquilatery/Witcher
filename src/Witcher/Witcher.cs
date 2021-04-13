#region Imports

using System;
using System.Drawing;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Forms.Integration;
using Witcher.Enum;
using Witcher.Notify.Manager;
using Witcher.Notify.Standard;
using Witcher.Struct;
using Witcher.Value;

#endregion

// |---------DO-NOT-REMOVE---------|
//
//     Creator: Taiizor
//     Website: www.Soferity.com
//     Created: 12.Apr.2021
//     Changed: 14.Apr.2021
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

            /// <summary>
            /// 
            /// </summary>
            /// <param name="ST"></param>
            /// <param name="WF"></param>
            /// <param name="WPF"></param>
            /// <returns></returns>
            internal static bool FontControl(Enums.SystemType ST, Font WF, Structs.FontWPF WPF)
            {
                if (ST == Enums.SystemType.WindowsForms)
                {
                    if (WF == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    if (WPF.Family == null)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
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

                                foreach (Window Window in Values.Windows)
                                {
                                    Window.Close();
                                }

                                Values.Windows.Clear();
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
                if (Property.FontControl(Data.System, Data.FontWF, Data.FontWPF) && Data.Time >= Values.Time)
                {
                    if (Property.ActiveOpen <= 0 || (Property.ActiveOpen < Property.MaxOpen && Values.Type == Data.Type && Values.System == Data.System && Values.Location == Data.Location))
                    {
                        Values.Type = Data.Type;
                        Values.System = Data.System;
                        Values.Location = Data.Location;

                        switch (Data.Type)
                        {
                            case Enums.NotifyType.Standard:
                                switch (Data.System)
                                {
                                    case Enums.SystemType.WindowsForms:
                                        Show(new WitcherStandardWF(Data));
                                        break;
                                    case Enums.SystemType.WindowsPresentationFoundation:
                                        WitcherStandardWPF WPF = new(Data);
                                        Values.Windows.Add(WPF);
                                        Show(WPF);
                                        break;
                                }
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
                    if (Data.Time < Values.Time)
                    {
                        throw new Exception($"Time must be greater than or equal to {Values.Time}!");
                    }
                    else
                    {
                        throw new Exception("The font cannot be empty!");
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