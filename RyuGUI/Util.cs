﻿using System;
using System.Reflection;
using System.Windows.Media.Imaging;

namespace RyuGUI
{
    internal static class Util
    {
        /// <summary>
        /// Compares two versions and returns true if the target version is higher than the current one.
        /// </summary>
        /// <param name="versionTarget">Target version.</param>
        /// <param name="versionCurrent">Current version to compare against.</param>
        /// <returns>A boolean.</returns>
        internal static bool CompareVersionIsHigher(string versionTarget, string versionCurrent)
        {
            Version v1 = new Version(versionTarget);
            Version v2 = new Version(versionCurrent);
            switch (v1.CompareTo(v2))
            {
                case 0: //same
                    return false;

                case 1: //target is higher
                    return true;

                case -1: //target is lower
                    return false;

                default:
                    return false;
            }
        }


        internal static string GetAppVersion()
        {
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            return version;
        }



        // EXTENSIONS
        public static void Save(this BitmapImage image, string filePath)
        {
            BitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));

            using (var fileStream = new System.IO.FileStream(filePath, System.IO.FileMode.Create))
            {
                encoder.Save(fileStream);
            }
        }
    }
}
