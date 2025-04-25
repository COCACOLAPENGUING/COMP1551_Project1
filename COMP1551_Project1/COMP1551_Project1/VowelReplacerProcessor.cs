using System.Linq;
using System.Text;

namespace COMP1551_Project1
{
    public class VowelReplacerProcessor : StringProcessorBase
    {
        public VowelReplacerProcessor(string input)
        {
            Input = input;
            N = 0;
        }

        public override string Encode()
        {
            var sb = new StringBuilder();
            foreach (char c in Input)
                sb.Append("AEIOU".Contains(c) ? '*' : c);
            return sb.ToString();
        }
    }
}
