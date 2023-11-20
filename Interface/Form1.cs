using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;
using System.Threading;
using ImageAnalysis.Snapshot;
using Tools;
using ImageAnalysis.Сlustering;
using ImageProcessingTools.Extensions;
using OxyPlot;
using OxyPlot.Series;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;


namespace Interface
{
    public partial class Form1 : Form
    {
        private readonly Image defaultImage;
        private Image sourceImage;
        private Image bufferImage;

        public static readonly int[] colors = new int[]
           {
                0xff0000, 0x0000ff, 0x00ff00, 0xff1493, 0x8b4513, 0x008080,
                0x0000ff, 0x000080, 0x008000, 0x80ff80, 0xffff80, 0xff8080, 0xff80ff, 0xc0c0c0, 0xff, 0x80ff,
                0xffff, 0xff00, 0xffff00, 0xff0000, 0xff00ff, 0x808080, 0xc0, 0x40c0, 0xc0c0, 0xc000, 0xc0c000,
                0xc00000, 0xc000c0, 0x404040, 0x80, 0x4080, 0x8080, 0xc0ffc0, 0x8000, 0x800000, 0x800080, 0,
                0x40, 0x404080, 0x4040, 0x4000, 0x404000, 0x400000, 0x400040
           };

        public List<Shape> ShapeList = new List<Shape>();

        enum Direction
        {
            Up, 
            Down,
            Left,
            Right
        }

        public class Shape
        {
            public int Id;              // Id объекта
            public int ClusterId;       // Id кластера
            //public Color BordColor;     // Цвет краевых пикселей
            
            public int Perimeter;       // Периметр
            public int Square;          // Площадь
            public double Elongation;   // Вытянутость

            public List<Point> borderPixels;    // Позиции краевых пикселей

            public Shape(int id) // Конструкторы класса
            {
                this.Id = id;
                borderPixels = new List<Point>();
            }
            public Shape() {
                borderPixels = new List<Point>();
            }

            public double Distance(double[] center) { // Определение дистанции
                return Math.Sqrt(Math.Pow(center[0] - this.Perimeter, 2.0) +    // Perimeter
                                 Math.Pow(center[1] - this.Square, 2.0) +       // Square
                                 Math.Pow(center[2] - this.Elongation, 2.0));   // Elongation
            }   // Определение дистанции

            public Shape Clone()
            {
                return new Shape()
                {
                    Id = Id,
                    ClusterId = ClusterId,
                    Perimeter = Perimeter,
                    Square = Square,
                    Elongation = Elongation,
                };
            }   // Создание копии 

            public override string ToString()
            {
                return "\t\tId: " + Id.ToString() +
                   "\n\t\t  ClasterId: " + ClusterId.ToString() +
                   "\n\t\t  Square: " + Square.ToString() + 
                   "\n\t\t  Perimeter: " + Perimeter.ToString() +
                   "\n\t\t  Elongation: " + Elongation.ToString();
            }   // Перевод данных в строку
        }

        public class Cluster
        {
            public int Number { get; set; }             // Номер кластера
            public double[] Center { get; set; }        // Центроид кластера
            public List<Shape> Members { get; set; }    // Список фигур, принадлежащих кластеру

            public Color BordColor;     // Цвет краевых пикселей

            public Cluster(int number, double[] center) { // Конструктор класса 
                Number = number;
                Center = center;
                Members = new List<Shape>();
            }

            public void UpdateCenter() // Метод для обновления центроида кластера по средним значениям характеристик фигур
            {
                if(Members.Count > 0)
                {
                    Center[0] = Members.Average(s => s.Perimeter); 
                    Center[1] = Members.Average(s => s.Square);
                    Center[2] = Members.Average(s => s.Elongation);
                }

            }

            public override string ToString()
            {
                return "\nNumber: " + Number.ToString() + 
                   "\n  Center: " + Center.ToString() + 
                   "\n  Color: " + BordColor.ToString() +
                   "\n  Members Count: " + Members.Count().ToString();
            }   // Перевод данных в строку
        }

        public Form1() //1
        {
            InitializeComponent();
            DisableAllControlElements();            //Ожидаем открытия изображения пользователя
            defaultImage = sourcePictureBox.Image;
        }

        // ---------------------------------lab1-----------------------------------------------       
        #region Lab1

        #region File Menu
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e) //1
        {
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            sourceImage = Image.FromFile(openFileDialog.FileName);
            sourcePictureBox.Image = sourceImage;
            processedPictureBox.Image = sourceImage;        //Помещаем выбранное изображение в окна вывода
            EnableAllControlElements();
            ShowBrightnessLevels();
        }
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e) //1
        {
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            processedPictureBox.Image.Save(saveFileDialog.FileName);
        }
        private void CloseToolStripMenuItem_Click(object sender, EventArgs e) //1
        {
            sourcePictureBox.Image = defaultImage;
            processedPictureBox.Image = defaultImage;
            DisableAllControlElements();
            plotView1.Model = null;
        }
        #endregion

        #region Source Image
        private void SourceButton_Click(object sender, EventArgs e) //1
        {
            processedPictureBox.Image = sourceImage;
            ShowBrightnessLevels();
        }
        #endregion
        
        #region Linear Contrasting
        private void LinearContrastingButton_Click(object sender, EventArgs e) //1
        {
            var image = accumulativeProcessing.Checked ? processedPictureBox.Image : sourceImage;
            byte.TryParse(minBrightnessTextBox.Text, out byte min);
            byte.TryParse(maxBrightnessTextBox.Text, out byte max);
            //processedPictureBox.Image = (Image)LinearContrasting((Bitmap)image, 1, min, max);
            //processedPictureBox.Image = (Image)ApplyLinearCorrection((Bitmap)image, 1f, min, max);
            processedPictureBox.Image = (Image)LinearContrasting((Bitmap)image, min, max);
            ShowBrightnessLevels();
        }
        static Bitmap LinearContrasting(Bitmap sourceImage, float gmin, float gmax) //1
        {
            // Валидация входных значений
            if (sourceImage == null) throw new ArgumentNullException("sourceImage");
            if (gmin < 0 || gmin > 255) throw new ArgumentOutOfRangeException("min");
            if (gmax < 0 || gmax > 255) throw new ArgumentOutOfRangeException("max");
            if (gmin > gmax) throw new ArgumentException("min must be less than or equal to max");

            // Создание копии для результируещего изображения
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height, sourceImage.PixelFormat);

            // Необходимо пройти по изображению и определить изначальные значения яркости в разных диапозонах RGB
            float fminR = 255, fminG = 255, fminB = 255;
            float fmaxR = 0, fmaxG = 0, fmaxB = 0;

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color pixelColor = sourceImage.GetPixel(x, y);
                    // R
                    if (pixelColor.R < fminR) fminR = pixelColor.R;
                    if (pixelColor.R > fmaxR) fmaxR = pixelColor.R;
                    // G
                    if (pixelColor.G < fminG) fminG = pixelColor.G;
                    if (pixelColor.G > fmaxG) fmaxG = pixelColor.G;
                    // B
                    if (pixelColor.B < fminB) fminB = pixelColor.B;
                    if (pixelColor.B > fmaxB) fmaxB = pixelColor.B;
                }
            }

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    // Извлекаем исходный пиксель
                    Color f = sourceImage.GetPixel(x, y);
                    // Подставляем значения в формулу
                    float newR = ((((float)f.R - fminR) / (fmaxR - fminR)) * (gmax - gmin)) + gmin;
                    float newG = ((((float)f.G - fminG) / (fmaxG - fminG)) * (gmax - gmin)) + gmin;
                    float newB = ((((float)f.B - fminB) / (fmaxB - fminB)) * (gmax - gmin)) + gmin;

                    Color g = Color.FromArgb(f.A, (int)newR, (int)newG, (int)newB);
                    resultImage.SetPixel(x, y, g);
                }
            }
            return resultImage;
        }
        #endregion
        
        #region Max Filter
        private void MaxFilterButton_Click(object sender, EventArgs e) //1
        {
            var image = accumulativeProcessing.Checked ? processedPictureBox.Image : sourceImage;
            processedPictureBox.Image = (Image)MaxFilter((Bitmap)image);
            ShowBrightnessLevels();
        }
        static Bitmap MaxFilter(Bitmap sourceImage) //1
        {
            // Валидация входных значений
            if (sourceImage == null) throw new ArgumentNullException("sourceImage");

            // Создание копии для результируещего изображения
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height, sourceImage.PixelFormat);

            for (int y = 1; y < sourceImage.Height - 1; y++)
            {
                for (int x = 1; x < sourceImage.Width - 1; x++)
                {
                    byte[] redValues = new byte[8];
                    byte[] greenValues = new byte[8];
                    byte[] blueValues = new byte[8];

                    byte index = 0;
                    for (int j = (y - 1); j <= (y + 1); j++)
                    {
                        for (int i = (x - 1); i <= (x + 1); i++, index++)
                        {
                            if (j == y && i == x)
                            {
                                index--;
                                continue;
                            }

                            redValues[index] = sourceImage.GetPixel(i, j).R;
                            greenValues[index] = sourceImage.GetPixel(i, j).G;
                            blueValues[index] = sourceImage.GetPixel(i, j).B;
                        }
                    }

                    Color pixelColor = Color.FromArgb(Max(redValues), Max(greenValues), Max(blueValues));
                    resultImage.SetPixel(x, y, pixelColor);
                }
            }

            return resultImage;
        }
        static byte Max(byte[] values) //1
        {
            // Инициализировать максимум максимально возможным значением
            byte max = byte.MinValue;
            // Пройти по всем значениям в массиве
            foreach (byte value in values) {
                // Если значение больше текущего максимума, обновить максимум
                if (value > max) {
                    max = value;
                }
            }
            // Вернуть максимальное значение
            return max;
        }
        #endregion
        
        #region Min Filter
        private void MinFilterButton_Click(object sender, EventArgs e) //1
        {
            var image = accumulativeProcessing.Checked ? processedPictureBox.Image : sourceImage;
            processedPictureBox.Image = (Image)MinFilter((Bitmap)image);
            ShowBrightnessLevels();
        }
        static Bitmap MinFilter(Bitmap sourceImage) //1
        {
            // Валидация входных значений
            if (sourceImage == null) throw new ArgumentNullException("sourceImage");

            // Создание копии для результируещего изображения
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height, sourceImage.PixelFormat);

            for (int y = 1; y < sourceImage.Height - 1; y++)
            {
                for (int x = 1; x < sourceImage.Width - 1; x++)
                {
                    byte[] redValues = new byte[8];
                    byte[] greenValues = new byte[8];
                    byte[] blueValues = new byte[8];

                    byte index = 0;
                    for (int j = (y - 1); j <= (y + 1); j++)
                    {
                        for (int i = (x - 1); i <= (x + 1); i++, index++)
                        {
                            if (j == y && i == x) {
                                index--;
                                continue;
                            }

                            redValues[index] = sourceImage.GetPixel(i, j).R;
                            greenValues[index] = sourceImage.GetPixel(i, j).G;
                            blueValues[index] = sourceImage.GetPixel(i, j).B;
                        }
                    }

                    Color pixelColor = Color.FromArgb(Min(redValues), Min(greenValues), Min(blueValues));
                    resultImage.SetPixel(x, y, pixelColor);
                }
            }

            return resultImage;
        }
        static byte Min(byte[] values) //1
        {
            // Инициализировать минимум максимально возможным значением
            byte min = byte.MaxValue;
            // Пройти по всем значениям в массиве
            foreach (byte value in values) {
                // Если значение меньше текущего минимума, обновить минимум
                if (value < min) {
                    min = value;
                }
            }
            // Вернуть минимальное значение
            return min;
        }
        #endregion
        
        #region Min Max Filter
        private void MinMaxFilterButton_Click(object sender, EventArgs e) //1
        {
            var image = accumulativeProcessing.Checked ? processedPictureBox.Image : sourceImage;
            processedPictureBox.Image = (Image)MinMaxFilter((Bitmap)image, 1);
            ShowBrightnessLevels();
        }
        private Bitmap MinMaxFilter(Bitmap sourceImage, int radius) //1
        {
            Bitmap minResult = MinFilter(sourceImage);
            Bitmap minmaxResult = MaxFilter(minResult);
            return minmaxResult;
        }
        #endregion
        
        #region UI interface
        private void DisableAllControlElements() //1
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
            clusteringButton.Enabled = false;
            checkBinarizationButton.Enabled = false;
            classesNumberTextBox.Enabled = false;
            accumulativeProcessing.Enabled = false;
            showRgbCheckBox.Enabled = false;
        }
        private void EnableAllControlElements() //1
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
            clusteringButton.Enabled = true;
            checkBinarizationButton.Enabled = true;
            classesNumberTextBox.Enabled = true;
            accumulativeProcessing.Enabled = true;
            showRgbCheckBox.Enabled = true;
        }
        private void ShowBrightnessLevels() //1
        {
            var plotModel = new PlotModel               //Создаём график яркости
            {
                Title = "Brightness levels",
                PlotType = PlotType.XY,
            };

            var whiteColor = OxyColor.FromRgb(255, 255, 255);
            plotModel.TextColor = whiteColor;
            plotModel.TitleColor = whiteColor;
            plotModel.PlotAreaBorderColor = whiteColor;

            if (showRgbCheckBox.Checked)
            {   //Извлекаем данные о яркости на R/G/B уровнях
                var redLevels = processedPictureBox.Image.GetBrightnessLevels(2);
                var greenLevels = processedPictureBox.Image.GetBrightnessLevels(1);
                var blueLevels = processedPictureBox.Image.GetBrightnessLevels(0);
                //Помещаем результаты на график
                plotModel.Series.Add(GetBrightnessSeries(redLevels, OxyColor.FromRgb(200, 0, 0)));
                plotModel.Series.Add(GetBrightnessSeries(greenLevels, OxyColor.FromRgb(0, 200, 0)));
                plotModel.Series.Add(GetBrightnessSeries(blueLevels, OxyColor.FromRgb(0, 0, 200)));
            }
            else
            {   //Извлекаем данные об общей яркости
                var grayLevels = processedPictureBox.Image.GetBrightnessLevels();
                //Помещаем результаты на график
                plotModel.Series.Add(GetBrightnessSeries(grayLevels, OxyColor.FromRgb(255, 255, 255)));
            }

            plotView1.Model = plotModel;
        }
        private Series GetBrightnessSeries(List<int> brightnessLevels, OxyColor seriesColor) //1
            => new FunctionSeries((x) => brightnessLevels[(int)x], 0, brightnessLevels.Count, 0.1)
            {
                Color = seriesColor
            };
        private void ShowRgbCheckBox_CheckedChanged(object sender, EventArgs e) //1
        {
            ShowBrightnessLevels();
        }
        private void MaxBrightnessTextBox_Leave(object sender, EventArgs e) //1
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
        private void MinBrightnessTextBox_Leave(object sender, EventArgs e) //1
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
        #endregion

        #endregion
        // ------------------------------------------------------------------------------------        

        // ---------------------------------lab2-----------------------------------------------
        #region Elongation
        private void ElongationMethod(Shape shape) 
        {
            (double length, double area) = CalculatePolygon(shape.borderPixels);
            double elongation = CalculateElongation(length, area);
            shape.Elongation = elongation;
        }
        // Метод для расчета длины и площади замкнутой ломаной по списку точек
        static (double length, double area) CalculatePolygon(List<Point> points)
        {
            // Проверяем, что список точек не пустой и содержит хотя бы три точки
            if (points == null || points.Count < 3)
            {
                throw new ArgumentException("Недостаточно точек для построения замкнутой ломаной");
            }

            // Инициализируем переменные для длины и площади
            double length = 0;
            double area = 0;

            // Проходим по всем точкам в списке и добавляем длину и площадь каждого отрезка
            for (int i = 0; i < points.Count; i++)
            {
                // Берем текущую точку и следующую точку (или первую, если текущая - последняя)
                Point p1 = points[i];
                Point p2 = points[(i + 1) % points.Count];

                // Расстояние между точками - это длина отрезка
                double segmentLength = Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2));

                // Площадь треугольника, образованного отрезком и началом координат - это половина векторного произведения
                double segmentArea = 0.5 * Math.Abs(p1.X * p2.Y - p1.Y * p2.X);

                // Добавляем длину и площадь к общим суммам
                length += segmentLength;
                area += segmentArea;
            }

            // Возвращаем длину и площадь в виде кортежа
            return (length, area);
        }
        static double CalculateElongation(double perimeter, double area)
        {
            // Удлиннённость - это отношение квадрата периметра к площади
            return Math.Pow(perimeter, 2) / area;
        }
        #endregion
        
        #region Square
        private void SquareMethod(Bitmap binImage, Shape shape) 
        {
            List<Point> bordPixels = new List<Point>();
            bordPixels.AddRange(shape.borderPixels);
            // Сортируем список по возрастанию Y, а при равенстве Y - по возрастанию X
            bordPixels.Sort((p1, p2) => p1.Y == p2.Y ? p1.X.CompareTo(p2.X) : p1.Y.CompareTo(p2.Y));
            int counter = 0,
                p1 = counter,
                p2 = counter,
                i = bordPixels[counter].X,
                j = bordPixels[counter].Y;
            int Square = 0;

            while (counter < bordPixels.Count())
            {
                if (bordPixels[counter].Y != j || counter == bordPixels.Count() - 1)    // Переход на новый ряд 
                {
                    if (bordPixels[counter].Y != j)
                        p2 = counter - 1;
                    else
                        p2 = counter;
                    for (int z = bordPixels[p1].X; z <= bordPixels[p2].X; z++)
                    {   // Проход по всем пикселям в строке 
                        if(binImage.GetPixel(z, bordPixels[p1].Y) != Color.FromArgb(0,0,0)) // Проверка что пиксель белый или красный
                            Square++;
                    }
                    p1 = counter;
                    j = bordPixels[counter].Y;     // переход к следующей строке
                    if (counter != bordPixels.Count() - 1)
                        continue;
                }
                counter++;
            }
            p2 = bordPixels.Count() - 1;
            for (int z = bordPixels[p1].X; z <= bordPixels[p2].X; z++)
            {   // Проход по всем пикселям в строке 
                if (binImage.GetPixel(z, bordPixels[p1].Y) != Color.FromArgb(0, 0, 0)) // Проверка что пиксель белый или красный
                    Square++;
            }
            shape.Square = Square;
        }
        #endregion

        #region Perimeter
        private void PerimeterMethod(Shape shape) { 
            List<Point> bordPixels = new List<Point>();
            bordPixels.AddRange(shape.borderPixels);
            // Сортируем список по возрастанию x, а при равенстве x - по возрастанию y
            bordPixels.Sort ((p1, p2) => p1.X == p2.X ? p1.Y.CompareTo (p2.Y) : p1.X.CompareTo (p2.X)); 
            // Создаём переменную для хранения периметра и инициализируем её нулём
            shape.Perimeter = 0;
            // Создаём цикл, в котором перебираем все точки из списка
            for (int i = 0; i < bordPixels.Count(); i++) {
                // Определяем индекс следующей точки, учитывая, что после последней идёт первая
                int next = (i + 1) % bordPixels.Count();
                // Вычисляем расстояние между текущей и следующей точкой по формуле Евклида
                double distance = Math.Sqrt(Math.Pow(bordPixels[next].X - bordPixels[i].X, 2) + Math.Pow(bordPixels[next].Y - bordPixels[i].Y, 2));
                // Прибавляем это расстояние к переменной периметра
                shape.Perimeter += Convert.ToInt32(distance);
            }
            shape.Perimeter = shape.borderPixels.Count();
        }
        #endregion

        #region ClusterizationOld
        //private void ClassesNumberTextBox_Leave(object sender, EventArgs e) //2
        //{
        //    var value = classesNumberTextBox.Text;
        //    if (value.Any(c => !char.IsDigit(c)))
        //    {
        //        classesNumberTextBox.Text = "2";
        //    }
        //    else if (!int.TryParse(value, out int number) || number < 2)
        //    {
        //        classesNumberTextBox.Text = "2";
        //    }
        //}
        //private void СlusteringButton_Click(object sender, EventArgs e) //2
        //{
        //    var image = accumulativeProcessing.Checked ? processedPictureBox.Image : sourceImage;
        //    ClusteringTest1((Bitmap)image);

        //    //var snapshot = GetSnapshot(image);

        //    //var vectors = new List<PropertyVector>();
        //    //for (int areaNumber = snapshot.FirstAreaNumber; areaNumber <= snapshot.LastAreaNumber; ++areaNumber)
        //    //{
        //    //    vectors.Add(CreatePropertyVector(snapshot, areaNumber));
        //    //    ClusteringLog.Text = Convert.ToString($"areaNumber - {areaNumber}; maxAreaNumber - {snapshot.LastAreaNumber}");
        //    //}

        //    //byte.TryParse(classesNumberTextBox.Text, out byte classesNumber);
        //    //ClusterSnapshot(snapshot, vectors, classesNumber);
        //    //processedPictureBox.Image = await sourceImage.VisualizeClusterAsync(snapshot);
        //}
        //private ConnectedAreasSnapshot GetSnapshot(Image image)  //2
        //{
        //    var threshold = image.GetBinaryThreshold();
        //    var binarySnapshot = BinaryImageSnapshot.CreateFromImage(image, threshold);
        //    return ConnectedAreasSnapshot.Create(binarySnapshot);
        //}
        //private PropertyVector CreatePropertyVector(ConnectedAreasSnapshot snapshot, int areaNumber) //2
        //{
        //    var perimeter = snapshot.GetPerimeter(areaNumber);
        //    var area = snapshot.GetArea(areaNumber);
        //    var massCenterX = snapshot.GetMassCenterX(areaNumber, area);
        //    var massCenterY = snapshot.GetMassCenterY(areaNumber, area);
        //    var centralMoment20 = snapshot.GetCentralMoment20(areaNumber, massCenterX, massCenterY);
        //    var centralMoment02 = snapshot.GetCentralMoment02(areaNumber, massCenterX, massCenterY);
        //    var centralMoment11 = snapshot.GetCentralMoment11(areaNumber, massCenterX, massCenterY);

        //    var elongation = PropertyCalculator.GetElongation(centralMoment20, centralMoment02, centralMoment11);
        //    var compactness = PropertyCalculator.GetCompactness(area, perimeter);
        //    return new PropertyVector(compactness, elongation, areaNumber);
        //}
        //private void ClusterSnapshot(ConnectedAreasSnapshot snapshot, List<PropertyVector> vectors, int numberOfClusters) //2
        //{
        //    var clusteredVectors = Сlusterer.MakeClusters(vectors, numberOfClusters);
        //    for (int row = 0; row < snapshot.Height; ++row)
        //    {
        //        for (int column = 0; column < snapshot.Width; ++column)
        //        {
        //            if (snapshot[row, column] >= snapshot.FirstAreaNumber)
        //            {
        //                snapshot[row, column] = clusteredVectors.First(v => v.AreaNumber == snapshot[row, column]).ClassNumber;
        //            }
        //        }
        //    }
        //}
        #endregion

        #region Binarization
        private void CheckBinarizationButton_MouseDown(object sender, MouseEventArgs e) //2
        {
            bufferImage = processedPictureBox.Image;
            processedPictureBox.Image = Binarization((Bitmap)bufferImage);
        }
        private void CheckBinarizationButton_MouseUp(object sender, MouseEventArgs e) //2
        {
            processedPictureBox.Image = bufferImage;
        }
        private Bitmap Binarization(Bitmap sourceImage) //2
        {
            // Валидация входных значений
            if (sourceImage == null) throw new ArgumentNullException("sourceImage");

            // Применение бинаризации
            int threshold = sourceImage.GetBinaryThreshold(); // Порог бинаризации
            Bitmap resultImage = new Bitmap(sourceImage.Width, sourceImage.Height, sourceImage.PixelFormat);

            for (int y = 0; y < sourceImage.Height; y++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    Color pixelColor = sourceImage.GetPixel(x, y);
                    double grayValue = (pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);

                    // Преобразование в черно-белое изображение на основе порога
                    Color newPixelColor = grayValue >= threshold ? Color.White : Color.Black;
                    resultImage.SetPixel(x, y, newPixelColor);
                }
            }
            return resultImage;
        }
        #endregion

        #region Clastering UI
        private void ClassesNumberTextBox_Leave(object sender, EventArgs e) 
        {
            var value = classesNumberTextBox.Text;
            if (value.Any(c => !char.IsDigit(c)))
            {
                classesNumberTextBox.Text = "2";
            }
            else if (!int.TryParse(value, out int number) || number < 2)
            {
                classesNumberTextBox.Text = "2";
            }
        }
        private void СlusteringButton_Click(object sender, EventArgs e) 
        {
            var image = accumulativeProcessing.Checked ? processedPictureBox.Image : sourceImage;
            Clustering((Bitmap)image);
        }
        #endregion
       
        #region Do Not Use Yet
        private ConnectedAreasSnapshot GetSnapshot(Image image)  //2
        {
            var threshold = image.GetBinaryThreshold();
            var binarySnapshot = BinaryImageSnapshot.CreateFromImage(image, threshold);
            return ConnectedAreasSnapshot.Create(binarySnapshot);
        }
        private PropertyVector CreatePropertyVector(ConnectedAreasSnapshot snapshot, int areaNumber) //2
        {
            var perimeter = snapshot.GetPerimeter(areaNumber);
            var area = snapshot.GetArea(areaNumber);
            var massCenterX = snapshot.GetMassCenterX(areaNumber, area);
            var massCenterY = snapshot.GetMassCenterY(areaNumber, area);
            var centralMoment20 = snapshot.GetCentralMoment20(areaNumber, massCenterX, massCenterY);
            var centralMoment02 = snapshot.GetCentralMoment02(areaNumber, massCenterX, massCenterY);
            var centralMoment11 = snapshot.GetCentralMoment11(areaNumber, massCenterX, massCenterY);

            var elongation = PropertyCalculator.GetElongation(centralMoment20, centralMoment02, centralMoment11);
            var compactness = PropertyCalculator.GetCompactness(area, perimeter);
            return new PropertyVector(compactness, elongation, areaNumber);
        }
        private void ClusterSnapshot(ConnectedAreasSnapshot snapshot, List<PropertyVector> vectors, int numberOfClusters) //2
        {
            var clusteredVectors = Сlusterer.MakeClusters(vectors, numberOfClusters);
            for (int row = 0; row < snapshot.Height; ++row)
            {
                for (int column = 0; column < snapshot.Width; ++column)
                {
                    if (snapshot[row, column] >= snapshot.FirstAreaNumber)
                    {
                        snapshot[row, column] = clusteredVectors.First(v => v.AreaNumber == snapshot[row, column]).ClassNumber;
                    }
                }
            }
        }

        private Bitmap CopyImage(Bitmap sourceImage)
        {
            Bitmap temp = sourceImage;
            for (int y = 0; y < temp.Height; y++)
            {
                temp.SetPixel(0, y, Color.FromArgb(0, 0, 0));
                temp.SetPixel(temp.Width-1, y, Color.FromArgb(0, 0, 0));
            }
            for (int x = 0; x < temp.Width; x++)
            {
                temp.SetPixel(x, 0, Color.FromArgb(0, 0, 0));
                temp.SetPixel(x, temp.Height-1, Color.FromArgb(0, 0, 0));
            }
            return temp;
        }
        #endregion

        #region Clastering
        private void Clustering(Bitmap sourceImage)
        {
            ShapeList.Clear();

            // Произведение биноризации изображения
            Bitmap binarized = Binarization(sourceImage);

            Shapization(binarized);     // Проходим по изображению и сохраняем все найденные обьекты в ShapeList
            
            // Подсчёт данных о фигурах (Периметр / Площадь / Вытянутость)
            for (int j = 0; j < ShapeList.Count(); j++)
            {
                PerimeterMethod(ShapeList[j]);
                SquareMethod(binarized, ShapeList[j]);
                ElongationMethod(ShapeList[j]);
            }
            ShapeList.Sort((p1, p2) => p1.Elongation == p2.Elongation ? p1.Square.CompareTo(p2.Square) : p1.Elongation.CompareTo(p2.Elongation));
            int.TryParse(classesNumberTextBox.Text, out int k);
            List<Cluster> clusters = KMeansAlgorithm(k, ShapeList);

            
            foreach (Cluster c in clusters) // Разукрашиваем по контуру все найденные обьекты
            {
                c.BordColor = Color.FromArgb(colors[c.Number]);
                foreach (Shape shape in c.Members) {
                    for (int j = 0; j < shape.borderPixels.Count(); j++)
                    {
                        Point tmp = shape.borderPixels[j];
                        binarized.SetPixel(tmp.X, tmp.Y, Color.FromArgb(colors[c.Number % colors.Length]));
                        //binarized.SetPixel(tmp.X, tmp.Y, Color.FromArgb(255,0,0));
                    }
                }
            }

            foreach (Cluster c in clusters) {
                Console.WriteLine(c.ToString());
                foreach (Shape s in c.Members)
                    Console.WriteLine(s.ToString());
            }
            binarized = ColoringShapes(binarized, clusters);
            processedPictureBox.Image = binarized;
        }

        #region Devide to Shapes
        private void Shapization(Bitmap sourceImage)
        {
            Bitmap binImage = CopyImage(sourceImage);
            int shapesCounter = 0;

            for (int y = 0; y < binImage.Height; y++)
            {
                for (int x = 0; x < binImage.Width; x++)
                {
                    if (binImage.GetPixel(x, y) == Color.FromArgb(255, 0, 0)) { // Попадаем на известный нам обьект
                        x++; // Сдвиг на один от границы известного обьекта

                        while (true) { // Движение до второй границы
                            if (binImage.GetPixel(x - 1, y) == Color.FromArgb(255, 0, 0))            // Предыдущий пиксель Red
                                if (binImage.GetPixel(x, y) == Color.FromArgb(0, 0, 0)) {            // Данный пиксель Black
                                    if (x == binImage.Width-1)
                                        break;
                                    if (binImage.GetPixel(x + 1, y) == Color.FromArgb(0, 0, 0))      // Следующий пиксель Black
                                        break;
                                }
                            x++;
                        }
                    }

                    else if (binImage.GetPixel(x,y) == Color.FromArgb(255,255,255))   // Попадаем на неизвесный нам обьект
                    {
                        if (binImage.GetPixel(x + 1, y) != Color.FromArgb(255, 255, 255)) //если следующий пиксель не белый, то пропуск
                            continue;
                        Shape shape = BugAlgorithm(x, y, binImage, shapesCounter++);
                        SquareMethod(binImage, shape);

                        if (shape.Square > 300)
                            ShapeList.Add(shape);   // сохранять, только если периметр > 100
                        else {
                            shapesCounter--;
                            for (int i = 0; i < shape.borderPixels.Count(); i++)
                                binImage.SetPixel(shape.borderPixels[i].X, shape.borderPixels[i].Y, Color.FromArgb(0, 0, 0));
                        }
                    }
                }
            }
        }

        private Shape BugAlgorithm(int x, int y, Bitmap image, int shapesCounter)  // Алгоритм жука
        {
            Shape shape = new Shape(shapesCounter);
            Point start = new Point(x, y);
            Direction dir = Direction.Right;     // Направление
            Direction lastDir = Direction.Right; // Прошлое направление
            bool isSecond = false;
            bool moveOneDirection = false;
            int nextX = x, nextY = y+1;
            while (true)
            {
                // Проверяем условия выхода из цикла
                if (new Point(x, y) == start && isSecond == true)
                    break;
                if (new Point(x, y) == start && isSecond == false)
                    isSecond = true;

                Point pixelPos = new Point(x, y);
                if (!shape.borderPixels.Contains(pixelPos) && image.GetPixel(x, y) != Color.FromArgb(0, 0, 0))
                {
                    shape.borderPixels.Add(pixelPos); // Сохраняем положение краевых пикселей обьекта
                    if (image.GetPixel(x, y) == Color.FromArgb(255, 255, 255)) // Меняем цвет краевого пикселя
                        image.SetPixel(x, y, Color.FromArgb(255, 0, 0));
                }

                if (moveOneDirection) // Движение вдоль края
                {
                    switch(dir)
                    {
                        case Direction.Up:          // y--
                            y--;
                            nextY = y - 1;
                            nextX = x;
                            break;
                        case Direction.Down:        // y++
                            y++;
                            nextY = y + 1;
                            nextX = x;
                            break;
                        case Direction.Left:        // x--
                            x--;
                            nextX = x - 1;
                            nextY = y;
                            break;
                        case Direction.Right:       // x++
                            x++;
                            nextX = x + 1;
                            nextY = y;
                            break;
                    }
                }   //Движение вдоль края

                // Двигаемся на следующий пиксель
                if (image.GetPixel(x,y) == Color.FromArgb(255,0,0) && !moveOneDirection) // Поворот налево
                {
                    switch(dir)
                    {
                        case Direction.Up:
                            x--;
                            nextX = x - 1;
                            nextY = y;
                            lastDir = dir;
                            dir = Direction.Left;
                            break;
                        case Direction.Down:
                            x++;
                            nextX = x + 1;
                            nextY = y;
                            lastDir = dir;
                            dir = Direction.Right;
                            break;
                        case Direction.Left:
                            y++;
                            nextY = y - 1;
                            nextX = x;
                            lastDir = dir;
                            dir = Direction.Down;
                            break;
                        case Direction.Right:
                            y--;
                            nextY = y + 1;
                            nextX = x;
                            lastDir = dir;
                            dir = Direction.Up;
                            break;
                    }
                }      // Поворот налево
                else if(image.GetPixel(x, y) == Color.FromArgb(0,0,0) && !moveOneDirection)      // Поворот направо
                {
                    switch (dir)
                    {
                        case Direction.Up:
                            x++;
                            nextX = x + 1;
                            nextY = y;
                            lastDir = dir;
                            dir = Direction.Right;
                            break;
                        case Direction.Down:
                            x--;
                            nextX = x - 1;
                            nextY = y;
                            lastDir = dir;
                            dir = Direction.Left;
                            break;
                        case Direction.Left:
                            y--;
                            nextY = y + 1;
                            nextX = x;
                            lastDir = dir;
                            dir = Direction.Up;
                            break;
                        case Direction.Right:
                            y++;
                            nextY = y - 1;
                            nextX = x;
                            lastDir = dir;
                            dir = Direction.Down;
                            break;
                    }
                }   // Поворот направо
            }
            return shape;
        }
        #endregion

        #region KMeansAlgorithm
        static List<Cluster> KMeansAlgorithm(int k, List<Shape> shapes)
        {
            List<Cluster> clusters = InitializeClusters(k, shapes);
           
            List<Cluster> oldClusters = null; // Переменная для хранения старых кластеров

            do {// Повторяем, пока центроиды кластеров не сойдутся
                // Копируем текущие кластеры в старые кластеры
                oldClusters = clusters.Select(c => new Cluster(c.Number, c.Center)).ToList();

                AssignShapes(shapes, clusters);   // Присваиваем фигуры к ближайшему кластеру

                UpdateClusters(shapes, clusters); // Обновляем центроиды кластеров по средним значениям характеристик фигур

            } while (!Converged(oldClusters, clusters));

            return clusters; // Возвращаем список кластеров
        }

        static List<Cluster> InitializeClusters(int k, List<Shape> shapes)
        {
            List<Cluster> clusters = new List<Cluster>();

            Random random = new Random();

            for (int i = 0; i < k; i++)
            {
                int index = random.Next(shapes.Count);
                Shape shape = shapes[index];            // Выбираем случайную фигуру из списка

                // Создаем центроид кластера по характеристикам фигуры
                double[] centroid = new double[3];
                centroid[0] = shape.Perimeter;
                centroid[1] = shape.Square;
                centroid[2] = shape.Elongation;

                Cluster cluster = new Cluster(i + 1, centroid);

                clusters.Add(cluster);
            }
            return clusters;
        }  // Инициализация кластеров со случайными центроидами

        static void AssignShapes(List<Shape> shapes, List<Cluster> clusters)
        {
            foreach (Shape shape in shapes)
            {
                // Инициализируем минимальное расстояние до кластера и номер кластера
                double minDistance = double.MaxValue;
                int clusterNumber = 0;

                foreach (Cluster cluster in clusters)
                {
                    // Вычисляем расстояние между фигурой и центроидом кластера
                    double distance = shape.Distance(cluster.Center);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        clusterNumber = cluster.Number;
                    }
                }

                shape.ClusterId = clusterNumber;
            }
        }  // Присвоения фигур к ближайшему кластеру

        static void UpdateClusters(List<Shape> shapes, List<Cluster> clusters)
        {
            foreach (Cluster cluster in clusters)
            {
                cluster.Members.Clear();    // Очищаем список фигур, принадлежащих кластеру

                foreach (Shape shape in shapes)
                {
                    if (shape.ClusterId == cluster.Number)  // Добавление фигур в список фигур кластера
                    {
                        cluster.Members.Add(shape);
                    }
                }
                
                cluster.UpdateCenter(); // Присвоение средних значений характеристик
            }
        }   // Обновление центроидов кластеров по средним значениям характеристик фигур

        static bool Converged(List<Cluster> oldClusters, List<Cluster> newClusters)
        {
            for (int i = 0; i < oldClusters.Count; i++)
                for (int j = 0; j < oldClusters[i].Center.Length; j++)          // Сравниваем центроиды старого и нового кластера
                    if (oldClusters[i].Center[j] != newClusters[i].Center[j])   // Если центроиды отличаются
                        return false;

            return true;
        }   // Сверка центроид кластеров
        #endregion

        #region Coloring the Shapes
        private Bitmap ColoringShapes(Bitmap image, List<Cluster> clusters)
        {
            foreach (Cluster c in clusters)
            {
                foreach (Shape s in c.Members)
                {
                    List<Point> bordPixels = new List<Point>();
                    bordPixels.AddRange(s.borderPixels);
                    bordPixels.Sort((p1, p2) => p1.Y == p2.Y ? p1.X.CompareTo(p2.X) : p1.Y.CompareTo(p2.Y));
                    int counter = 0,
                        p1 = counter,
                        p2 = counter,
                        i = bordPixels[counter].X,
                        j = bordPixels[counter].Y;

                    while (counter < bordPixels.Count())
                    {
                        if (bordPixels[counter].Y != j || counter == bordPixels.Count() - 1)    // Переход на новый ряд 
                        {
                            if (bordPixels[counter].Y != j)
                                p2 = counter - 1;
                            else
                                p2 = counter;
                            for (int z = bordPixels[p1].X; z <= bordPixels[p2].X; z++)
                            {   // Проход по всем пикселям в строке 
                                if (image.GetPixel(z, bordPixels[p1].Y) != Color.FromArgb(0, 0, 0)) // Проверка что пиксель белый или красный
                                    image.SetPixel(z, bordPixels[p1].Y, c.BordColor);
                            }
                            p1 = counter;
                            j = bordPixels[counter].Y;     // переход к следующей строке
                            if (counter != bordPixels.Count() - 1)
                                continue;
                        }
                        counter++;
                    }
                    p2 = bordPixels.Count() - 1;
                    for (int z = bordPixels[p1].X; z <= bordPixels[p2].X; z++)
                    {   // Проход по всем пикселям в строке 
                        if (image.GetPixel(z, bordPixels[p1].Y) != Color.FromArgb(0, 0, 0)) // Проверка что пиксель белый или красный
                            image.SetPixel(z, bordPixels[p1].Y, c.BordColor);
                    }
                }
            }
            return image;
        }
        #endregion

        #endregion
    }
}