using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IFrameInteractor
    {
        IEnumerable<Frame> GetAllFrames();
    }
}
