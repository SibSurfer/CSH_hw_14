using System.Reflection;

public class BlackBox
{
    private int innerValue;
    private BlackBox(int innerValue)
    {
        this.innerValue = 0;
    }
    private BlackBox()
    {
        this.innerValue = 88;
    }
    private void Add(int addend)
    {
        this.innerValue += addend;
    }
    private void Subtract(int subtrahend)
    {
        this.innerValue -= subtrahend;
    }
    private void Multiply(int multiplier)
    {
        this.innerValue *= multiplier;
    }
    private void Divide(int divider)
    {
        this.innerValue /= divider;
    }
}

class Program
{
    static void Main(String[] args)
    {
        var type = typeof(BlackBox);
        var BBox = (BlackBox)Activator.CreateInstance(type, true);
        var field = type.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);
        if (field == null)
        {
            return;
        }
        while (true)
        {
            var line = Console.ReadLine();
            if (line == null)
            {
                break;
            }
            var tmp = line.Split('(');
            var methodName = tmp[0];
            var arg = new String(tmp[1].SkipLast(1).ToArray());
            var method = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (method == null)
            {
                Console.WriteLine("Invalid input");
                break;
            }
            method.Invoke(BBox, new object[] { Int32.Parse(arg) });
            Console.WriteLine(field.GetValue(BBox));
        }
    }
}