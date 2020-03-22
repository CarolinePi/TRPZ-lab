using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<Material> MaterialRepository { get; }
        IRepository<Frame> FrameRepository { get; }
        void Save();
    }
}
