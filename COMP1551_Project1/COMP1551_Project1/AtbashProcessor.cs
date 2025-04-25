using System.Text;

namespace COMP1551_Project1
{
    public class AtbashProcessor : StringProcessorBase
    {
        public AtbashProcessor(string input)
        {
            Input = input;
            N = 0;
        }

        public override string Encode()
        {
            var sb = new StringBuilder();
            foreach (char c in Input)
                sb.Append((char)('Z' - (c - 'A')));
            return sb.ToString();
        }
    }
}
