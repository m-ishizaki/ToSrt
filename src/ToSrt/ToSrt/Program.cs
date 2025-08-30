using ToSrt;

if(args?.Length == 0)
{
    Console.WriteLine("args[0]: 0 => 動画 概要欄向け / 1 => Srt ファイル");
    Console.WriteLine("args[1]: 文字起こしファイルのパス");
    Console.WriteLine("args[2]: 開始時刻の調整 例: 3 と指定した場合、文字起こしファイル内の時間から 3 秒後ろにした時間で出力する。先頭 3 秒にタイトル表示時間を追加する場合などに)");
    Console.WriteLine("args[3]: Srt ファイルを作成する場合の、字幕の表示時間(秒)");
    return;
}

var values = Values.Parse(args);

if (values.Type == 0)
{
    var result = YT.Format(values);
    Console.WriteLine(result);
}
else
{
    var srtElms = values.Lines.Select((line, index) => ToSrt.ToSrt.Format(index + 1, line, values.Start, values.Span)).ToArray();
    var result = string.Join(Environment.NewLine + Environment.NewLine, srtElms);

    Console.WriteLine(result);
}


