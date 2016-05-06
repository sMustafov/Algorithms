namespace Problem4.BestLecturesSchedule
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class BestLecturesSchedule
    {
        static void Main()
        {
            int lectureCount = int.Parse(Console.ReadLine().Substring(10));

            List<Lecture> lectures = new List<Lecture>();

            for (int i = 0; i < lectureCount; i++)
            {
                string[] parameter = Console.ReadLine()
                    .Split(new char[] { ':', '-' }, StringSplitOptions.RemoveEmptyEntries);

                string name = parameter[0];
                int start = int.Parse(parameter[1]);
                int end = int.Parse(parameter[2]);

                Lecture lecture = new Lecture(name, start, end);

                lectures.Add(lecture);
            }

            lectures = lectures.OrderBy(l => l.End).ToList();

            List<Lecture> result = new List<Lecture>();

            while (lectures.Count > 0)
            {
                Lecture last = lectures[0];
                result.Add(last);
                lectures = lectures.Where(lecture => lecture.Start >= last.End).ToList();
            }

            Console.WriteLine();
            Console.WriteLine("Lectures ({0}):", result.Count);
            Console.WriteLine(string.Join(Environment.NewLine, result));
        }
    }
}