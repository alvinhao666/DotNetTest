using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace 生产消费队列实现写文本
{
    public class WriteItem : IDisposable
    {
        public string Filename { get; private set; }
        public Encoding Encode { get; }
        public bool Append { get; }
        public bool TimeName { get; }

        private StreamWriter _writer;

        private readonly BlockingCollection<string> _blocking = new BlockingCollection<string>();

        public void Write(string msg)
        {
            _blocking.Add(msg);
        }

        public void WriteLine(string msg)
        {
            Write(msg + Environment.NewLine);
        }

        public WriteItem(string filename, Encoding encode, bool append = true, bool timeName = false)
        {
            Filename = filename;
            Encode = encode;
            Append = append;
            TimeName = timeName;

            if (timeName && string.IsNullOrEmpty(Path.GetExtension(filename)))
            {
                this.Filename = Path.Combine(this.Filename, DateTime.Now.ToString("yyyy-MM-dd") + ".txt");
            }
            var dir = Path.GetDirectoryName(this.Filename);
            Directory.CreateDirectory(dir ?? throw new InvalidOperationException());
            _writer = new StreamWriter(this.Filename, this.Append, this.Encode) { AutoFlush = true };
            Task.Factory.StartNew(() =>
            {
                foreach (var s in _blocking.GetConsumingEnumerable())
                {
                    if (TimeName)
                    {
                        var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(this.Filename);
                        var nowDay = DateTime.Now.ToString("yyyy-MM-dd").ToString();
                        if (fileNameWithoutExtension != nowDay)
                        {
                            _writer.Dispose();
                            this.Filename = Path.Combine(Path.GetDirectoryName(this.Filename), nowDay + ".txt");
                            _writer = new StreamWriter(this.Filename, this.Append, this.Encode) { AutoFlush = true };
                        }
                    }
                    _writer.Write(s);
                }

            }, TaskCreationOptions.LongRunning);
        }

        public void Dispose()
        {
            _writer?.Dispose();
            _blocking?.Dispose();
        }
    }
}
