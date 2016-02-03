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
using System.Drawing;

namespace TheCodeKing.ActiveButtons.Controls.Themes
{
    internal interface ITheme
    {
        bool IsDisplayed { get; }

        Color BackColor { get; }

        Size ControlBoxSize { get; }

        Point ButtonOffset { get; }

        Size FrameBorder { get; }

        Size SystemButtonSize { get; }
    }
}