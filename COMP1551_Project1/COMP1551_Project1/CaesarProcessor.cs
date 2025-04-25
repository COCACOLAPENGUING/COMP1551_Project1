using System.Text;

namespace COMP1551_Project1
{
    public class CaesarProcessor : StringProcessorBase
    {
        public CaesarProcessor(string input, int n)
        {
            Input = input;
            N = n;
        }

        public override string Encode()
        {
            var sb = new StringBuilder();
            foreach (char c in Input)
                sb.Append((char)(((c - 'A' + N + 26) % 26) + 'A'));
            return sb.ToString();
        }
    }
}