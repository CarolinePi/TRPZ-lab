using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories
{
    public class MaterialRepository : Repository<MaterialModel>
    {
        public MaterialRepository(DataDbContext context) : base(context)
        {
        }

        public override IEnumerable<MaterialModel> GetAll()
        {
            return _context.Materials.Include(m => m.FrameModel);
        }
    }
}
