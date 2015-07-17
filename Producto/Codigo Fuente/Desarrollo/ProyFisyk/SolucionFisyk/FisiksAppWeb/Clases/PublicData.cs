using System.Collections;

namespace FisiksAppWeb.Clases
{
    public class PublicData
    {
        //________________________________________________________________________________________________________
        //  Genero ArrayList de Altura
        public static ArrayList ArrayAltura()
        {
            ArrayList altura = new ArrayList();
            altura.Add("Elegir...");
            for ( int i = 50 ; i <=  250 ; i++)
            {
                altura.Add(i + " cm");
            }
            return altura;
        }

        //________________________________________________________________________________________________________
        //  Genero ArrayList de Peso
        public static ArrayList ArrayPeso()
        {
            ArrayList peso = new ArrayList();
            peso.Add("Elegir...");
            for (int i = 2; i <= 200; i++)
            {
                peso.Add(i + " Kg");
            }
            return peso;
        }


        //________________________________________________________________________________________________________
        //  Genero ArrayList de Pesion Maxima y Minima
        public static ArrayList ArrayMaxMin()
        {
            ArrayList maxMin = new ArrayList();
            maxMin.Add("Elegir...");
            maxMin.Add("");
            for (int i = 5; i <= 20; i++)
            {
                maxMin.Add(i);
            }
            return maxMin;
        }


        //________________________________________________________________________________________________________

        //________________________________________________________________________________________________________

    }
}
