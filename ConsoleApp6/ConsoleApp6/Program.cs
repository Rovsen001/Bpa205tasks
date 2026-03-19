namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Array lenght:");          //1.1
            //int n = int.Parse(Console.ReadLine());
            //int[] arr = new int[n];
            //Console.WriteLine("Input array: ");
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //Console.WriteLine("Value:");
            //int k = int.Parse(Console.ReadLine());
            //Console.WriteLine("Current array:");
            //foreach (int i in arr)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("New array:");
            //IncreaseAll(ref arr, k);
            //foreach (int i in arr)
            //{
            //    Console.WriteLine(i);
            //}


            //Console.WriteLine("Input balance:");                   //1.2
            //double balance=int.Parse(Console.ReadLine());
            //Console.WriteLine("Input amount:");
            //double amount=int.Parse(Console.ReadLine());
            //Withdraw(ref  balance, amount);


            //Console.WriteLine("Array lenght:");          //1.3
            //int n = int.Parse(Console.ReadLine());
            //int[] arr = new int[n];
            //Console.WriteLine("Input array: ");
            //for (int i = 0; i < n; i++)
            //{
            //    arr[i] = int.Parse(Console.ReadLine());
            //}
            //int min,max;
            //GetMinMax(ref arr, out min, out max);
            //Console.WriteLine($"Min: {min}, Max: {max}");


            //Console.WriteLine("Input number:");                        //1.4
            //int num=int.Parse(Console.ReadLine());
            //bool isEven;
            //ProcessNumber(ref num,out isEven);
            //Console.WriteLine($"Number: {num}, isEven: {isEven}");



            Book book = new Book();          //2
            book.SetName("Sefiller");
            book.SetPrice(25);
            book.SetAuthor("Viktor Huqo");
            book.ShowBookInfo();
        }
        public static void IncreaseAll(ref int[] arr,int value)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] += value;
            }
        }
        public static void Withdraw(ref double balance,double amount)
        {
            if (balance < amount)
            {
                Console.WriteLine("Not enough balance.");
            }
            else
            {
                balance = balance - amount;
                Console.WriteLine($"Balance: {balance}");
            }
        }
        public static void GetMinMax(ref int[] arr,out int min,out int max)
        {
            min = arr[0];
            max = arr[0];
            foreach(int i in arr)
            {
                if(min>i)min= i;
                else if(max<i)max= i;
            }
        }
        public static bool ProcessNumber(ref int number,out bool isEven)
        {
            number *= 2;
            if (number % 2==0) isEven= true;
            else isEven= false;
            return isEven;
        }

    }
}
