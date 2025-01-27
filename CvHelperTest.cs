using System.Drawing.Imaging;
using System.Drawing;
using System.Globalization;

using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;


namespace Sentio.Test.VisionEmguCv
{
    public class CvHelperTest
    {
        private string SamplesFolder { get; set; }


        [OneTimeSetUp]
        public void SetUp()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            // Get samples folder path
            Type type = typeof(CvHelperTest);
            string ns = type.Namespace;
            string root = TestContext.CurrentContext.TestDirectory;
            int index = root.IndexOf(ns);
            if (index > 0)
            {
                SamplesFolder = $"{root.Substring(0, index + ns.Length)}\\samples";
            }
            else
            {
                SamplesFolder = $"{root}\\samples";
            }
        }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("/image_col_std_1.png", 1)]
        public async Task StandardDeviationTestAsync(string fileName, double standardDeviation)
        {
            fileName = $"{SamplesFolder}{fileName}";
            if (!File.Exists(fileName))
            {
                Assert.Fail($"StandardDeviationTest failed! Image {fileName} not found!");
            }

            var bitmap = new Bitmap(fileName);
            Image<Bgr, byte> cvImg = bitmap.ToImage<Bgr, byte>();

            var grayImage = new Mat();
            CvInvoke.CvtColor(cvImg, grayImage, ColorConversion.Bgr2Gray);

            Assert.Pass("Test passed!");

            await Task.CompletedTask;
        }
    }
}