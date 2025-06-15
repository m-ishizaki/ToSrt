
var start = long.TryParse(args.Skip(1).FirstOrDefault(), out var _start) ? _start : 5;
var span = long.TryParse(args.Skip(2).FirstOrDefault(), out var _span) ? _span : 5;

var lines = File.ReadAllLines(args[0]);
var srtElms = lines.Select((lines, index) => Format(index + 1, ToLine(lines), start, span)).ToArray();
var result = string.Join(Environment.NewLine+Environment.NewLine, srtElms);

Console.WriteLine(result);

static string Format(long no, Line line, long start, long span)
{
    var time_start_second = line.Time + start;
    var time_end_second = time_start_second + span;
    var time_start = TimeFormat(time_start_second);
    var time_end = TimeFormat(time_end_second);
    var title = line.Title.Trim();
    var description = string.Join("<br>", line.Description).Trim();

    var result = @$"{no}
{time_start},{time_start_second} --> {time_end},{time_end_second}
<font size=""16""><font color=""#ffffff"">{title}<br>{description}</font></font>";
    return result;
}

static string TimeFormat(long time)
{
    var hours = time / 3600;
    var minutes = (time % 3600) / 60;
    var seconds = time % 60;
    return $"{hours:D2}:{minutes:D2}:{seconds:D2}";
}

static Line ToLine(string line)
{
    var elms = line.Split(" ");
    long time = 0;
    {
        var values = (elms.FirstOrDefault() ?? "00:00:00").Split(":").Take(3).ToList();
        while (values.Count < 3) values.Insert(0, "00");
        var _time
            = (long.TryParse(values[0], out var hours) ? hours * 3600 : 0)
            + (long.TryParse(values[1], out var minutes) ? minutes * 60 : 0)
            + (long.TryParse(values[1], out var second) ? second : 0);
        time = _time;
    }
    var title = elms.Skip(1).FirstOrDefault() ?? string.Empty;
    var description = elms.Skip(2).ToArray();
    return new Line(time, title, description);
}

internal record Line(long Time, string Title, string[] Description) { }
