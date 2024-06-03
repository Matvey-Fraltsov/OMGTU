delegate double BinaryOperation(double x, double y);
delegate double UnaryOperation(double x);
class Program
{

    static void Main()
    {
        Calculator calculator = new Calculator();
        BinaryOperation BinOp;
        UnaryOperation UnOp;
        double a, b;

        Console.Write("Введите операцию (+, -, *, /, sqrt, sin, cos): ");
        string operation = Console.ReadLine();

        if (new string[] { "+", "-", "*", "/" }.Contains(operation))
        {
            Console.Write("Введите 1-ое число: ");
            a = double.Parse(Console.ReadLine());

            Console.Write("Введите 2-ое число: ");
            b = double.Parse(Console.ReadLine());

            BinOp = calculator.DefineBinOp(operation);

            try
            {
                Console.WriteLine(BinOp(a, b));
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
        }
        else if (new string[] { "sqrt", "sin", "cos" }.Contains(operation))
        {
            Console.Write("Введите число: ");
            a = double.Parse(Console.ReadLine());

            UnOp = calculator.DefineUnaryOp(operation);
            try
            {
                Console.WriteLine(UnOp(a));
            }
            catch (ArgumentException e) { Console.WriteLine(e.Message); }
        }
        else Console.WriteLine("Неверная операция");
    }
}
interface ICalculator
{
    double Add(double x, double y);
    double Sub(double x, double y);
    double Mult(double x, double y);
    double Div(double x, double y);
    double Sqrt(double x);
    double Sin(double x);
    double Cos(double x);
    UnaryOperation DefineUnaryOp(string operation);
    BinaryOperation DefineBinOp(string operation);


}
class Calculator : ICalculator
{
    public double Add(double x, double y) => x + y;
    public double Sub(double x, double y) => x - y;
    public double Mult(double x, double y) => x * y;
    public double Div(double x, double y)
    {
        if (y == 0) throw new ArgumentException("Деление на ноль невозможно");
        return x / y;
    }
    public double Sqrt(double x)
    {
        if (x < 0) throw new ArgumentException("Корень из отрицательного числа не извлекается");
        return Math.Sqrt(x);
    }
    public double Sin(double x) => Math.Sin(x);
    public double Cos(double x) => Math.Cos(x);
    public BinaryOperation DefineBinOp(string operation)
    {
        switch (operation)
        {
            case "+":
                return Add;
            case "-":
                return Sub;
            case "*":
                return Mult;
            case "/":
                return Div;
            default:
                return null;
        }
    }
    public UnaryOperation DefineUnaryOp(string operation)
    {
        switch (operation)
        {
            case "sqrt":
                return Sqrt;
            case "sin":
                return Sin;
            case "cos":
                return Cos;
            default:
                return null;
        }
    }
}
