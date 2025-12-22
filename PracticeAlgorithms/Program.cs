using System.Linq;
using System.Text;
using System.Collections;

class Program
{

    static Boolean IsUpperCase(string input) {
        return input.All(char.IsUpper);
    }

    static Boolean IsLowerCase(string input) {
        return input.All(char.IsLower);
    }

    static Boolean IsPasswordComplex(string password) {
        return password.Any(char.IsUpper) && password.Any(char.IsLower) && password.Any(char.IsDigit);
    }

    static string NormaliseString(string userInput) {
        //Covert to lower case
        //Then trim spaces
        //Then replace ',' with ''
        return userInput.ToLower().Trim().Replace(",", "");
    }

    static void ParseContents(string s) {

        Console.WriteLine("Option 1");
        foreach (char letter in s) {
            Console.WriteLine(letter);
        }

        Console.WriteLine("Option 2");
        for(int i = 0; i < s.Length; i++)
        {
            char c = s[i];
            Console.WriteLine(c);
        }

    }

    static Boolean IsAtEvenIndex(string s, char item)
    {
        for(int i = 0; i < s.Length / 2 + 1; i = i + 2)
        {
            if (item == s[i])
                return true;
        }
        return false;
    }

    static string ReverseString(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }
        StringBuilder reversed = new StringBuilder(input.Length);
        for(int i = input.Length - 1; i >= 0; i--)
        {
            reversed.Append(input[i]);
        }

        return reversed.ToString();
    }

    static string Reverse2(string input)
    {
        var arrayInput = input.ToCharArray();
        Array.Reverse(arrayInput);
        return new string(arrayInput);
    }

    static Boolean BinarySearch(int[] array, int item)
    {
        // This will check if the item exist in the Array
        // Set min = 0 and set max is end of array length
        // Loop through the array, and set mid point
        // if item == mid point, then return true
        // else if item < mid point, search in first half
        // else, search in the other half
        // Return false if there is no record
        int min = 0;
        int max = array.Length - 1;

        while(min <= max)
        {
            int mid = (min + max) / 2;
            if (item == array[mid])
            {
                return true;
            }
            else if (item < array[mid]) { //check first half
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }

        return false;
        
    }

    static int[] FindEvenNumber(int[] arrayOne, int[] arrayTwo) {
        // Find even number from array one and array two
        ArrayList result = new ArrayList();
        foreach(int num in arrayOne)
        {
            if(num % 2 == 0)
            {
                result.Add(num);
            }
        }

        foreach(int num in arrayTwo)
        {
            if(num % 2 == 0)
            {
                result.Add(num);
            }
        }

        return (int[])result.ToArray(typeof(int));
    }

    static int[] Reverse(int[] input)
    {
        int[] reversed = new int[input.Length];
        for(int i = 0; i < input.Length; i++)
        {
            reversed[i] = input[input.Length - i - 1];
        }

        return reversed;
    }

    static int[] ReverseInPlace(int[] input)
    {
        // We will swap the number, first number with last number
        // So we only need loop half of the array

        for (int i = 0; i < input.Length / 2; i++)
        {
            int temp = input[i]; // Storing first number
            input[i] = input[input.Length - i - 1]; // Replace the first number with last number
            input[input.Length - i - 1] = temp; // Replace the last with first number
        }
        return input;
    }

    static void Main(string[] args)
    {
        //Console.WriteLine(IsLowerCase("HELLO"));
        //Console.WriteLine(IsLowerCase("Hello"));
        //Console.WriteLine(IsLowerCase("123"));
        //Console.WriteLine(IsLowerCase("000"));

        //Console.WriteLine(IsUpperCase("HELLO"));
        //Console.WriteLine(IsUpperCase("123"));
        //Console.WriteLine(IsUpperCase("000"));

        //Console.WriteLine(IsPasswordComplex("Hello123"));
        //Console.WriteLine(IsPasswordComplex("12345"));
        //Console.WriteLine(IsPasswordComplex("Passw0rd"));
        //Console.WriteLine(IsPasswordComplex("hello"));

        //Console.WriteLine(NormaliseString("  Hello there, How are you DOING?         "));

        //Console.WriteLine(ReverseString("ChungLe"));
        //Console.WriteLine(ReverseString(null));
        //Console.WriteLine(ReverseString("1234"));
        //Console.WriteLine(ReverseString(" "));

        //int[] arr = { 1, 2, 3, 4, 5, 6 };
        //Console.WriteLine(BinarySearch(arr, 5));

        int[] arrayOne = {1, 20, 4, 7, -15};
        int[] arrayTwo = {20, -32, 6, 17, 55 };

        //int[] evenNum = FindEvenNumber(arrayOne, arrayTwo);
        //Array.ForEach(evenNum, Console.WriteLine);

        int[] reversedArray = ReverseInPlace(arrayOne);
        Array.ForEach(reversedArray, Console.WriteLine);
    }

}