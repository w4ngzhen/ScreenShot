using System;

namespace ScreenShot.Core.Event
{
    public class ImageDataAcquiredEventArgs : EventArgs
    {
        public byte[] ImageData { get; }

        public ImageDataAcquiredEventArgs(byte[] imageData)
        {
            ImageData = imageData;
        }
    }
}