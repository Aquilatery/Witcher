#region Imports

using System.Windows.Forms;
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

            public static void Clear()
            {
                try
                {
                    Values.Datas.Clear();

                    foreach (Form OpenForm in Application.OpenForms)
                    {
                        if (OpenForm.Text.StartsWith(Values.StandardForm))
                        {
                            OpenForm.Close();
                            OpenForm.Dispose();
                        }
                    }
                }
                catch
                {
                    Clear();
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="Data"></param>
            public static void Show(Structs.Data Data)
            {
                if (Property.ActiveOpen <= 0 || (Property.ActiveOpen < Property.MaxOpen && Values.Type == Data.Type && Values.Location == Data.Location))
                {
                    Values.Type = Data.Type;
                    Values.Location = Data.Location;

                    switch (Data.Type)
                    {
                        default:
                            Show(new WitcherStandard(Data));
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
        }

        #endregion
    }

    #endregion
}