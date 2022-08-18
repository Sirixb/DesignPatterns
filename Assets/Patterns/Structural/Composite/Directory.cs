using System.Collections.Generic;
using System.Text;

namespace Patterns.Structural.Composite
{
    public class Directory : File
    {
        public bool IsDirectory => true;

        private readonly string _name;
        private readonly List<File> _files;

        public Directory(string name)
        {
            _name = name;
            _files = new List<File>();
        }

        public void Add(File file)
        {
            _files.Add(file);
        }

        public void Remove(File file)
        {
            _files.Remove(file);
        }

        public string Print(int level)
        {
            var stringBuilder = new StringBuilder();
            var nextLevel = level + 1;

            stringBuilder.Append('-', nextLevel);
            stringBuilder.AppendLine(_name);

            foreach (var file in _files)
            {
                stringBuilder.Append(file.Print(nextLevel));
            }

            return stringBuilder.ToString();
        }
    }
}
