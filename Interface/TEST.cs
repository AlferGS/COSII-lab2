using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace Interface {
        //class dsghf
        //{
        //    // Метод для определения, является ли пиксель черным
        //    static bool IsBlack(Color pixel)
        //    {
        //        return pixel.R == 0 && pixel.G == 0 && pixel.B == 0;
        //    }

        //    // Метод для определения, является ли пиксель белым
        //    static bool IsWhite(Color pixel)
        //    {
        //        return pixel.R == 255 && pixel.G == 255 && pixel.B == 255;
        //    }

        //    // Метод для заполнения области одним цветом
        //    static void FillRegion(Bitmap image, int x, int y, Color color)
        //    {
        //        // Проверяем, что координаты в пределах изображения
        //        if (x < 0 || x >= image.Width || y < 0 || y >= image.Height)
        //            return;

        //        // Получаем цвет пикселя в данной позиции
        //        Color pixel = image.GetPixel(x, y);

        //        // Проверяем, что пиксель черный
        //        if (IsBlack(pixel))
        //        {
        //            // Заменяем пиксель на заданный цвет
        //            image.SetPixel(x, y, color);

        //            // Рекурсивно заполняем соседние пиксели
        //            FillRegion(image, x - 1, y, color); // слева
        //            FillRegion(image, x + 1, y, color); // справа
        //            FillRegion(image, x, y - 1, color); // сверху
        //            FillRegion(image, x, y + 1, color); // снизу
        //        }
        //    }

        //    // Метод для выделения четырехсвяных областей на бинаризированном изображении
        //    static void FindFourConnectedRegions(Bitmap image)
        //    {
        //        // Создаем массив цветов для обозначения областей
        //        Color[] colors = new Color[] { Color.Red, Color.Green, Color.Blue, Color.Yellow };

        //        // Инициализируем счетчик областей
        //        int count = 0;

        //        // Проходим по всем пикселям изображения
        //        for (int x = 0; x < image.Width; x++)
        //        {
        //            for (int y = 0; y < image.Height; y++)
        //            {
        //                // Получаем цвет пикселя в данной позиции
        //                Color pixel = image.GetPixel(x, y);

        //                // Проверяем, что пиксель черный
        //                if (IsBlack(pixel))
        //                {
        //                    // Проверяем, что не превышено максимальное количество областей
        //                    if (count < 4)
        //                    {
        //                        // Заполняем область соответствующим цветом
        //                        FillRegion(image, x, y, colors[count]);

        //                        // Увеличиваем счетчик областей
        //                        count++;
        //                    }
        //                    else
        //                    {
        //                        // Выводим сообщение об ошибке
        //                        Console.WriteLine("Найдено более четырех областей на изображении");
        //                        return;
        //                    }
        //                }
        //            }
        //        }

        //        // Выводим количество найденных областей
        //        Console.WriteLine("Найдено {0} областей на изображении", count);
        //    }

        //    static void fsregthyjk,(string[] args)
        //    {
        //        // Загружаем бинаризированное изображение из файла
        //        Bitmap image = new Bitmap("binary_image.png");

        //        // Выделяем четырехсвяные области на изображении
        //        FindFourConnectedRegions(image);

        //        // Сохраняем измененное изображение в файл
        //        image.Save("result_image.png", ImageFormat.Png);

        //        // Освобождаем ресурсы
        //        image.Dispose();
        //    }
        //}

}
