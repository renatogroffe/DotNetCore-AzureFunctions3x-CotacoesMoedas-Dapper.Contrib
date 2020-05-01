using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using System.Text.Json;
using ServerlessMoedas.Models;
using Dapper.Contrib.Extensions;

namespace ServerlessMoedas
{
    public static class MoedasQueueTrigger
    {
        [FunctionName("MoedasQueueTrigger")]
        public static void Run([QueueTrigger("queue-cotacoes", Connection = "AzureWebJobsStorage")]string myQueueItem, ILogger log)
        {
            var cotacao =
                JsonSerializer.Deserialize<Cotacao>(myQueueItem);

            if (!String.IsNullOrWhiteSpace(cotacao.Sigla) &&
                cotacao.Valor.HasValue && cotacao.Valor > 0)
            {
                using (var conexao = new SqlConnection(
                    Environment.GetEnvironmentVariable("BaseCotacoes")))
                {
                    var dadosCotacao = conexao.Get<Cotacao>(cotacao.Sigla);
                    if (dadosCotacao != null)
                    {
                        dadosCotacao.UltimaCotacao = DateTime.Now;
                        dadosCotacao.Valor = cotacao.Valor;
                        conexao.Update(dadosCotacao);
                    }
                }

                log.LogInformation($"MoedasQueueTrigger: {myQueueItem}");
            }
            else
                log.LogError($"MoedasQueueTrigger - Erro validação: {myQueueItem}");
        }
    }
}