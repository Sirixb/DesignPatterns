using System.Text;

namespace Patterns.Structural.Composite
{
    public class FileImpl : File
    {
        public bool IsDirectory => false;

        private readonly string _name;

        public FileImpl(string name)
        {
            _name = name;
        }
        
        public void Add(File file)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(File file)
        {
            throw new System.NotImplementedException();
        }

        public string Print(int level)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append('-', level + 1);
            stringBuilder.AppendLine(_name);
            return stringBuilder.ToString();
        }
    }
}
