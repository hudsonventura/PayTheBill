# PayTheClickup

Projeto pessoal para realização de um check list das contas a pagar e receber, criadas como tarefas no ClickUp.  
Motivação: manter as contas organizadas e realizar o pagamento em dia, resultando em um não pagamento de juros ou corte de serviços.  

Criar o arquivo `appsettings.json` na raiz do projeto:
``` json
{
    "ClickUp":{
        "token":"pk_SEUTOKENDOCLICKUP", //token do clickup
        "team": "45765756756",          //ID do time
        "assignee":67895664564,         //seu ID
        "lists":{
            "anual": 435345345,         //lista das suas contas anuais
            "mensal": 76567567567       //lista das suas contas mensais
        }
    },
    "Contas":{
        "APagar":[
            {
                "titulo": "Água",   
                "valor": 85.00,     //valor  a ser pago mensalmente
                "vencimento" : 6,   //dia do vencimento
                "prioridade": 2,    //1 Urgente, 2 Alta, 3 Normal e 4 Baixa
                "pessoa": "Casa",   //informar quem ou o que  é responsável pelos custos
                "descricao":"Conta de água pela empresa Águas e Prefeitura LTDA"
            },
            {
                "titulo": "Energia",
                "valor": 450.00,
                "vencimento" : 8,
                "prioridade": 2,
                "pessoa": "Casa",
                "descricao":"Conta de energia pela empresa Energias Brasil Ficticus S/A"
            }
        ],
        "AReceber":[
            
        ]
    }
}
```

Iniciar:
``` bash
sudo docker compose up
```

O crono (ver docker-compose.yml) se encarrega de rodar a aplicação 1 vez ao dia.  
A aplicação faz uma comparação se todas as contas foram criadas no Clickup. Se algo estiver faltando, ele tenta criar.