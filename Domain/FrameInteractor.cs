using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    class FrameInteractor: IFrameInteractor
    {
        private IRepository<Frame> framesRepository;
        public IEnumerable<Frame> GetAllFrames()
        {
            return framesRepository.GetAll();
        }
        
        public FrameInteractor(IRepository<Frame> frames)
        {
            this.framesRepository = frames;
        }
    }


}
