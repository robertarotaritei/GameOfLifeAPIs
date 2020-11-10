func @_GameHistoryAPI.AppDb.Dispose$$() -> () loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\AppDb.cs" :14 :8) {
^entry :
br ^0

^0: // SimpleBlock
%0 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\AppDb.cs" :16 :12) // Not a variable of known type: Connection
%1 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\AppDb.cs" :16 :12) // Connection.Dispose() (InvocationExpression)
// Entity from another assembly: GC
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\AppDb.cs" :17 :32) // this (ThisExpression)
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\AppDb.cs" :17 :12) // GC.SuppressFinalize(this) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
