using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<MaterialModel> MaterialRepository { get; }
        IRepository<FrameModel> FrameRepository { get; }
        void Save();
    }
}
