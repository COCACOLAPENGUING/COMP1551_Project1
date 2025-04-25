using System.Linq;

namespace COMP1551_Project1
{
    public class MirrorProcessor : StringProcessorBase
    {
        public MirrorProcessor(string input)
        {
            Input = input;
            N = 0;
        }

        public override string Encode()
        {
            var reversed = new string(Input.Reverse().ToArray());
            return Input + reversed;
        }
    }
}
