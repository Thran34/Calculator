namespace Calculator
{
    public class CalculatorTests
    {
        [TestCase(1, 2, 3)]
        [TestCase(-1, 5, 4)]
        [TestCase(0, 0, 0)]
        [TestCase(int.MaxValue, 1, int.MinValue)]
        [TestCase(-10, -5, -15)]
        [TestCase(7, -3, 4)]
        [TestCaseSource(nameof(GetTestCasesFromFile))]
        public void Add_Should_Add_Number(int x, int y, int expectedResult)
        {
            var result = Calculator.Add(x, y);

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase(1, 2, -1)]
        [TestCase(5, 3, 2)]
        [TestCase(0, 0, 0)]
        [TestCase(int.MinValue, 1, int.MaxValue)]
        [TestCase(-5, -3, -2)]
        [TestCase(7, -3, 10)]
        public void Sub_Should_Substract_Number(int x, int y, int expectedResult)
        {
            var result = Calculator.Sub(x, y);

            Assert.That(expectedResult, Is.EqualTo(result));
        }

        [TestCase(1, 2, 0.5)]
        [TestCase(5, 2, 2.5)]
        [TestCase(0, 5, 0)]
        [TestCase(10, 2, 5)]
        [TestCase(7, -3, -2.33)]
        [TestCase(-10, -2, 5)]
        public void Divide_Should_Divide_Number(int x, int y, decimal expectedResult)
        {
            var result = Calculator.Divide(x, y);

            Assert.That(result, Is.EqualTo(expectedResult).Within(0.1m));
        }

        [TestCase(1, 2, 2)]
        [TestCase(5, 3, 15)]
        [TestCase(0, 5, 0)]
        [TestCase(-5, -3, 15)]
        [TestCase(7, -3, -21)]
        public void Multiply_Should_Multiply_Number(int x, int y, int expectedResult)
        {
            var result = Calculator.Multiply(x, y);

            Assert.That(expectedResult, Is.EqualTo(result));
        }


        private static IEnumerable<TestCaseData> GetTestCasesFromFile()
        {
            var filePath = GetFilePath("TestCases.txt");
            var lines = File.ReadAllLines(filePath);

            foreach (var line in lines)
            {
                var data = line.Replace(";", "").Split(',').Select(int.Parse).ToArray();
                yield return new TestCaseData(data[0], data[1], data[2]);
            }
        }

        private static string GetFilePath(string fileName)
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            var filePath = Path.Combine(baseDirectory, fileName);
            return filePath;
        }
    }
}