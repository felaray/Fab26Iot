// See https://aka.ms/new-console-template for more information
using Microsoft.Azure.Devices.Client;
using System.Text;

Console.WriteLine("Hello, World!");
try
{
    // IoT Hub連接字串
    string connectionString =
    "HostName=fab26iot.azure-devices.net;DeviceId=ryzenItv;SharedAccessKey=9vRAR9b+Ibx9LTeQ5G5VeLO2DaNe++oUqwM8CL717Y4=";
    // 建立DeviceClient
    var deviceClient = DeviceClient.CreateFromConnectionString(connectionString);

    // 連接到IoT Hub
    await deviceClient.OpenAsync();

    // 發送訊息到IoT Hub
    string message = "Hello IoT Hub!";
    var payload = new Message(Encoding.UTF8.GetBytes(message));
    await deviceClient.SendEventAsync(payload);

    // 關閉連接
    await deviceClient.CloseAsync();
}
catch (Exception ex)
{
    throw ex;
}finally
{
    Console.WriteLine("Press any key to exit.");
    Console.ReadLine();
}