namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {

                //int a = 5;
                //int b = 2;
                //Swap(ref a,ref b);
                //Console.WriteLine($"a={a},b={b}");


                //int r=int.Parse(Console.ReadLine());
                //double Area,Lenght;  
                //Circle(r, out Area, out Lenght);
                //Console.WriteLine($"Area:{Area}, Length: {Lenght}");



                //double n=double.Parse(Console.ReadLine());
                //n = TenPercent(ref n);
                //Console.WriteLine(n);


                //int n = int.Parse(Console.ReadLine());
                //Console.WriteLine(Reverse(n));



            //   string str1=Console.ReadLine();
            //   string str2=Console.ReadLine();
            //Console.WriteLine(ConCat(ref str1, str2));


            }
        public static void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;

        }

        public static void Circle(double r, out double Area, out double Lenght)
        {
            double p = 3.14;
            Area = 2 * p * r * r;
            Lenght = 2 * p * r;

        }
        public static double TenPercent(ref double n)
        {
            return n * 1.1;
        }
        public static int Reverse(int n)
        {
            int s = 0;
            int h;
            while (n > 0)
            {
                h = n % 10;
                s = s * 10 + h;
                n /= 10;
            }
            return s;
        }
        public static string ConCat(ref string str1,params string[] strings)
        {
            for (int i = 0; i < strings.Length; i++) str1 += strings[i];
            return str1;
        }
    }
    
}
