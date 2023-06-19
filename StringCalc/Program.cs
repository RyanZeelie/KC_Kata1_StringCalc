using StringCalc;

var calc = new Calculator();

try
{
    var res = calc.Add("1,2,3");

    Console.WriteLine(res);
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

