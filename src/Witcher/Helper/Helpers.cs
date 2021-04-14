namespace Witcher.Helper
{
    /// <summary>
    /// 
    /// </summary>
    internal class Helpers
    {
        #region Helpers
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CX"></param>
        /// <param name="CY"></param>
        /// <param name="FX"></param>
        /// <param name="FY"></param>
        /// <param name="FW"></param>
        /// <param name="FH"></param>
        /// <returns></returns>
        internal static bool Contains(int CX, int CY, int FX, int FY, int FW, int FH)
        {
            try
            {
                if (CX >= FX && CX <= FX + FW && CY >= FY && CY <= FY + FH)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CX"></param>
        /// <param name="CY"></param>
        /// <param name="FX"></param>
        /// <param name="FY"></param>
        /// <param name="FW"></param>
        /// <param name="FH"></param>
        /// <returns></returns>
        internal static bool Contains(int CX, int CY, double FX, double FY, double FW, double FH)
        {
            try
            {
                return Contains(CX, CY, (int)FX, (int)FY, (int)FW, (int)FH);
            }
            catch
            {
                return false;
            }
        }
        #endregion
    }
}