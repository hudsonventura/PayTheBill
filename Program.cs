using ClickUp;
using Microsoft.Extensions.Configuration;

IConfiguration appsettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
    
double lista_anual = double.Parse(appsettings["ClickUp:lists:mensal"]);
double lista_mensal = double.Parse(appsettings["ClickUp:lists:mensal"]);
//double PRO_lista = 900700992947;
string id_team = appsettings["ClickUp:token"];
string token = appsettings["ClickUp:token"];
//int assignee = 49145376;
ClickUpClient clickup_client = new ClickUpClient(token);
TimeSpan now = DateTime.Now.TimeOfDay;



var tasks = clickup_client.Tasks.ListTasks(lista_mensal);
Console.WriteLine();


var task = clickup_client.Tasks.GetTask("86a2rjm9b");
Console.WriteLine();