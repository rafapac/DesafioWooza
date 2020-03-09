
# DesafioWooza

API de cadastro, atualização, remoção e listagem de planos de telefonia.

1. Tecnologias/Framework utilizados:
  * Microsoft Visual Studio Community 2019
  * .NET Core 3.1
  * Entity Framework Core
  * NUnit
 

2. Endpoints disponíveis:

* "/api/cadastrar":
  * Método: POST
  * Tipo de parâmetro: JSON (enviado no request body)
  * Parâmetro:
    {"Codigo": [string|obrigatório],
    "Tipo": {"Tipo": [string|obrigatório]},
    "Operadora": [string|obrigatório],
    "Valor": [string|obrigatório],
    "Minutos": [int],
    "FranquiaInternet": [int],
    "DDDs": [{ "DDD": [string|obrigatório]} | Não obrigatório]}
  * Retorno: HttpStatus(Created), HttpStatus(BadRequest)
    
 * "/api/atualizar":
     - Método: POST
     - Tipo de parâmetro: JSON (enviado no request body)
     - Parâmetro:
	      {"Codigo": [string|obrigatório],
	      "Tipo": {"Tipo": [string|obrigatório]},
	      "Operadora": [string|obrigatório],
	      "Valor": [string|obrigatório],
	      "Minutos": [int],
	      "FranquiaInternet": [int],
	      "DDDs": [{ "DDD": [string|obrigatório]} | Não obrigatório]}
     - Retorno: HttpStatus(Ok), HttpStatus(BadRequest)
    
 * "/api/remover":
   * Método: POST
   * Tipo de parâmetro: JSON (enviado no request body)
   * Parâmetro:{
	      {"Codigo": [string|obrigatório],
	      "Tipo": {"Tipo": [string|obrigatório]},
	      "Operadora": [string|obrigatório],
	      "Valor": [string|obrigatório],
	      "Minutos": [int],
	      "FranquiaInternet": [int],
	      "DDDs": [{ "DDD": [string|obrigatório]} | Não obrigatório]}
   * Retorno: HttpStatus(Ok), HttpStatus(BadRequest)
    
* "/api/listarportipo":
   * Método: GET
   * Tipo de parâmetro: JSON (enviado no request body)
   * Parâmetro:{
                  "Tipo": [string], -- Obrigatório
                  "DDD": [string] -- Não Obrigatório
                }
   * Retorno: Lista de planos de telefonia
      
* "/api/listarporoperadora":
   * Método: GET
   * Tipo de parâmetro: JSON (enviado no request body)
   * Parâmetro:{
                  "Operadora": [string], -- Obrigatório
                  "DDD": [string] -- Não Obrigatório
                }
   * Retorno: Lista de planos de telefonia
      
* "/api/getporcodigo":
   * Método: GET
   * Tipo de parâmetro: JSON (enviado no request body)
   * Parâmetro:{
                    "Codigo": [string] -- Obrigatório
                  }
   * Retorno: Plano de código informado
        
