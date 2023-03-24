namespace HW14_FooBar
{
    /// <summary>
    /// программа для вывода foobar.
    /// </summary>
    public class FooBar
    {
        private static AutoResetEvent waitBar = new (true);
        private static AutoResetEvent waitFoo = new (false);

        /// <summary>
        /// юи, запуск программы.
        /// </summary>
        /// <param name="args">Аргументы командной строки.</param>
        public static void Main(string[] args)
        {
            Console.Write("n = ");
            Run(int.Parse(Console.ReadLine()));
            Console.ReadKey();
        }

        /// <summary>
        /// вывод foobar.
        /// </summary>
        /// /// <param name="n">колличество повторов.</param>
        public static void Run(int n)
        {
            Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    waitBar.WaitOne();
                    Console.Write("foo");
                    waitFoo.Set();
                }
            });
            Task.Run(() =>
            {
                for (int i = 0; i < n; i++)
                {
                    waitFoo.WaitOne();
                    Console.Write("bar");
                    waitBar.Set();
                }

                Console.WriteLine();
            });
        }
    }
}