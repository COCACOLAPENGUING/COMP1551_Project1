using System;
using System.Linq;
using System.Text;

namespace COMP1551_Project1
{
    public class StringProcessing
    {
        private string _input;
        private int _n;
        private string _output;

        public string Input
        {
            get => _input;
            set
            {
                while (!IsValidInput(value))
                {
                    Console.Write("Error: Only A–Z (max 40). Try again: ");
                    value = Console.ReadLine();
                }
                _input = value;
            }
        }

        public int N
        {
            get => _n;
            set
            {
                while (value < -25 || value > 25)
                {
                    Console.Write("Error: N must be between -25 and 25. Try again: ");
                    int.TryParse(Console.ReadLine(), out value);
                }
                _n = value;
            }
        }

        public StringProcessing(string input, int n)
        {
            Input = input;
            N = n;
            _output = Encode();
        }

        public string Encode()
        {
            var sb = new StringBuilder();
            foreach (char c in _input)
            {
                // shift with wrap-around A–Z
                char shifted = (char)(((c - 'A' + _n + 26) % 26) + 'A');
                sb.Append(shifted);
            }
            _output = sb.ToString();
            return _output;
        }

        public string Print() => _output;
        public int[] InputCode() => _input.Select(c => (int)c).ToArray();
        public int[] OutputCode() => _output.Select(c => (int)c).ToArray();
        public string Sort() => new string(_input.OrderBy(c => c).ToArray());

        private bool IsValidInput(string s)
            => s.Length <= 40 && s.All(ch => ch >= 'A' && ch <= 'Z');
    }
}
