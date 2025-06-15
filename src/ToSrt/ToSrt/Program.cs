
using ToSrt;

var start = long.TryParse(args.Skip(1).FirstOrDefault(), out var _start) ? _start : 5;
var span = long.TryParse(args.Skip(2).FirstOrDefault(), out var _span) ? _span : 5;

var lines = File.ReadAllLines(args[0]).Select(Commons.ToLine).ToArray();

if (args.Skip(3).FirstOrDefault() == null)
{
    var srtElms = lines.Select((line, index) => ToSrt.ToSrt.Format(index + 1, line, start, span)).ToArray();
    var result = string.Join(Environment.NewLine + Environment.NewLine, srtElms);

    Console.WriteLine(result);
}
else
{
    var srtElms = lines.Select(line =>
    {
        var time_start = Commons.TimeFormat(line.Time + start);
        var title = line.Title.Trim();
        var description = string.Join(" ", line.Description).Trim();
        var _result = @$"{time_start} {title} {description}";
        return _result.Trim();
    }).ToArray();
    var result = string.Join(Environment.NewLine, srtElms);
}

