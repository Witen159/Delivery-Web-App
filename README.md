# Delivery-Web-App

For the application to work correctly, `PostgreSQL` must be installed on the device.

Launch Instructions:

1. Through the terminal, while in the folder `.\Orders.Data\` apply command to create Migration:
   ```
   dotnet ef migrations add Initial
   ```
   
   P.S. In case of an error, most likely the `dotnet ef` tool is not installed on the device. In this case, apply the command to install it:
   ```
   dotnet tool install --global dotnet-ef
   ```
   
2. Apply the command to update the Database to the latest Migration:
   ```
   dotnet ef database update
   ```
   
 3. Run `Program.cs` located in the `Orders.Web` project
