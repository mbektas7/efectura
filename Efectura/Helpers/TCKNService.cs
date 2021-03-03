using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Efectura.Helpers
{
    public class TCKNService
    {


        public static bool TcknDogrula(string tcKimlikNo)
        {
            bool returnvalue = false;
            if (tcKimlikNo.Length == 11)
            {
                Int64 ATCNO, BTCNO, TcNo;
                long C1, C2, C3, C4, C5, C6, C7, C8, C9, Q1, Q2;

                TcNo = Int64.Parse(tcKimlikNo);

                ATCNO = TcNo / 100;
                BTCNO = TcNo / 100;

                C1 = ATCNO % 10; ATCNO = ATCNO / 10;
                C2 = ATCNO % 10; ATCNO = ATCNO / 10;
                C3 = ATCNO % 10; ATCNO = ATCNO / 10;
                C4 = ATCNO % 10; ATCNO = ATCNO / 10;
                C5 = ATCNO % 10; ATCNO = ATCNO / 10;
                C6 = ATCNO % 10; ATCNO = ATCNO / 10;
                C7 = ATCNO % 10; ATCNO = ATCNO / 10;
                C8 = ATCNO % 10; ATCNO = ATCNO / 10;
                C9 = ATCNO % 10; ATCNO = ATCNO / 10;
                Q1 = ((10 - ((((C1 + C3 + C5 + C7 + C9) * 3) + (C2 + C4 + C6 + C8)) % 10)) % 10);
                Q2 = ((10 - (((((C2 + C4 + C6 + C8) + Q1) * 3) + (C1 + C3 + C5 + C7 + C9)) % 10)) % 10);

                returnvalue = ((BTCNO * 100) + (Q1 * 10) + Q2 == TcNo);
            }
            return returnvalue;
        }

        public static string TcknGenerator()
        {
            int[] rakamlar = new int[11];
            Random rnd = new Random();


            for (int i = 0; i < 9; i++)
            {
                rakamlar[i] = rnd.Next(0, 9);
            }
            if (rakamlar[0]==0)
            {
                rakamlar[0] = rnd.Next(0, 9);
            }
      
                int algoritmikAdim1 = (((rakamlar[0] + rakamlar[2] + rakamlar[4] + rakamlar[6] + rakamlar[8]) * 7) - (rakamlar[1] + rakamlar[3] + rakamlar[5] + rakamlar[7])) ;

                int onHane = algoritmikAdim1 % 10;
                int onToplam = 0;
                rakamlar[9] = onHane;
                for (int i = 0; i < rakamlar.Length; i++)
                {
                    onToplam += rakamlar[i];
                }


                int onbirHane = onToplam % 10;

              
                rakamlar[10] = onbirHane;
            
            string tckimlikNo = "";
            foreach (var item in rakamlar)
            {
                tckimlikNo += item.ToString() ;
            }


            return tckimlikNo;
        }

    }
}
