using System.Collections;

namespace FisiksAppWeb
{
    public class PublicData
    {
        //________________________________________________________________________________________________________
        //  Genero ArrayList de Altura
        public static ArrayList ArrayAltura()
        {
            ArrayList altura = new ArrayList();
            altura.Add("");
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
            peso.Add("");
            for (int i = 2; i <= 200; i++)
            {
                peso.Add(i + ",0 Kg");
                if (i == 200) { break; }
                peso.Add(i + ",5 Kg");
            }
            return peso;
        }


        //________________________________________________________________________________________________________

    }
}
