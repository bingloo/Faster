﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FlyUI.Library.MaterialLibs
{
    public enum AnimationDirection
    {
        In, //In. Stops if finished.
        Out, //Out. Stops if finished.
        InOutIn, //Same as In, but changes to InOutOut if finished.
        InOutOut, //Same as Out.
        InOutRepeatingIn, // Same as In, but changes to InOutRepeatingOut if finished.
        InOutRepeatingOut // Same as Out, but changes to InOutRepeatingIn if finished.
    }
}
