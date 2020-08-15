using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock
{
    public class SetClock
    {
        //srodek okręgu
        private int cx;
        private int cy;

        //constractor
        public SetClock(int cx, int cy)
        {
            this.cx = cx;
            this.cy = cy;
        }

        //funkcja ustalająca położenie końca wskazówki (sekundy i minuty)
        //lenghtHand - długość wskazówki
        //sevValue - wartość w sekundach
        public int[] SecSetHandOfAClock(int lenghtHand, int secValue)
        {
            int[] setSecMin = new int[2];
            //przeliczenie liczby sekund na kąt na zegarze
            //each secound make 6 degree
            secValue *= 6; 

            //jeśli wskazówka jest między 00:00 a 06.00
            if (secValue >= 0 && secValue <= 180)
            {
                setSecMin[0] = cx + (int)(lenghtHand * Math.Sin(Math.PI * secValue / 180));
                setSecMin[1] = cy - (int)(lenghtHand * Math.Cos(Math.PI * secValue / 180));
            }
            //jeśli wskazówka jest między 06.01 a 11,59
            else
            {
                setSecMin[0] = cx - (int)(lenghtHand * -Math.Sin(Math.PI * secValue / 180));
                setSecMin[1] = cy - (int)(lenghtHand * Math.Cos(Math.PI * secValue / 180));
            }
            return setSecMin;
        }


        //funkcja ustalająca położenie końca wskazówki godzin
        //ustalanie położenia wskazówki na podstawie godzin oraz minut
        public int[] HourSetHandOfAClock(int lenghtHand, int minValue, int hourValue)
        {
            int[] setHour = new int[2];
            //dodatkowe przesunięcie na podstawie minut
            hourValue = (int)((hourValue * 30) + (minValue * 0.5)); //for hours
            if (hourValue >= 0 && hourValue <= 180)
            {
                setHour[0] = cx + (int)(lenghtHand * Math.Sin(Math.PI * hourValue / 180));
                setHour[1] = cy - (int)(lenghtHand * Math.Cos(Math.PI * hourValue / 180));
            }
            else
            {
                setHour[0] = cx - (int)(lenghtHand * -Math.Sin(Math.PI * hourValue / 180));
                setHour[1] = cy - (int)(lenghtHand * Math.Cos(Math.PI * hourValue / 180));
            }
            return setHour;
        }

        //funkcja ustalająca położenie liczbowej wartości godzin
        public int[] SetHourString(int lenghtHand, int hourValueSt)
        {
            int[] setHrStr = new int[2];
            //każda cyfra to przeunięcie o 30 stopni
            //each secound make 30 degree
            hourValueSt *= 30; 

            if (hourValueSt >= 0 && hourValueSt <= 180)
            {
                setHrStr[0] = cx + (int)(lenghtHand * Math.Sin(Math.PI * hourValueSt / 180));
                setHrStr[1] = cy - (int)(lenghtHand * Math.Cos(Math.PI * hourValueSt / 180));
            }
            else
            {
                setHrStr[0] = cx - (int)(lenghtHand * -Math.Sin(Math.PI * hourValueSt / 180));
                setHrStr[1] = cy - (int)(lenghtHand * Math.Cos(Math.PI * hourValueSt / 180));
            }
            return setHrStr;
        }

    }
}
