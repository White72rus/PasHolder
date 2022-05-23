using System;

namespace PassHolder.Infrastructure.Services.FrameService
{
    public class Frame : IFrame
    {
        public string Name { get; set; }
        public Uri Uri { get; set ; }
    }
}
