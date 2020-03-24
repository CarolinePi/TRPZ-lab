using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Data.Repositories
{
    public class FrameRepository : Repository<FrameModel>
    {
        public FrameRepository(DataDbContext context) : base(context)
        {
        }

        public override IEnumerable<FrameModel> GetAll()
        {
            return _context.Frames.Include(f => f.Materials); 
        }
    }
}
