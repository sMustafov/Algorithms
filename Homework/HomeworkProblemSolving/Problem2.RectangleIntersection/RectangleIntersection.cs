namespace Problem2.RectangleIntersection
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RectangleIntersection
    {
        static void Main()
        {
            List<Rectangle> rectangles = new List<Rectangle>();
            List<int> xMinAndMax = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] parameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

                int minX = parameters[0];
                int maxX = parameters[1];
                int minY = parameters[2];
                int maxY = parameters[3];

                Rectangle rectangle = new Rectangle(minX, maxX, minY, maxY);
                rectangles.Add(rectangle);

                xMinAndMax.Add(minX);
                xMinAndMax.Add(maxX);
            }

            rectangles.Sort();
            xMinAndMax.Sort();

            List<Rectangle>[] rects = new List<Rectangle>[xMinAndMax.Count - 1];

            for (int i = 0; i < xMinAndMax.Count - 1; i++)
            {
                rects[i] = new List<Rectangle>();
            }

            foreach (var rectangle in rectangles)
            {
                for (int i = 0; i < xMinAndMax.Count - 1; i++)
                {
                    if (rectangle.MaxX > xMinAndMax[i] && rectangle.MinX < xMinAndMax[i + 1])
                    {
                        rects[i].Add(rectangle);
                    }
                }
            }

            long sum = 0;

            for (int i = 0; i < rects.Length; i++)
            {
                if (rects[i].Count < 2)
                {
                    continue;
                }

                List<int> yMinAndMax = new List<int>();

                foreach (var rectangle in rects[i])
                {
                    yMinAndMax.Add(rectangle.MinY);
                    yMinAndMax.Add(rectangle.MaxY);
                }

                yMinAndMax.Sort();

                int[] overlapCount = new int[yMinAndMax.Count - 1];

                foreach (var rectangle in rects[i])
                {
                    for (int j = 0; j < yMinAndMax.Count; j++)
                    {
                        if (rectangle.MaxY > yMinAndMax[j] && rectangle.MinY < yMinAndMax[j + 1])
                        {
                            overlapCount[j]++;
                        }
                    }
                }

                for (int j = 0; j < overlapCount.Length; j++)
                {
                    if (overlapCount[j] >= 2)
                    {
                        int distanceX = xMinAndMax[i + 1] - xMinAndMax[i];
                        int distanceY = yMinAndMax[j + 1] - yMinAndMax[j];

                        long quad = distanceX*distanceY;

                        sum += quad;
                    }
                }
            }

            Console.WriteLine(sum);
        }
    }
}