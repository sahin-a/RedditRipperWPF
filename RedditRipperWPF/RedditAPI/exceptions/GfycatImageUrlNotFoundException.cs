using System;

namespace RedditRipperWPF.RedditAPI.exceptions
{
    public class GfycatImageUrlNotFoundException : Exception
    {
        public GfycatImageUrlNotFoundException() : base("Couldn't find any direct links on gfycat!")
        {
        }

        public GfycatImageUrlNotFoundException(string message) : base(message)
        {
        }
    }
}
