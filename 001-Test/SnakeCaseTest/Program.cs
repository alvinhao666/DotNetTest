// See https://aka.ms/new-console-template for more information
using System.Buffers;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Yoh.Text.Segmentation;

Stopwatch sw = new Stopwatch();

sw.Start();

for (int i = 0; i <= 1000000; i++)
{
    var a = ToSnakeCase("FirstName");
}

sw.Stop();

Console.WriteLine(sw.ElapsedMilliseconds);

Stopwatch sw2 = new Stopwatch();

sw2.Start();
for (int i = 0; i <= 1000000; i++)
{
    var a = ConvertName("FirstName");
}

sw2.Stop();

Console.WriteLine(sw2.ElapsedMilliseconds);

Console.ReadKey();






static string ConvertName(string name)
{
    var words = name.EnumerateWords();
    if (words.MoveNext())
    {
        var bufferLength = name.Length * 2;
        var buffer = bufferLength > 512
            ? ArrayPool<char>.Shared.Rent(bufferLength)
            : null;

        var resultLength = 0;
        Span<char> result = buffer is null
            ? stackalloc char[512]
            : buffer;

        void WriteWord(ref Span<char> result, ReadOnlySpan<char> word)
        {
            var required = result.IsEmpty
                ? word.Length
                : word.Length + 1;

            if (required >= result.Length)
            {
                var bufferLength = result.Length * 2;
                var bufferNew = ArrayPool<char>.Shared.Rent(bufferLength);

                result.CopyTo(bufferNew);

                if (buffer is not null)
                    ArrayPool<char>.Shared.Return(buffer);

                buffer = bufferNew;
            }

            if (resultLength != 0)
            {
                result[resultLength] = '_';
                resultLength += 1;
            }

            var destination = result[resultLength..];
            if (true)
            {
                word.ToLowerInvariant(destination);
            }
            else
            {
                word.ToUpperInvariant(destination);
            }

            resultLength += word.Length;
        }

        do
        {
            var chars = words.Current;
            var previousCategory = CharCategory.Boundary;
            for (int first = 0, index = 0; index < chars.Length; index++)
            {
                var current = chars[index];
                if (current == '_')
                {
                    if (first == index)
                        first = index + 1;
                    continue;
                }

                if (index + 1 == chars.Length)
                {
                    WriteWord(ref result, chars[first..]);
                }
                else
                {
                    var next = chars[index + 1];
                    var currentCategory = char.GetUnicodeCategory(current) switch
                    {
                        UnicodeCategory.LowercaseLetter => CharCategory.Lowercase,
                        UnicodeCategory.UppercaseLetter => CharCategory.Uppercase,
                        _ => previousCategory
                    };

                    if (currentCategory == CharCategory.Lowercase &&
                        char.IsUpper(next) ||
                        next == '_')
                    {
                        WriteWord(ref result, chars[first..(index + 1)]);

                        previousCategory = CharCategory.Boundary;
                        first = index + 1;

                        continue;
                    }

                    if (previousCategory == CharCategory.Uppercase &&
                        char.IsUpper(current) &&
                        char.IsLower(next))
                    {
                        WriteWord(ref result, chars[first..index]);

                        previousCategory = CharCategory.Boundary;
                        first = index;

                        continue;
                    }

                    previousCategory = currentCategory;
                }
            }
        }
        while (words.MoveNext());

        name = new string(result[..resultLength]);

        if (buffer is not null)
            ArrayPool<char>.Shared.Return(buffer);
    }

    return name;
}


/// <summary>
/// 字符串转蛇形命名法snake_case
/// </summary>
/// <param name="value"></param>
/// <returns></returns>
static string ToSnakeCase(string value)
{
    //https://github.com/JamesNK/Newtonsoft.Json/blob/7b8c3b0ed0380cf76d66894e81bf4d4d5b0bd796/Src/Newtonsoft.Json/Utilities/StringUtils.cs#L200-L276

    if (string.IsNullOrEmpty(value))
    {
        return value;
    }

    StringBuilder sb = new StringBuilder();
    SnakeCaseState state = SnakeCaseState.Start;

    for (int i = 0; i < value.Length; i++)
    {
        if (value[i] == ' ')
        {
            if (state != SnakeCaseState.Start)
            {
                state = SnakeCaseState.NewWord;
            }
        }
        else if (char.IsUpper(value[i]))
        {
            switch (state)
            {
                case SnakeCaseState.Upper:
                    bool hasNext = (i + 1 < value.Length);
                    if (i > 0 && hasNext)
                    {
                        char nextChar = value[i + 1];
                        if (!char.IsUpper(nextChar) && nextChar != '_')
                        {
                            sb.Append('_');
                        }
                    }
                    break;
                case SnakeCaseState.Lower:
                case SnakeCaseState.NewWord:
                    sb.Append('_');
                    break;
            }
            sb.Append(char.ToLowerInvariant(value[i]));
            state = SnakeCaseState.Upper;
        }
        else if (value[i] == '_')
        {
            sb.Append('_');
            state = SnakeCaseState.Start;
        }
        else
        {
            if (state == SnakeCaseState.NewWord)
            {
                sb.Append('_');
            }

            sb.Append(value[i]);
            state = SnakeCaseState.Lower;
        }
    }

    return sb.ToString();
}


enum SnakeCaseState
{
    Start,
    Lower,
    Upper,
    NewWord
}

enum CharCategory
{
    Boundary,
    Lowercase,
    Uppercase,
}