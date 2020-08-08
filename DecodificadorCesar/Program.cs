using System;

namespace DecodificadorCesar
{
    class Program
    {
        static void Main(string[] args)
        {
            string cadenaCodificada;
            int desplazamiento;

            Console.WriteLine("Introduzca cadena codificada y pulse enter");
            cadenaCodificada = Console.ReadLine();
            bool notOk;
            do
            {
                notOk = true;
                Console.WriteLine("Introduce número de desplazamiento entre 1 y 1000 y pulse enter");
                string predesplazamiento = Console.ReadLine();

                try
                {
                    desplazamiento = Convert.ToInt32(predesplazamiento);
                }
                catch (Exception e)
                {
                    Console.WriteLine("No has introducido un número correcto,por ahora es cero");
                    desplazamiento = 0; // esto se realiza para que el valor del parámetro desplazamiento no sea nulo
                    notOk = false;
                }
            }
            while (notOk == false);

            if (desplazamiento > 1000 || desplazamiento < 0)
            {
                Console.WriteLine("El numero de desplazamiento no es correcto\nReinicia el decodificador");
                Environment.Exit(-1);
            }

            try
            {
                string cadenaDecodificada = Program.DecodigoCesar(cadenaCodificada, desplazamiento);//Program no es necesario ya que estamos dentro de la clase
                Console.WriteLine("La cadena original es : " + cadenaDecodificada);
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine("El texto codificado no es correcto, reinicia y vuelve a introducirlo");
            }
        }

        // Creamos método para decodificar texto,creando un array de char para convertir cada letra y volvemos a reconstruir el string original
        static string DecodigoCesar(string str, int num)
        {
            Console.WriteLine(str);
            char[] textoChar = str.ToCharArray();
            //Console.WriteLine(textoChar);

            for (int i = 0; i < str.Length; i++)
            {
                int ascii_CharCodificado = Convert.ToInt32(textoChar[i]);
                // Console.WriteLine(ascii_CharCodificado);
                if (num > 91) num %= 91;
                int ascii_charOriginal = ascii_CharCodificado - num;
                if (ascii_charOriginal < 32) ascii_charOriginal = (ascii_charOriginal + 122 - 31);

                textoChar[i] = Convert.ToChar(ascii_charOriginal);
            }
            string textoOriginal = new string(textoChar);
            return
                 textoOriginal;

        }
    }
}
