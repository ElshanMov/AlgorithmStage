namespace SaveThePrisoner
{
    class Result
    {
        //In any case, only a few simple arithmetic operations are done, so the running time of this program is O(1).
        public static int saveThePrisoner(int n, int m, int s)
        {
            /*
             * Biz bilirik ki, proses dairəvi masa ətrafında baş verir.
             * Tutaq ki, sıramız 1-dən başlayır və "Konfetin Sayı Məhbusun Sayınnan Çoxdur" bu zaman rahatlıqla demək olur ki, 'm%n'-dən
             * alınan cavab sonuncu məhbusu bildirir. Məsələn, (m)konfet=6,(n)məhbus=4 və (s)sıra=1 olarsa deməli konfet paylanan zaman 1-dən
               başladığımıza görə 4 nəfərə konfet paylanacaq yerdə qalan 2 konfet dairəvi masa olduğu üçün 2-ci adama düşəcək.
               Yəni m%n => 6%4 = 2 olduğu isbat olundu. Ancaq bizdə sıra isdənilən yerdən başlayacağı üçün sıranıda üzərinə gəlməliyik
               və dairəvi masada olduğu üçün 1 çıxılmalıdır.
             */

            /*
             * "Məhbusun Sayı Konfetin Sayından Çox" olarsa proses fərqli baş verəcək çünki konfetin düşmə ardıcıllığı məhbusun sayına
             * nəzərən aparıldı. Məhbusun sayı konfetin sayınnan çox olarsa, `result = m % n + s - 1`-dwsturunda sıranın sayı məhbus sayından daha böyük qiymət alır bu isə mümkün deyil. Bunun üçün yenidən mod alaraq sıranın kimdə olduğunu müəyyənləşdirdim.
             */

            int result;
            if (m>n)
            {                           
                    result = m % n + s - 1;
            }
            else
            {
                result = (m % n + s - 1) % n;
            }
            return result;
        }
    }
    class Solution
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Number of tables: ");
            int t = Convert.ToInt32(Console.ReadLine());
            int[] firstMultipleInput=new int[3];
            for (int tItr = 0; tItr < t; tItr++)
            {

                Console.WriteLine("Enter the '1.Prison 2.Candy 3.First-step' - number.");
                for (int i = 0; i < firstMultipleInput.Length; i++)
                {
                    firstMultipleInput[i] = Convert.ToInt32(Console.ReadLine());

                }
                
                int n = firstMultipleInput[0];
                int m = firstMultipleInput[1];
                int s = firstMultipleInput[2];               
                int result = Result.saveThePrisoner(n, m, s);

                Console.WriteLine($"The prisoner to be warned sits in chair number {result}\n");
            }

        }
    }
}