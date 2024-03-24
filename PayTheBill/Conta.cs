namespace PayTheBill;

public class Conta
{
    public string titulo { get; set; }
    public decimal valor { get; set; }
    public int vencimento { get; set; }
    public int vencimento_mes { get; set; } //para contas anuais
    public string pessoa { get; set; }

    public ClickUp.Priority.Priority_Enum prioridade { get; set; }
    public string descricao { get; set; }
}

