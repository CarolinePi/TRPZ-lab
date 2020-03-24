using Data.Interfaces;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class FrameInteractor: IFrameInteractor
    {
        private readonly IRepository<FrameModel> framesRepository;
        private readonly IMapper<IEnumerable<Frame>, IEnumerable<FrameModel>> _mapper;

        public IEnumerable<Frame> GetAllFrames()
        {
            return _mapper.ReverseMap(framesRepository.GetAll());
        }

        public FrameInteractor(IMapper<IEnumerable<Frame>, IEnumerable<FrameModel>> mapper, IRepository<FrameModel> frames)
        {
            this._mapper = mapper;
            this.framesRepository = frames;
        }
    }


}
