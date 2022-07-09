using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleApp1
{
    public class GetInventoryApp
    {

        public async Task ObtenerInventoryAsync()
        {
            var tokenBearer = "";
            var app_key = "742e1293-ce33-4d25-83d3-3f17af0a415b";
            var hotelId = "GNQ";

            Console.WriteLine("Obteniendo autorización...");
            var tokenApp = new ConsoleApp1.GetTokenApp();
            tokenBearer = await tokenApp.ObtenerTokenAsync();

            OperaCloud.Inventory.Client.Client client = new OperaCloud.Inventory.Client.Client("https://mtucn1uat.hospitality-api.us-ashburn-1.ocs.oc-test.com/inv/v1");

            var respuesta = await client.GetHotelInventoryAsync(hotelId, DateTimeOffset.Now.AddDays(2),
                DateTimeOffset.Now.AddDays(4), 1, false, true, true, null, null, tokenBearer, app_key, hotelId, "GNQ-API", "en-us");

            if (respuesta.HotelInventories == null)
                Console.WriteLine("HotelInventories Null");
            else
            {
                ICollection<OperaCloud.Inventory.Client.HotelInventoryType> hotelInventoryTypes = respuesta.HotelInventories;

                foreach(OperaCloud.Inventory.Client.HotelInventoryType item in hotelInventoryTypes)
                {
                    var StartDate = item.HouseInventory[0].StartDate;
                    var EndDate = item.HouseInventory[0].EndDate;

                    Console.WriteLine($"StartDate: {StartDate}  -  EndDate: {EndDate}");
                }

                Console.WriteLine($"{respuesta.HotelInventories.Count} inventarios encontrados.");
            }
                

        }
    }
}
