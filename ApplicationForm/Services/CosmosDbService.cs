using ApplicationForm.Models;
using Microsoft.Azure.Cosmos;
using System.Collections.Concurrent;
using System.ComponentModel;


namespace ApplicationForm.Services
{
    public class CosmosDbService
    {
        private Microsoft.Azure.Cosmos.Container _container;

        public CosmosDbService(IConfiguration configuration)
        {
            var cosmosClient = new CosmosClient(configuration["CosmosDb:Account"], configuration["CosmosDb:Key"]);
            var database = cosmosClient.GetDatabase(configuration["CosmosDb:DatabaseName"]);
            _container = database.GetContainer(configuration["CosmosDb:ContainerName"]);
        }

        public async Task AddFormDataAsync(FormData formData)
        {
            formData.Id = System.Guid.NewGuid().ToString();
            await _container.CreateItemAsync(formData, new PartitionKey(formData.Id));
        }

        public async Task UpdateFormDataAsync(FormData formData)
        {
            await _container.ReplaceItemAsync(formData, formData.Id, new PartitionKey(formData.Id));
        }

        public async Task<FormData> GetFormDataAsync(string id)
        {
            try
            {
                ItemResponse<FormData> response = await _container.ReadItemAsync<FormData>(id, new PartitionKey(id));
                return response.Resource;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}
