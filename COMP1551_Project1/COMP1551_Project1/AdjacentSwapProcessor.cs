namespace COMP1551_Project1
{
    public class AdjacentSwapProcessor : StringProcessorBase
    {
        public AdjacentSwapProcessor(string input)
        {
            Input = input;
            N = 0;
        }

        public override string Encode()
        {
            var arr = Input.ToCharArray();
            for (int i = 0; i < arr.Length - 1; i += 2)
            {
                var temp = arr[i];
                arr[i] = arr[i + 1];
                arr[i + 1] = temp;
            }
            return new string(arr);
        }
    }
}
