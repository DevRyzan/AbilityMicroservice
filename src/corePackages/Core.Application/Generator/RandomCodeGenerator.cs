namespace Core.Application.Generator;

public class RandomCodeGenerator : IRandomCodeGenerator
{

    public class Code
    {
        public string RandomCode { get; set; }

        private readonly IRandomCodeGenerator _randomCodeGenerator;
        public Code(IRandomCodeGenerator randomCodeGenerator, string randomCode)
        {
            _randomCodeGenerator = randomCodeGenerator;
            RandomCode = _randomCodeGenerator.GenerateUniqueCode();
        }
    }

    private static readonly Random random = new Random();

    private static readonly string datePart = DateTime.Now.ToString("yyyyMMdd");

    private static readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    private static readonly string numbers = "0123456789";



    private readonly string number1 = new string(Enumerable.Repeat(numbers, 5)
        .Select(s => s[random.Next(s.Length)])
        .ToArray());

    private readonly string number2 = new string(Enumerable.Repeat(numbers, 3)
        .Select(s => s[random.Next(s.Length)])
        .ToArray());

    private readonly string number3 = new string(Enumerable.Repeat(numbers, 4)
        .Select(s => s[random.Next(s.Length)])
        .ToArray());

    private readonly string randomPart = new string(Enumerable.Repeat(chars, 4)
        .Select(s => s[random.Next(s.Length)])
        .ToArray());


    public string GenerateUniqueCodeWithDateTime()
        => number1 + "-" + randomPart + "-" + datePart + number2;

    public string GenerateUniqueCode()
        => number1 + "-" + randomPart + "-" + number2;

    public string GenerateUniqueCodeNumberWithDateTime()
        => number1 + "-" + number2 + "-" + number3;

    public string GenerateUniqueCodeNumber()
        => number1 + "-" + number2 + "-" + number3;


}
