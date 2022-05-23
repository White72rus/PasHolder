using System;

namespace PassHolder.Infrastructure.Services.FrameService
{
    public interface IFrame
    {
        public string Name { get; set; }
        public Uri Uri { get; set; }
    }
}
