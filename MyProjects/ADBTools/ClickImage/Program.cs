using System;
using System.Diagnostics;
using System.Drawing;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;

public class ADB
{
    private string handle;

    public ADB(string handle)
    {
        this.handle = handle;
    }

    public void ScreenCapture(string name)
    {
        ExecuteCommand($"adb -s {this.handle} exec-out screencap -p > {name}.png");
    }

    public void Click(int x, int y)
    {
        ExecuteCommand($"adb -s {this.handle} shell input tap {x} {y}");
    }

    public Tuple<int, int>[] Find(string img = "", string templatePicName = null, double threshold = 0.99)
    {
        if (string.IsNullOrEmpty(templatePicName))
        {
            ScreenCapture(this.handle);
            templatePicName = this.handle + ".png";
        }
        else
        {
            ScreenCapture(templatePicName);
        }

        using (Mat image = CvInvoke.Imread(img), template = CvInvoke.Imread(templatePicName), result = new Mat())
        {
            CvInvoke.MatchTemplate(image, template, result, TemplateMatchingType.CcoeffNormed);
            VectorOfPoint locations = new VectorOfPoint();
            CvInvoke.Threshold(result, result, threshold, 1.0, ThresholdType.ToZero);
            CvInvoke.FindNonZero(result, locations);
            return Array.ConvertAll<Point, Tuple<int, int>>(locations.ToArray(), point => new Tuple<int, int>(point.X, point.Y));
        }
    }

    private void ExecuteCommand(string command)
    {
        Process process = new Process();
        process.StartInfo.FileName = "cmd.exe";
        process.StartInfo.Arguments = "/C " + command;
        process.StartInfo.UseShellExecute = false;
        process.StartInfo.RedirectStandardOutput = true;
        process.Start();
        process.WaitForExit();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        ADB d = new ADB("emulator-5554");
        Tuple<int, int>[] point = d.Find("name.png");
        Console.WriteLine(point[0]);
        d.Click(point[0].Item1, point[0].Item2);
    }
}