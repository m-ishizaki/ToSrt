using System;
using System.Collections.Generic;
using System.Text;

namespace ToSrt;

internal record Line(long Time, string Title, string[] Description) { }

internal class Commons
{
    internal static Line ToLine(string line)
    {
        var elms = line.Split(" ");
        long time = TimeLong(elms.FirstOrDefault());
        var title = elms.Skip(1).FirstOrDefault() ?? string.Empty;
        var description = elms.Skip(2).ToArray();
        return new Line(time, title, description);
    }

    internal static string TimeFormat(long time)
    {
        var hours = time / 3600;
        var minutes = (time % 3600) / 60;
        var seconds = time % 60;
        return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
    }

    internal static long TimeLong(string? time_string)
    {
        var values = (time_string ?? "00:00:00").Split(":").Take(3).ToList();
        while (values.Count < 3) values.Insert(0, "00");
        var time
            = (long.TryParse(values[0], out var hours) ? hours * 3600 : 0)
            + (long.TryParse(values[1], out var minutes) ? minutes * 60 : 0)
            + (long.TryParse(values[2], out var second) ? second : 0);
        return time;
    }
}
