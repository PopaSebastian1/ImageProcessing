using Emgu.CV;
using Emgu.CV.Structure;
using System.Windows;
using System.Net.Configuration;
using System;
using System.Windows.Forms;

namespace Algorithms.Tools
{
    public class Tools
    {
        #region Copy
        public static Image<Gray, byte> Copy(Image<Gray, byte> inputImage)
        {
            Image<Gray, byte> result = inputImage.Clone();
            return result;
        }

        public static Image<Bgr, byte> Copy(Image<Bgr, byte> inputImage)
        {
            Image<Bgr, byte> result = inputImage.Clone();
            return result;
        }
        #endregion

        #region Invert
        public static Image<Gray, byte> Invert(Image<Gray, byte> inputImage)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = (byte)(255 - inputImage.Data[y, x, 0]);
                }
            }
            return result;
        }

        public static Image<Bgr, byte> Invert(Image<Bgr, byte> inputImage)
        {
            Image<Bgr, byte> result = new Image<Bgr, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    result.Data[y, x, 0] = (byte)(255 - inputImage.Data[y, x, 0]);
                    result.Data[y, x, 1] = (byte)(255 - inputImage.Data[y, x, 1]);
                    result.Data[y, x, 2] = (byte)(255 - inputImage.Data[y, x, 2]);
                }
            }
            return result;
        }
        #endregion

        #region Convert color image to grayscale image
        public static Image<Gray, byte> Convert(Image<Bgr, byte> inputImage)
        {
            Image<Gray, byte> result = inputImage.Convert<Gray, byte>();
            return result;
        }
        #endregion
        #region ThreshHold
        public static Image<Gray, byte> ThreshHold(Image<Gray, byte> inputImage, byte threshHold)
        {
            Image<Gray, byte> result = new Image<Gray, byte>(inputImage.Size);
            for (int y = 0; y < inputImage.Height; y++)
            {
                for (int x = 0; x < inputImage.Width; x++)
                {
                    if (inputImage.Data[y, x, 0] > threshHold)
                    {
                        result.Data[y, x, 0] = 255;
                    }
                    else
                    {
                        result.Data[y, x, 0] = 0;
                    }
                }
            }
            return result;
        }
        #endregion
        #region Crop Image
        public static Image<Gray, byte> Crop(Image<Gray, byte> inputImage, Tuple<double, double> point1, Tuple<double, double> point2)
        {
            int height = (int)(Math.Abs(point1.Item2 - point2.Item2));
            int width = (int)(Math.Abs(point1.Item1 - point2.Item1));
            Image<Gray, byte> croppedImage = new Image<Gray, byte>(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    croppedImage.Data[y, x, 0] = inputImage.Data[(int)point1.Item2 + y, (int)point1.Item1 + x, 0];
                }
            }
            return croppedImage;
        }
        public static Image<Bgr, byte> CropColor(Image<Bgr, byte> inputImage, Tuple<double, double> point1, Tuple<double, double> point2)
        {
            int height = (int)(Math.Abs(point1.Item2 - point2.Item2));
            int width = (int)((Math.Abs(point1.Item1 - point2.Item1)));
            Image<Bgr, byte> croppedImage = new Image<Bgr, byte>(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    croppedImage.Data[y, x, 0] = inputImage.Data[(int)point1.Item2 + y, (int)point1.Item1 + x, 0];
                    croppedImage.Data[y, x, 1] = inputImage.Data[(int)point1.Item2 + y, (int)point1.Item1 + x, 1];
                    croppedImage.Data[y, x, 2] = inputImage.Data[(int)point1.Item2 + y, (int)point1.Item1 + x, 2];
                }
            }
            return croppedImage;
        }
        #endregion
        #region Mirror Image

        public static Image<Gray, byte> MirrorImage(Image<Gray, byte> initialImage)
        {
            Image<Gray, byte> processedImage = new Image<Gray, byte>(initialImage.Size);
            for (int y = 0; y < initialImage.Height; y++)
            {
                for (int x = 0; x < initialImage.Width; x++)
                {
                    processedImage.Data[y, x, 0] = initialImage.Data[y, initialImage.Width - x - 1, 0];
                }
            }
            return processedImage;
        }
        public static Image<Bgr, byte> MirrorImage(Image<Bgr, byte> initialImage)
        {
            Image<Bgr, byte> processedImage = new Image<Bgr, byte>(initialImage.Size);
            for (int y = 0; y < initialImage.Height; y++)
            {
                for (int x = 0; x < initialImage.Width; x++)
                {
                    processedImage.Data[y, x, 0] = initialImage.Data[y, initialImage.Width - x - 1, 0];
                    processedImage.Data[y, x, 1] = initialImage.Data[y, initialImage.Width - x - 1, 1];
                    processedImage.Data[y, x, 2] = initialImage.Data[y, initialImage.Width - x - 1, 2];
                }
            }
            return processedImage;
        }
        #region Rotate Clockwise
        public static Image<Gray, byte> RotateClockwise(Image<Gray, byte> initialImage)
        {
            Image<Gray, byte> processedImage = new Image<Gray, byte>(initialImage.Height, initialImage.Width);

            for (int y = 0; y < initialImage.Height; y++)
            {
                for (int x = 0; x < initialImage.Width; x++)
                {
                    processedImage.Data[x, initialImage.Height - 1 - y, 0] = initialImage.Data[y, x, 0];
                }
            }
            return processedImage;
        }
        public static Image<Bgr, byte> RotateClockwise(Image<Bgr, byte> initialImage)
        {
            Image<Bgr, byte> processedImage = new Image<Bgr, byte>(initialImage.Height, initialImage.Width);
            for (int y = 0; y < initialImage.Height; y++)
            {
                for (int x = 0; x < initialImage.Width; x++)
                {
                    processedImage.Data[x, initialImage.Height - 1 - y, 0] = initialImage.Data[y, x, 0];
                    processedImage.Data[x, initialImage.Height - 1 - y, 1] = initialImage.Data[y, x, 1];
                    processedImage.Data[x, initialImage.Height - 1 - y, 2] = initialImage.Data[y, x, 2];
                }
            }
            return processedImage;
        }
        #endregion
        #region Rotate AntiClockWise
        public static Image<Gray, byte> RotateAntiClockwisw(Image<Gray, byte> initialImage)
        {
            Image<Gray, byte> processedImage = new Image<Gray, byte>(initialImage.Height, initialImage.Width);
            for (int y = 0; y < initialImage.Height; y++)
            {
                for (int x = 0; x < initialImage.Width; x++)
                {
                    processedImage.Data[x, y, 0] = initialImage.Data[y, initialImage.Width - 1 - x, 0];
                }
            }
            return processedImage;
        }
        public static Image<Bgr, byte> RotateAntiClockwisw(Image<Bgr, byte> initialImage)
        {
            Image<Bgr, byte> processedImage = new Image<Bgr, byte>(initialImage.Height, initialImage.Width);
            for (int y = 0; y < initialImage.Height; y++)
            {
                for (int x = 0; x < initialImage.Width; x++)
                {
                    processedImage.Data[x, y, 0] = initialImage.Data[y, initialImage.Width - 1 - x, 0];
                    processedImage.Data[x, y, 1] = initialImage.Data[y, initialImage.Width - 1 - x, 1];
                    processedImage.Data[x, y, 2] = initialImage.Data[y, initialImage.Width - 1 - x, 2];
                }
            }
            return processedImage;
        }
        #endregion
        #endregion
    }
}