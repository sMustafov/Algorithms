namespace Problem4.NestedRectangles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Rectangle
    {
        public string Name { get; set; }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public int BestDepth { get; set; }

        public Rectangle BestNested { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }

    class NestedRectangles
    {
        private static List<Rectangle> rectangles = new List<Rectangle>();

        static void Main()
        {
            rectangles = new List<Rectangle>();
            var line = Console.ReadLine();

            while (line != "End")
            {
                var data = line.Split(':');
                string name = data[0];
                int[] coords = data[1]
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                rectangles.Add(new Rectangle()
                {
                    Name = name,
                    X1 = coords[0],
                    Y1 = coords[1],
                    X2 = coords[2],
                    Y2 = coords[3],
                    BestDepth = 0
                });

                line = Console.ReadLine();
            }

            Rectangle best = rectangles[0];
            for (int i = 0; i < rectangles.Count; i++)
            {
                var rect = rectangles[i];
                FindNestedRectangles(rect);

                if (rect.BestDepth > best.BestDepth ||
                    (rect.BestDepth > best.BestDepth ||
                    (rect.BestDepth == best.BestDepth) && rect.Name.CompareTo(best.Name) < 0))
                {
                    best = rect;
                }
            }

            var result = new List<string>();
            while (best != null)
            {
                result.Add(best.Name);
                best = best.BestNested;
            }
            Console.WriteLine(string.Join(" < ", result));
        }

        private static void FindNestedRectangles(Rectangle rect)
        {
            if (rect.BestDepth > 0)
            {
                return;
            }

            Rectangle bestNested = null;
            rect.BestDepth = 1;

            for (int i = 0; i < rectangles.Count; i++)
            {
                var otherRect = rectangles[i];
                if (IsInside(otherRect, rect) && otherRect != rect)
                {
                    FindNestedRectangles(otherRect);
                    if (bestNested == null ||
                        otherRect.BestDepth > bestNested.BestDepth ||
                        (otherRect.BestDepth == bestNested.BestDepth && otherRect.Name.CompareTo(bestNested.Name) < 0))
                    {
                        bestNested = otherRect;
                    }
                }
            }

            if (bestNested != null)
            {
                rect.BestNested = bestNested;
                rect.BestDepth = bestNested.BestDepth + 1;
            }
        }

        private static bool IsInside(Rectangle inside, Rectangle outside)
        {
            return inside.X1 >= outside.X1 &&
                   inside.Y1 <= outside.Y1 &&
                   inside.X2 <= outside.X2 &&
                   inside.Y2 >= outside.Y2;
        }
    }
}