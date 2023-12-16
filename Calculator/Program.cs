namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Type first number: ");
                int.TryParse(Console.ReadLine(), out var x);
                Console.WriteLine("Type second number: ");
                int.TryParse(Console.ReadLine(), out var y);

                Console.WriteLine("Select operation: ");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Substract");
                Console.WriteLine("3. Divide");
                Console.WriteLine("4. Multiply");
                int.TryParse(Console.ReadLine(), out var operation);
                var result = operation switch
                {
                    1 => Calculator.Add(x, y),
                    2 => Calculator.Sub(x, y),
                    3 => Calculator.Divide(x, y),
                    4 => Calculator.Multiply(x, y),
                    _ => 0
                };

                Console.WriteLine(result);
            }
        }
    }

    public static class Calculator
    {
        public static int Add(int x, int y)
        {
            return x + y;
        }

        public static int Sub(int x, int y)
        {
            return x - y;
        }

        public static decimal Divide(int x, int y)
        {
            return (decimal)x / y;
        }

        public static int Multiply(int x, int y)
        {
            return x * y;
        }
    }
}