// See https://aka.ms/new-console-template for more information

Console.WriteLine("Vamos que se puede");
Console.ReadKey();

try
{
    //ConsoleApp1.GetTokenApp token = new ConsoleApp1.GetTokenApp();
    //await token.ObtenerTokenAsync();

    //ConsoleApp1.GetCustomerApp customerApp = new ConsoleApp1.GetCustomerApp();
    //await customerApp.CrearGuestProfileAsync();

    //ConsoleApp1.GetInventoryApp inventory = new ConsoleApp1.GetInventoryApp();
    //await inventory.ObtenerInventoryAsync();

    ConsoleApp1.GetReservationApp reservations = new ConsoleApp1.GetReservationApp();
    //await reservations.ObtenerReservationsAsync();
    //await reservations.CrearReservation();
    await reservations.GetReservationById();

    Console.ReadKey();

}
catch(Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.ReadKey();
    //Console.WriteLine(ex.StackTrace);
    //Console.ReadKey();
}
