// The program shows the 3d digit of number

using System;
class Program
{
    // function without any return type declaration  
    public int GetNumber(string VarName)
    {
        int res;
        string input;
        bool is_number = false;
        do
        {
            Console.WriteLine(String.Format("Enter number: {0} = ", VarName));
            input = Console.ReadLine();
            
            is_number = int.TryParse(input, out res);
          
        } while (!is_number);

        return res;
    }
    
    public bool TestNumber_3c(int num) {
        
        if (num >= 100 && num < 1000) {
            return true;
        } else {
            return false;
        }
    }

    public List<int> ConvertNumberToArrayOfDigit(int num)
    {
        int Size = 3;
        List<int> DigitOfNumber = new List<int>();
        int Rest = 0;
        int LastNumber = num;
        int Base = 10;
        while(LastNumber != 0)
        {
            Rest = LastNumber % Base;
            DigitOfNumber.Add(Rest);
            LastNumber = (LastNumber - Rest) / Base;
        }
        return DigitOfNumber;
    }
    public void PrintNumberInDecimalNotation(int Number, List<int> NumberInDecimalNotation)
    {
        string Result = GetStringToPrintNumberInDecimalNotation(NumberInDecimalNotation);
        Console.WriteLine(String.Format("{0} = {1}", Number, Result));
    }

    public string GetStringToPrintNumberInDecimalNotation(List<int> NumberInDecimalNotation)
    {
        string Result = "";
        bool is_first_row = true;
        int MaxPower = 0;
        foreach(int digit in NumberInDecimalNotation) {
            
            if(is_first_row) {
                Result = Result + String.Format("{0}", digit, MaxPower);
                is_first_row = false;
                MaxPower = MaxPower + 1;
                continue;
            }
            string text_format = "{0}*10^{1} + ";
            if (MaxPower == 1) {
                text_format = "{0}*10 + ";
            }
            Result = String.Format(text_format, digit, MaxPower) + Result;
            MaxPower = MaxPower + 1;
        }
        return Result;
    }

    public static void Main(string[] args)
    {
        Program pr = new Program(); // Creating a class Object  
        Console.WriteLine("The program calculates the parity of a numbers.");

        string VarName_N = "N";
        int N = pr.GetNumber(VarName_N);
        List<int> DigintOfNumber = pr.ConvertNumberToArrayOfDigit(N);
        
        pr.PrintNumberInDecimalNotation(N, DigintOfNumber);
        int CountDigits = DigintOfNumber.Count();
        if (CountDigits < 3) {
            Console.WriteLine("The 3d digit does not exists!");
        } else {
            Console.WriteLine(String.Format("The 3d digit is {0} ", DigintOfNumber[CountDigits - 3]));
        }
        
    }
}