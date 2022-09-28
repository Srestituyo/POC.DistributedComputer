using System;
using System.Net.Http.Headers;

namespace POC.DistributedComputer  
{
    internal class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
             
            Console.Write("Escribe el valor de la temperatura: ");
            var aTemp = Console.ReadLine();
            Console.Write("Esriba el tipo de temperatura: ");
            var aScale = Console.ReadLine();
            Console.Write("Escriba el tipo de temperatura a convertir: ");
            var aScaleToConvert = Console.ReadLine();

            ProcessRepositories(aTemp,aScale,aScaleToConvert);
            Console.ReadKey();

        }
        
        private static async Task ProcessRepositories(string aTemp, string aScale, string aScaleToConvert)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")); 

            var stringTask = await client.GetStringAsync($"http://192.168.1.10:5001/api/Temps?Temperature={aTemp}%2B{aScale}%2Bto%2B{aScaleToConvert}");
 
            Console.WriteLine(stringTask);
        }
    }
}



