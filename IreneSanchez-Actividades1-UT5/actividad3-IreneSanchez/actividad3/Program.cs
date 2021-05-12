/*Ejercicio 3. Con algún proyecto realizado en C#, incorpora la información a IntelliSense, tienes
en la teoría cómo incorporar la posibilidad de generar la documentación en XML de manera
automática. Localiza el fichero XML generado. ¿Con qué heramienta podrías generar la API
web?

*/
using System;
using System.Text;
using System.IO;

namespace Ejercicio06
{
    /// <summary>
    /// Clase Microprocesador formada por 3 atributos privados: frecuencia, modelo y núcleos
    /// </summary>
    public class Microprocesador
    {
        private float frecuencia;
        private string modelo;
        private short nucleos;
        /// <summary>
        /// Accesor del atributo frecuencia que devuelve el valor de la frecuencia
        /// </summary>
        /// <returns>una variable de tipo float con la frecuencia</returns>
        public float GetFrecuencia()
        {
            return frecuencia;
        }
        /// <summary>
        /// Accesor del atributo modelo que devuelve el valor del modelo
        /// </summary>
        /// <returns>una variable de tipo string con el modelo</returns>
        public string GetModelo()
        {
            return modelo;
        }
        /// <summary>
        /// Accesor del atributo nucleos que devuelve el valor de los nucleos
        /// </summary>
        /// <returns>una variable de tipo short con los nucleos</returns>
        public short GetNucleos()
        {
            return nucleos;
        }
        /// <summary>
        /// Constructor de Microprocesador con 3 parámetros de entrada en lo s que se indicarán el modelo, los núcleos y la frecuencia.
        /// </summary>
        /// <param name="modelo"></param>
        /// <param name="nucleos"></param>
        /// <param name="frecuencia"></param>
        public Microprocesador(string modelo, short nucleos, float frecuencia)
        {
            this.frecuencia = frecuencia;
            this.modelo = modelo;
            this.nucleos = nucleos;
        }
        /// <summary>
        /// Método ACSV devuelve un string formado por los atributos separados por ";"
        /// </summary>
        /// <returns>devuelve una variable de tipo string con los valores separados por comas"</returns>
        public string ACSV()
        {
            return $"{modelo};{nucleos};{frecuencia}";
        }
        /// <summary>
        /// Método AMicroprocesador separa las comas que haya en el parametro de entrada y los iguala a los atributos para que tomen los mismos valores.
        /// </summary>
        /// <param name="cadena"></param>
        public void AMicroprocesador(String cadena)
        {
            string[] atributos = cadena.Split(';');
            modelo = atributos[0];
            nucleos = short.Parse(atributos[1]);
            frecuencia = float.Parse(atributos[2]);
        }

        /// <summary>
        /// Método ToString método que sirve para mostrar el modelo, la frecuencia y los núcleor.
        /// </summary>
        /// <returns>una variabe de tipo string con el valor del modelo, nucleos y frecuencia</returns>
        public override string ToString()
        {
            return $"Modelo:{GetModelo()}\nNucleos:{GetNucleos()}\nFrecuencia:{GetFrecuencia()}";
        }
    }

    /// <summary>
    /// Clase principal en la que se desarrollará todo el programa.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método público LeeCSV se encarga de leer un fichero .csv línea a línea y los pasa a un array de objetos Microprocesador.
        /// </summary>
        /// <param name="ruta"></param>
        /// <returns>un array del objeto Microprocesador</returns>
        static public Microprocesador[] LeeCSV(string ruta)
        {
            Microprocesador[] microprocesador = new Microprocesador[0];
            using FileStream stream = new FileStream(ruta, FileMode.Open, FileAccess.Read);
            using StreamReader sr = new StreamReader(stream, Encoding.UTF8);
            while (sr.Peek() != -1)
            {
                string[] campos = sr.ReadLine().Split(';');
                Array.Resize(ref microprocesador, microprocesador.Length + 1);
                microprocesador[^1] = new Microprocesador(campos[0], short.Parse(campos[1]), float.Parse(campos[2]));
            }
            return microprocesador;
        }
        /// <summary>
        /// Método público estático ACSV en los que convierte un objeto en una línea en el fichero .csv que se encuentra en uno de los parámetros de entrada.
        /// </summary>
        /// <param name="ruta"></param>
        /// <param name="microprocesador"></param>
        public static void ACSV(string ruta, Microprocesador microprocesador)
        {
            using FileStream stream = new FileStream(ruta, FileMode.Append, FileAccess.Write);
            using StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);
            sw.WriteLine($"{microprocesador.GetModelo()};{microprocesador.GetNucleos()};{microprocesador.GetFrecuencia()};");
        }
        /// <summary>
        /// Método estático MuestraMicroprocesadors se encarga de mostrar el array de Microprocesadores que se introduce como parámetro de entrada en el método.
        /// </summary>
        /// <param name="microprocesadors"></param>
        static void MuestraMicroprocesadors(Microprocesador[] microprocesadors)
        {
            foreach (var a in microprocesadors) Console.WriteLine(a);
        }
        /// <summary>
        /// Método estático RecogeMicroprocesadores se encarga de crear y devolver un array de microprocesadores con datos de procesadores.
        /// </summary>
        /// <returns>Array del objeto Microprocesador</returns>
        static Microprocesador[] RecogeMicroprocesadores()
        {
            Microprocesador[] microprocesadors = new Microprocesador[3];
            microprocesadors[0] = new Microprocesador("Intel Core I7", 4, 3.6f);
            microprocesadors[1] = new Microprocesador("Intel Core I5", 4, 2.4f);
            microprocesadors[2] = new Microprocesador("Intel Celeron", 2, 3.3f);
            return microprocesadors;
        }



        static void Main()
        {
            const string FICHERO = "Microprocesador.csv";

            foreach (var a in RecogeMicroprocesadores()) ACSV(FICHERO, a);
            MuestraMicroprocesadors(LeeCSV(FICHERO));

        }
    }
}
