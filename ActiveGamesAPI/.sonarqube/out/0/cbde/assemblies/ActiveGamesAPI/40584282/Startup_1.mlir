func @_ActiveGamesAPI.Startup.ConfigureServices$Microsoft.Extensions.DependencyInjection.IServiceCollection$(none) -> () loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :27 :8) {
^entry (%_services : none):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :27 :38)
cbde.store %_services, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :27 :38)
br ^0

^0: // SimpleBlock
%1 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :29 :12) // Not a variable of known type: services
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :29 :12) // services.AddSignalR() (InvocationExpression)
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :30 :12) // Not a variable of known type: services
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :30 :12) // services.AddControllers() (InvocationExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :31 :12) // Not a variable of known type: services
%6 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\ActiveGamesAPI\\ActiveGamesAPI\\Startup.cs" :31 :12) // services.AddTransient<IGameProgressBroadcaster, SignalRGameProgressBroadcaster>() (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
// Skipping function Configure(none, none), it contains poisonous unsupported syntaxes

