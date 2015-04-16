# dotnet-api-example

Esse projeto é um exemplo de como usar a biblioteca ClickSign.Net para realizar consultas e alterações na ClickSign API.

TechStack:
- .Net Platform 4.0
- AspNet MVC
SignalR 
    

###Como importar as DLL da API para seu projeto.

- Baixe o arquivo [ClickSign.zip](https://github.com/clicksign/dotnet-api-example/raw/master/dotnet-example/dependencies/ClickSign.zip) , extraia seu conteúdo. 
- Importe as 3 DLL`s para seu projeto. (nesse projeto de exemplo, as 3 DLLs se encontram em dotnet-example/dependencies)


###Como utilizar o API client.

- Dentro do seu App.config (no nosso caso Web.config, pois nosso exemplo se trata de um app Web), coloque as seguintes appSettings:

```xml
    <add key="Clicksign-Host" value="https://api.clicksign-stage.com"  /> <!-- ou qualquer outro ambiente que esteja usando (nesse caso, estamos usando o stage para testar). -->
    <add key="ClickSign-Token" value="InsiraAquiSeuToken" /> <!-- Token gerado pela ClickSign para cada conta -->
```

- Instancie um objeto do tipo ClickSign

```C#
  var clicksign = new Clicksign.Clicksign();
```

- Utilize normalmente os métodos disponiveis. Por exemplo, para listar os documentos de sua conta use:

```C#
  var documentList = clicksign.List();
```

Mais exemplos de uso estão na classe [SimpleHub.cs](https://github.com/clicksign/dotnet-api-example/blob/master/dotnet-example/Hubs/SimpleHub.cs) ,e a documentação oficial está ná [Página do projeto no github](https://github.com/clicksign/clicksign-dotnet)


  
