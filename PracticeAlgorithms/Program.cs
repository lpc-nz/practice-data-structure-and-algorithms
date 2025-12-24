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

    static void printBinaryNumber(int number)
    {
        //Check valid input
        if(number <= 0)
        {
            return;
        }

        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        for(int i = 0; i < number; i++)
        {
            // 1 -> 10 -> 11 -> 100 -> 101 -> 111 -> 1000
            int current = queue.Dequeue();
            Console.WriteLine(current);

            queue.Enqueue(current * 10);
            queue.Enqueue(current * 10 + 1);
        }

        Console.WriteLine();

    }

    static void findNextGreaterNumber(int[] array)
    {
        //Null check
        if(array.Length <= 0)
        {
            return;
        }

        //Setup stack to keep track the array
        Stack<int> stack = new Stack<int>();

        // Add first element into the stack
        stack.Push(array[0]); //15
        //Then we can loop through the array
        for(int i = 1; i < array.Length; i++)
        {
            int next = array[i];//8
            //Checking the Stack has item
            if(stack.Count > 0)
            {
                int popped = stack.Pop();//15
                while(popped < next)// 8 < 10 --> Found the next greater, 
                {
                    Console.WriteLine(popped + "-->" + next);
                    if(stack.Count <= 0)
                    {
                        break;
                    }
                    popped = stack.Pop();
                }

                if(popped > next) //15 > 8 --> Not match the requirement
                {
                    stack.Push(popped); // stack: 8
                }
            }
            stack.Push(next); 
        }

        while(stack.Count > 0)
        {
            Console.WriteLine(stack.Pop() + "-->" + -1);
        }

    }

    static void findNextGreaterNumber2(int[] ints) {
        //Null check
        if(ints.Length <= 0)
        {
            Console.WriteLine();
            return;
        }

        // Create stack to keep track the value
        Stack<int> stack = new Stack<int>();
        stack.Push(ints[0]);

        //Loop through the list to check the next number
        for(int i = 1; i < ints.Length; i++)
        {
            if(stack.Count > 0)
            {
                int next = ints[i];
                int popped = stack.Pop();
                while(popped < next)
                {
                    Console.WriteLine(popped + "-->" + next);
                    if(stack.Count <= 0) {
                        break;
                    }
                    popped = stack.Pop();
                }

                if(popped > next)
                {
                    stack.Push(popped);
                }

                stack.Push(next);

            }
        }
        while(stack.Count > 0)
        {
            Console.WriteLine(stack.Pop() + "-->" + -1);
        }
    }

    static Boolean hasMatchingParentheses(string sympol) {
        Stack<char> stack = new Stack<char>();
        for(int i = 0; i< sympol.Length; i++)
        {
            char current = sympol[i];
            if(current == '(')
            {
                stack.Push(current);
                continue;
            }

            if(current == ')')
            {
                if(stack.Count > 0)
                {
                    stack.Pop();
                }
                else
                {
                    return false;
                }
                
            }

        }

        return stack.Count == 0;
    }

    public static bool IsNumber(string token)
    {
        try
        {
            double.Parse(token);
            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }

    public static bool IsOperator(string token)
    {
        return "+-*/".Contains(token);
    }

    public static double PerformOperation(string @operator, double operand1, double operand2)
    {
        switch (@operator)
        {
            case "+":
                return operand1 + operand2;
            case "-":
                return operand1 - operand2;
            case "*":
                return operand1 * operand2;
            case "/":
                if (operand2 == 0)
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                return operand1 / operand2;
            default:
                throw new ArgumentException("Invalid operator: " + @operator);
        }
    }

    // Return the result of the Reverse Polish notation expression
    public static double EvaluateRPN(string expression)
    {
        // Your code goes here.
        Stack<double> stack = new Stack<double>();
        double finalResult = 0;
        for (int i = 0; i < expression.Length; i++)
        {
            string item = expression[i].ToString();
            if (IsNumber(item))
            {
                stack.Push(int.Parse(item));
            }
            if (IsOperator(item))
            {
                if (stack.Count > 2)
                {
                    double first = stack.Pop();
                    double second = stack.Pop();
                    double result = PerformOperation(item, first, second);
                    stack.Push(result);
                }
            }

        }
        if (stack.Count > 0)
        {
            finalResult = stack.Pop();
        }

        return finalResult;
    }

    static void Main(string[] args){

        string expression = "3 4 +";
        double result = EvaluateRPN(expression);
        Console.WriteLine(result);

        //Console.WriteLine(hasMatchingParentheses("()hello()"));
        //Console.WriteLine(hasMatchingParentheses("(())hello(())"));
        //Console.WriteLine(hasMatchingParentheses("hello(())"));
        //Console.WriteLine(hasMatchingParentheses("(hello)()"));

        //Console.WriteLine("------");

        //Console.WriteLine(hasMatchingParentheses("(hello()"));
        //Console.WriteLine(hasMatchingParentheses("((hello"));
        //Console.WriteLine(hasMatchingParentheses("((hello("));
        //Console.WriteLine(hasMatchingParentheses("))hello"));

        //int[] arr = new int[] {15, 8, 4, 10};
        //int[] arr2 = new int[] { 2 };
        //int[] arr3 = new int[] { 2, 3 };
        //int[] arr4 = new int[] { };

        //findNextGreaterNumber2(arr);
        //findNextGreaterNumber2(arr2);
        //findNextGreaterNumber2(arr3);
        //findNextGreaterNumber2(arr4);


        //Stack
        //Stack<string> myStacks = new Stack<string>();

        //myStacks.Push("Main");
        //myStacks.Push("ResponseBuilder");
        //myStacks.Push("CallExternalService");

        //Console.WriteLine("End " + myStacks.Pop());
        //myStacks.Push("ParseExternalData");
        //Console.WriteLine("End " + myStacks.Pop());
        //Console.WriteLine("End " + myStacks.Pop());
        //Console.WriteLine("End " + myStacks.Pop());


        // printBinaryNumber(5);

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

        //int[] arrayOne = {1, 20, 4, 7, -15};
        //int[] arrayTwo = {20, -32, 6, 17, 55 };

        //int[] evenNum = FindEvenNumber(arrayOne, arrayTwo);
        //Array.ForEach(evenNum, Console.WriteLine);

        //int[] reversedArray = ReverseInPlace(arrayOne);
        //Array.ForEach(reversedArray, Console.WriteLine);

        //Queue<int> queue = new Queue<int>();

        //queue.Enqueue(1);
        //queue.Enqueue(2);
        //queue.Enqueue(3);
        //queue.Enqueue(4);
        //queue.Enqueue(5);

        ////Queue will remove first item in the queue
        //// First in, first out
        //int removedItem = queue.Dequeue();
        //Console.WriteLine(removedItem); //Number 1

        ////Peek is select the fist item in the queue
        ////It will not remove item
        //int peekItem = queue.Peek(); //Number 2
        //Console.WriteLine(peekItem);

        //int current;
        //while (queue.TryDequeue(out current))
        //{
        //    Console.WriteLine(current);
        //}
    }

}