#region Imports

using System;
using System.Windows;
using Witcher.Enum;
using Witcher.Message;
using Witcher.WPF.Notify.Manager;
using Witcher.WPF.Notify.Standard;
using Witcher.WPF.Struct;
using Witcher.WPF.Value;
using static Witcher.Witcher.Property;

#endregion

// |---------DO-NOT-REMOVE---------|
//
//     Creator: Taiizor
//     Website: www.Soferity.com
//     Created: 12.Apr.2021
//     Changed: 22.Dec.2021
//     Version: 1.0.0.3
//
// |---------DO-NOT-REMOVE---------|

namespace Witcher.WPF
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
            /// <param name="Font"></param>
            /// <returns></returns>
            internal static bool FontControl(Structs.Font Font)
            {
                if (Font.Family == null)
                {
                    return false;
                }
                else
                {
                    return true;
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
                WitcherManagement WM = new();
                WM.Show();
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
                        ClearNotify();
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
            public static void ClearNotify()
            {
                try
                {
                    if (Property.ActiveOpen > 0)
                    {
                        foreach (Window Window in Application.Current.Windows)
                        {
                            if (Window.Title.StartsWith(NotifyName))
                            {
                                Window.Close();
                            }
                        }
                    }
                }
                catch
                {
                    ClearNotify();
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
                        ClearNotify();
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
                if (Property.FontControl(Data.Font) && Data.Time >= DefaultTime)
                {
                    if (Property.ActiveOpen <= 0 || (Property.ActiveOpen < MaxOpen && Values.Type == Data.Type && Values.Location == Data.Location && Values.Distance == Data.Distance && Values.Size.Width == Data.Size.Width && Values.Size.Height == Data.Size.Height))
                    {
                        Values.Type = Data.Type;
                        Values.Location = Data.Location;
                        Values.Distance = Data.Distance;
                        Values.Size = Data.Size;

                        switch (Data.Type)
                        {
                            case Enums.NotifyType.Standard:
                                Show(new WitcherStandardWPF(Data));
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
                    if (Data.Time < DefaultTime)
                    {
                        throw new Exception(Messages.SmallerTime);
                    }
                    else
                    {
                        throw new Exception(Messages.EmptyFont);
                    }
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Window"></param>
            internal static void Show(Window Window)
            {
                Window.Show();
                Property.ActiveOpen++;
            }
        }

        #endregion
    }

    #endregion
}