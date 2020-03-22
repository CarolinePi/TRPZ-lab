using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataDbContext _context;
        public IRepository<MaterialModel> MaterialRepository { get; }
        public IRepository<FrameModel> FrameRepository { get; }

        public UnitOfWork(DataDbContext context, IRepository<MaterialModel> materials, IRepository<FrameModel> frames)
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
