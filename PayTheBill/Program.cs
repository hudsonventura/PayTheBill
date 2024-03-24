
using Microsoft.Extensions.Configuration;
using PayTheBill;
using ClickUp;

Console.WriteLine($"Iniciando ... ");
IConfiguration appsettings = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .Build();
    
double lista_anual = double.Parse(appsettings["ClickUp:lists:anual"]);
double lista_mensal = double.Parse(appsettings["ClickUp:lists:mensal"]);
string id_team = appsettings["ClickUp:token"];
string token = appsettings["ClickUp:token"];
int assignee = int.Parse(appsettings["ClickUp:assignee"]);
ClickUpClient clickup_client = new ClickUpClient(token);
TimeSpan now = DateTime.Now.TimeOfDay;


Console.Write($"Obtendo dados mensais ... ");
var mensais = appsettings.GetSection("Contas:Mensais").Get<List<Conta>>();
var tasks_mensais = clickup_client.Tasks.ListTasks(lista_mensal, 0, false);
Console.WriteLine($"Tratando contas mensais ... ");
tratar_mensais(mensais, tasks_mensais, lista_mensal, DateTime.Now.AddMonths(1).Month);
Console.WriteLine($"Tratativa de contas mensais encerradas");


Console.Write($"Obtendo dados anuais ... ");
var anuais = appsettings.GetSection("Contas:Anuais").Get<List<Conta>>();
var tasks_anuais = clickup_client.Tasks.ListTasks(lista_anual, 0, false);
Console.WriteLine($"Tratando contas anuais ... ");
tratar_anuais(anuais, tasks_anuais, lista_anual, DateTime.Now.AddYears(1).Year);
Console.WriteLine($"Tratativa de contas anuais encerradas");


Console.WriteLine($"Finalizado");


void tratar_mensais(List<Conta> contas, List<ClickUp.Task> tasks, double lista_id, int mes_referencia)
{
    foreach (var conta in contas)
    {
        string titulo = $"{conta.titulo} - Ref. {DateTime.Now.AddMonths(1).ToString("yyyy/MM")}";
        Console.Write($"Analisando a necessidade de criar a task da conta '{conta.titulo}' ... ");

        var criado = tasks.Where(x => x.name == titulo && x.due_date.Value.Month == mes_referencia).FirstOrDefault();
        if(criado is not null){
            Console.WriteLine("Conta já criada anteriormente");
            continue;
        }

        Console.Write("Conta ainda não criada. Criando ... ");

        ClickUp.Task nova = new ClickUp.Task(){
            name = titulo,
            description = $"R$ {conta.valor}",
            assignees = ClickUp.Utils.Helper.CreateAssigneesByIds(new int[] {assignee}),
            //status = "Open",
            //oderindex = "New Task Name",
            date_created = DateTime.Now,
            date_updated = DateTime.Now,
            date_closed = null,
            date_done = null,
            start_date = null,
            due_date = DateTime.ParseExact($"{DateTime.Now.Year}/{mes_referencia}/{conta.vencimento}", "yyyy/M/d", null),
            priority = ClickUp.Utils.Helper.PriorityEnumToObject(conta.prioridade),
            custom_fields = new List<CustomFields>(){
                new CustomFields(){
                    id = Guid.Parse("fff3282b-05c5-4b9d-8e82-e8556d29f0b0"), //valor
                    value = conta.valor.ToString()
                }
            },
            tags = ClickUp.Utils.Helper.TagsListStringToObjects(new List<string>{{conta.pessoa}})
        };
        Console.Write("Objeto ok ... ");
        try
        {
            Console.Write("Enviando p/ ClickUp ... ");
            clickup_client.Tasks.CreateTask(lista_id, nova);
            Console.WriteLine("Ok!");
        }
        catch (System.Exception erro)
        {
            Console.WriteLine($"Não foi possivel criar o registro {conta.titulo} Erro: {erro.Message}");
        }
    }
}



void tratar_anuais(List<Conta> contas, List<ClickUp.Task> tasks, double lista_id, int ano_referencia)
{
    foreach (var conta in contas)
    {
        string titulo = $"{conta.titulo} - Ref. {DateTime.Now.AddYears(1).ToString("yyyy")}";
        Console.Write($"Analisando a necessidade de criar a task da conta '{conta.titulo}' ... ");

        var criado = tasks.Where(x => x.name == titulo && x.due_date.Value.Year == ano_referencia).FirstOrDefault();
        if(criado is not null){
            Console.WriteLine("Conta já criada anteriormente");
            continue;
        }

        Console.Write("Conta ainda não criada. Criando ... ");

        ClickUp.Task nova = new ClickUp.Task(){
            name = titulo,
            description = $"R$ {conta.valor}",
            assignees = ClickUp.Utils.Helper.CreateAssigneesByIds(new int[] {assignee}),
            //status = "Open",
            //oderindex = "New Task Name",
            date_created = DateTime.Now,
            date_updated = DateTime.Now,
            date_closed = null,
            date_done = null,
            start_date = null,
            due_date = DateTime.ParseExact($"{ano_referencia}/{conta.vencimento_mes}/{conta.vencimento}", "yyyy/M/d", null),
            priority = ClickUp.Utils.Helper.PriorityEnumToObject(conta.prioridade),
            custom_fields = new List<CustomFields>(){
                new CustomFields(){
                    id = Guid.Parse("fff3282b-05c5-4b9d-8e82-e8556d29f0b0"), //valor
                    value = conta.valor.ToString()
                }
            },
            tags = ClickUp.Utils.Helper.TagsListStringToObjects(new List<string>{{conta.pessoa}})
        };
        Console.Write("Objeto ok ... ");
        try
        {
            Console.Write("Enviando p/ ClickUp ... ");
            clickup_client.Tasks.CreateTask(lista_id, nova);
            Console.WriteLine("Ok!");
        }
        catch (System.Exception erro)
        {
            Console.WriteLine($"Não foi possivel criar o registro {conta.titulo} Erro: {erro.Message}");
        }
    }
}