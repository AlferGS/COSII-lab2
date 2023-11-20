using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessing
{
    public partial class Form1 : Form
    {
        private readonly Image defaultImage;
        private Image sourceImage;

        public Form1()
        {
            InitializeComponent();
            defaultImage = sourcePictureBox.Image;
            DisableAllControlElements();
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            sourceImage = Image.FromFile(openFileDialog.FileName);
            sourcePictureBox.Image = sourceImage;
            processedPictureBox.Image = sourceImage;
            EnableAllControlElements();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            processedPictureBox.Image.Save(saveFileDialog.FileName);            
        }

        private void CloseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sourcePictureBox.Image = defaultImage;
            processedPictureBox.Image = defaultImage;
            DisableAllControlElements();
        }

        private void SourceButton_Click(object sender, EventArgs e)
        {
            processedPictureBox.Image = sourceImage;
        }

        private async void LinearContrastingButton_Click(object sender, EventArgs e)
        {
            //var filter = new LinearCorrectionProcessor(0, 255);
            //processedPictureBox.Image = await filter.ProcessAsync(processedPictureBox.Image);
        }

        private async void MaxFilterButton_Click(object sender, EventArgs e)
        {

            var filter = new MaxFilter();
            processedPictureBox.Image = await filter.ProcessAsync(sourceImage);
        }

        private async void MinFilterButton_Click(object sender, EventArgs e)
        {
            //var filter = new MinFilter();
            //processedPictureBox.Image = await filter.ProcessAsync(sourceImage);
        }

        private async void MinMaxFilterButton_Click(object sender, EventArgs e)
        {
            //var minFilter = new MinFilter();
            //var maxFilter = new MaxFilter();
            //var image = await minFilter.ProcessAsync(sourceImage);
            //processedPictureBox.Image = await maxFilter.ProcessAsync(image);
        }

        private async void Button1_Click(object sender, EventArgs e)
        {
            //var binorizer = new Binorizer((byte)trackBar1.Value);
            //var binorizer = new Binorizer(116);
            //var extractor = new AreaExtractor();

            //var binaryImage = await binorizer.ProcessAsync(sourceImage);
            //var extractedImage = await extractor.ProcessAsync(binaryImage);

            //using (var writer = new StreamWriter(@"D:\console.txt"))
            //{
            //    var prms = new List<int>();
            //    var squrs = new List<int>();
            //    var cmpctns = new List<int>();
            //    var mass = new List<Vector>();
            //    var elon = new List<double>();
            //    foreach (var id in extractor.IdList)
            //    {
            //        var perim = new PerimeterExtractor(id);
            //        var square = new SquareExtractor(id);
            //        var massextr = new MassCenterExtractor(id);

            //        prms.Add(await perim.ProcessAsync(extractedImage));
            //        squrs.Add(await square.ProcessAsync(extractedImage));
            //        cmpctns.Add(prms.Last() * prms.Last() / squrs.Last());

            //        var vector = await massextr.ProcessAsync(extractedImage);
            //        mass.Add(new Vector(vector.X / squrs.Last(), vector.Y / squrs.Last()));
            //        elon.Add(await GetElingation(extractedImage, id, mass.Last()));
            //    }

            //    Console.SetOut(writer);
            //    for (int i = 0; i < prms.Count; ++i)
            //    {
            //        Console.WriteLine($"{prms[i]}; {squrs[i]}; {cmpctns[i]}; {mass[i].X}-{mass[i].Y}; {elon[i]}");
            //    }
            //}

            //processedPictureBox.Image = extractedImage;
        }

        private void DisableAllControlElements()
        {
            sourceButton.Enabled = false;
            minFilterButton.Enabled = false;
            maxFilterButton.Enabled = false;
            minMaxFilterButton.Enabled = false;
            minBrightnessTextBox.Enabled = false;
            maxBrightnessTextBox.Enabled = false;
            linearContrastingButton.Enabled = false;
            saveToolStripMenuItem.Enabled = false;
            closeToolStripMenuItem.Enabled = false;
        }

        private void EnableAllControlElements()
        {
            sourceButton.Enabled = true;
            minFilterButton.Enabled = true;
            maxFilterButton.Enabled = true;
            minMaxFilterButton.Enabled = true;
            minBrightnessTextBox.Enabled = true;
            maxBrightnessTextBox.Enabled = true;
            linearContrastingButton.Enabled = true;
            saveToolStripMenuItem.Enabled = true;
            closeToolStripMenuItem.Enabled = true;
        }

        private void MinBrightnessTextBox_Leave(object sender, EventArgs e)
        {
            var value = minBrightnessTextBox.Text;
            if (value.Any(c => !char.IsDigit(c)))
            {
                minBrightnessTextBox.Text = "0";
            }
            else if (!int.TryParse(value, out int min) || min > 255)
            {
                minBrightnessTextBox.Text = "0";
            }
        }

        private void MaxBrightnessTextBox_Leave(object sender, EventArgs e)
        {
            var value = maxBrightnessTextBox.Text;
            if (value.Any(c => !char.IsDigit(c)))
            {
                maxBrightnessTextBox.Text = "255";
            }
            else if (!int.TryParse(value, out int max) || max > 255)
            {
                maxBrightnessTextBox.Text = "255";
            }
        }

        //private async Task<double> GetElingation(Image image, byte id, Vector massCenter)
        //{
        //    var discrete20 = new DiscreteCentralMoment(id, massCenter, 2, 0);
        //    var discrete02 = new DiscreteCentralMoment(id, massCenter, 0, 2);
        //    var discrete11 = new DiscreteCentralMoment(id, massCenter, 1, 1);

        //    long m20 = await discrete20.ProcessAsync(image);
        //    long m02 = await discrete02.ProcessAsync(image);
        //    long m11 = await discrete11.ProcessAsync(image);

        //    long m202 = (m20 - m02);
        //    long subRoot = m202 * m202 + 4 * m11 * m11;
        //    var root = Math.Sqrt(subRoot);
        //    var up = m20 + m02 + root;
        //    var down = m20 + m02 - root;
        //    return up / down;
        //}
    }
}
