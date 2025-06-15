using System;
using System.Collections.Generic;
using System.Text;

namespace ToSrt;

internal class ToSrt
{
    internal static string Format(long no, Line line, long start, long span)
    {
        var time_start_second = line.Time + start;
        var time_end_second = time_start_second + span;
        var time_start = Commons.TimeFormat(time_start_second);
        var time_end = Commons.TimeFormat(time_end_second);
        var title = line.Title.Trim();
        var description = string.Join(" ", line.Description).Trim();

        var result = @$"{no}
{time_start},{time_start_second} --> {time_end},{time_end_second}
<font size=""16""><font color=""#ffffff"">{title}
{description}</font></font>";
        return result;
    }
}
