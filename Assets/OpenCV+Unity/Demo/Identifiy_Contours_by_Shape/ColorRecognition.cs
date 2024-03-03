using UnityEngine;
using OpenCvSharp;
using static OpenCvSharp.Unity; // Use 'using static' directive for Unity namespace

public class ColorRecognition : MonoBehaviour
{
    public Texture2D inputTexture; // Input texture containing the image
    public Color targetColor; // Color to recognize
    public double threshold = 50.0; // Threshold for color similarity
    
    void Start()
    {
        // Convert Unity Texture2D to OpenCV Mat
        Mat inputMat = TextureToMat(inputTexture); // Now you can use TextureToMat directly

        // Convert Unity Color to OpenCV Scalar (BGR format)
        Scalar targetScalar = new Scalar(targetColor.b * 255, targetColor.g * 255, targetColor.r * 255);

        // Convert input image to HSV color space for better color segmentation
        Mat hsvMat = new Mat();
        Cv2.CvtColor(inputMat, hsvMat, ColorConversionCodes.BGR2HSV);

        // Thresholding based on color similarity
        Mat mask = new Mat();
        Cv2.InRange(hsvMat, new Scalar(0, 100, 100), new Scalar(10, 255, 255), mask); // Example: detect red color in HSV

        // Morphological operations to remove noise
        Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
        Cv2.MorphologyEx(mask, mask, MorphTypes.Close, kernel);

        // Find contours of color regions
        OpenCvSharp.Point[][] contours;
        HierarchyIndex[] hierarchy;
        Cv2.FindContours(mask, out contours, out hierarchy, RetrievalModes.Tree, ContourApproximationModes.ApproxSimple);

        // Draw contours
        Mat resultMat = inputMat.Clone();
        foreach (OpenCvSharp.Point[] contour in contours)
        {
            Cv2.DrawContours(resultMat, new OpenCvSharp.Point[][] { contour }, -1, new Scalar(0, 255, 0), 2); // Draw contours in green
        }

        // Convert result back to Unity Texture2D for display
        Texture2D resultTexture = MatToTexture(resultMat); // Now you can use MatToTexture directly

        // Display the result
        GetComponent<Renderer>().material.mainTexture = resultTexture;
    }
}
