using Localiza.Diogo.Modelo;

using Newtonsoft.Json;

using System;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Text;

namespace Localiza.Diogo.Client01
{
    class Program
    {
        static HttpClient client = new HttpClient();

        private static string BaseUrl => ConfigurationManager.AppSettings["apiGateway"];

        static void Main(string[] args)
        {
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            GerenciarApp();
        }

        static void GerenciarApp()
        {
            Console.WriteLine("Bem vindo");
            
            ApresentarOpcoes();

            Console.WriteLine("Finalizando programa");
        }

        static async void ApresentarOpcoes()
        {
            Console.WriteLine("--Digite--");
            Console.WriteLine("A - Para iniciar o processo");
            Console.WriteLine("B - Para para finalizar a aplicação");

            var rEntrada = Console.ReadLine();

            if (rEntrada == "A" || rEntrada == "a")
            {
                int num = 0;

                while(!NumeroValido(rEntrada))
                {
                    Console.WriteLine("Digite um número inteiro válido para iniciarmos a operação");
                    rEntrada = Console.ReadLine();
                }

                num = Convert.ToInt32(rEntrada);

                //TODO: aguardar resposta 
                Operacao(num);
                ApresentarOpcoes();
            }
            else if (rEntrada == "B" || rEntrada == "b")
            {
                Console.WriteLine("Obrigado pela utilização do sistema");
            }
            else
            {
                Console.WriteLine("Resultado Inválido");
                Console.WriteLine("-------------------");
                ApresentarOpcoes();
            }
        }

        static bool NumeroValido(string num)
        {
            //TODO: validar double e decimal
            try
            {
                Convert.ToInt32(num);
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }

        static async void Operacao(int num)
        {
            //TODO: ajustar bug
            
            var jsonContent = JsonConvert.SerializeObject(num);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync($"/api/v1/Numero/fatorar", contentString);
            response.EnsureSuccessStatusCode();

            var resposta = response.Content.ReadAsAsync<mResposta>().Result;

            var divisores = resposta.Divisores.OrderBy(o => o);
            var primos = resposta.Primos.OrderBy(o => o);

            Console.WriteLine($"Número de Entrada: {resposta.Entrada} \r\n " +
                $"Números divisores: {string.Join(" ", divisores)} \r\n " +
                $"Divisores Primos: {string.Join(" ", primos)} \r\n ");

            Console.WriteLine("---");
            Console.WriteLine("---");
            Console.WriteLine("--Digite--");
            Console.WriteLine("A - Para iniciar o processo");
            Console.WriteLine("B - Para para finalizar a aplicação");
        }
    }
}
