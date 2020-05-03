using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OpenCvSharp;


namespace VirusHackKodShredinger.VideoCore
{
    public class VideoCaptureSimple 
    {
        public void Run()
        {
            // Opens MP4 file (ffmpeg is probably needed)
            var capture = new VideoCapture(0);

            int sleepTime = (int)Math.Round(1000 / capture.Fps);

            using var window = new Window("capture");
            // Frame image buffer
            Mat image = new Mat();
            
            // When the movie playback reaches end, Mat.data becomes NULL.
            while (true)
            {
                capture.Read(image); // same as cvQueryFrame
                if (image.Empty())
                    break;

                window.ShowImage(image);
                Cv2.WaitKey(sleepTime);
            }
        }

    }
}