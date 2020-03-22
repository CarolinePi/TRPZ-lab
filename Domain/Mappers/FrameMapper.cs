using Data.Interfaces;
using Data.Models;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Mappers
{
    public class FrameMapper : IMapper<IEnumerable<Frame>, IEnumerable<FrameModel>>
    {
        private readonly IMapper<IEnumerable<Material>, IEnumerable<MaterialModel>> _mapper;
        IEnumerable<FrameModel> IMapper<IEnumerable<Frame>, IEnumerable<FrameModel>>.Map(IEnumerable<Frame> frames)
        {
            List<FrameModel> l = new List<FrameModel>();
            foreach (Frame f in frames)
            {
                var frameModel = new FrameModel
                {
                    Materials = _mapper.Map(f.Materials).ToList(),
                    Name = f.Name
                };
                l.Add(frameModel);
            }
            return l;
        }

        IEnumerable<Frame> IMapper<IEnumerable<Frame>, IEnumerable<FrameModel>>.ReverseMap(IEnumerable<FrameModel> frames)
        {
            List<Frame> l = new List<Frame>();
            foreach (FrameModel f in frames)
            {
                var frame = new Frame
                {
                    Materials = _mapper.ReverseMap(f.Materials).ToList(),
                    Name = f.Name
                };
                l.Add(frame);
            }
            return l;
        }

        public FrameMapper(IMapper<IEnumerable<Material>, IEnumerable<MaterialModel>> mapper)
        {
            this._mapper = mapper;
        }
    }
}
