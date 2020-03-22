using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly DataDbContext _context;
        public IRepository<Material> MaterialRepository { get; }
        public IRepository<Frame> FrameRepository { get; }

        public UnitOfWork(DataDbContext context, IRepository<Material> materials, IRepository<Frame> frames)
            {
                _context = context;
                MaterialRepository = materials;
                FrameRepository = frames;
            }

            public void Save()
            {
                _context.SaveChanges();
            }

        void IUnitOfWork.Save()
        {
            throw new NotImplementedException();
        }
    } 
}
