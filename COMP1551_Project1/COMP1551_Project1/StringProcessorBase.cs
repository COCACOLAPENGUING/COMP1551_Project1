using System.Linq;

namespace COMP1551_Project1
{
    public abstract class StringProcessorBase
    {
        public string Input { get; protected set; }
        public int N { get; protected set; }

        public abstract string Encode();
        public virtual string Print() => Encode();
        public virtual int[] InputCode() => Input.Select(c => (int)c).ToArray();
        public virtual int[] OutputCode() => Encode().Select(c => (int)c).ToArray();
    }
}
