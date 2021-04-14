#region Imports

using System;
using System.Windows.Forms;
using Witcher.Enum;
using Witcher.WF.Notify.Manager;
using Witcher.WF.Notify.Standard;
using Witcher.WF.Struct;
using Witcher.WF.Value;
using static Witcher.Witcher.Property;

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

namespace Witcher.WF
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
                                foreach (Form Form in Application.OpenForms)
                                {
                                    if (Form.Text.StartsWith(StandardForm))
                                    {
                                        Form.Close();
                                        Form.Dispose();
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
                if (Data.Font != null && Data.Time >= DefaultTime)
                {
                    if (Property.ActiveOpen <= 0 || (Property.ActiveOpen < MaxOpen && Values.Type == Data.Type && Values.Location == Data.Location && Values.Distance == Data.Distance))
                    {
                        Values.Type = Data.Type;
                        Values.Location = Data.Location;
                        Values.Distance = Data.Distance;

                        switch (Data.Type)
                        {
                            case Enums.NotifyType.Standard:
                                Show(new WitcherStandardWF(Data));
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
                        throw new Exception($"Time must be greater than or equal to {DefaultTime}!");
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
            internal static void Show(Form Form)
            {
                Form.Show();
                Property.ActiveOpen++;
            }
        }

        #endregion
    }

    #endregion
}