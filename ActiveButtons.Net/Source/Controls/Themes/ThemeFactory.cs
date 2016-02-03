/*=============================================================================
*
*	(C) Copyright 2011, Michael Carlisle (mike.carlisle@thecodeking.co.uk)
*
*   http://www.TheCodeKing.co.uk
*  
*	All rights reserved.
*	The code and information is provided "as-is" without waranty of any kind,
*	either expresed or implied.
*
*-----------------------------------------------------------------------------
*	History:
*		01/09/2007	Michael Carlisle				Version 1.0
*=============================================================================
*/
using System.Windows.Forms;
using TheCodeKing.ActiveButtons.Utils;

namespace TheCodeKing.ActiveButtons.Controls.Themes
{
    internal class ThemeFactory
    {
        private readonly Form form;

        public ThemeFactory(Form form)
        {
            this.form = form;
        }

        public ITheme GetTheme()
        {
            if (Win32.DwmIsCompositionEnabled)
            {
                // vista
                return new Aero(form);
            }
            else if (Application.RenderWithVisualStyles && Win32.version > 6)
            {
                // vista basic
                return new Styled(form);
            }
            else if (Application.RenderWithVisualStyles)
            {
                // xp
                return new XPStyle(form);
            }
            else
            {
                return new Standard(form);
            }
        }
    }
}