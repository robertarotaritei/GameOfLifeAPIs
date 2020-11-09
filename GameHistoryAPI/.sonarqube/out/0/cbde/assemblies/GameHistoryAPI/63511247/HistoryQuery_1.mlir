// Skipping function InsertAsync(none), it contains poisonous unsupported syntaxes

// Skipping function AllAsync(), it contains poisonous unsupported syntaxes

// Skipping function UpdateAsync(i32, none), it contains poisonous unsupported syntaxes

// Skipping function DeleteAsync(i32), it contains poisonous unsupported syntaxes

// Skipping function FindOneAsync(i32), it contains poisonous unsupported syntaxes

// Skipping function ReadAllAsync(none), it contains poisonous unsupported syntaxes

func @_GameHistoryAPI.Models.HistoryQuery.BindId$MySqlConnector.MySqlCommand.int$(none, i32) -> () loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :96 :8) {
^entry (%_cmd : none, %_id : i32):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :96 :28)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :96 :28)
%1 = cbde.alloca i32 loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :96 :46)
cbde.store %_id, %1 : memref<i32> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :96 :46)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :98 :12) // Not a variable of known type: cmd
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :98 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :98 :31) // new MySqlParameter              {                  ParameterName = "@id",                  DbType = DbType.Int32,                  Value = id,              } (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :100 :32) // "@id" (StringLiteralExpression)
// Entity from another assembly: DbType
%6 = constant unit loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :101 :25) // DbType.Int32 (SimpleMemberAccessExpression)
%7 = cbde.load %1 : memref<i32> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :102 :24)
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :98 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@id",                  DbType = DbType.Int32,                  Value = id,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_GameHistoryAPI.Models.HistoryQuery.BindParams$MySqlConnector.MySqlCommand.string.string$(none, none, none) -> () loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :106 :8) {
^entry (%_cmd : none, %_author : none, %_initialState : none):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :106 :32)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :106 :32)
%1 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :106 :50)
cbde.store %_author, %1 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :106 :50)
%2 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :106 :65)
cbde.store %_initialState, %2 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :106 :65)
br ^0

^0: // SimpleBlock
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :108 :12) // Not a variable of known type: cmd
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :108 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :108 :31) // new MySqlParameter              {                  ParameterName = "@author",                  DbType = DbType.String,                  Value = author,              } (ObjectCreationExpression)
%6 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :110 :32) // "@author" (StringLiteralExpression)
// Entity from another assembly: DbType
%7 = constant unit loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :111 :25) // DbType.String (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :112 :24) // Not a variable of known type: author
%9 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :108 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@author",                  DbType = DbType.String,                  Value = author,              }) (InvocationExpression)
%10 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :114 :12) // Not a variable of known type: cmd
%11 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :114 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%12 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :114 :31) // new MySqlParameter              {                  ParameterName = "@initialState",                  DbType = DbType.String,                  Value = initialState,              } (ObjectCreationExpression)
%13 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :116 :32) // "@initialState" (StringLiteralExpression)
// Entity from another assembly: DbType
%14 = constant unit loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :117 :25) // DbType.String (SimpleMemberAccessExpression)
%15 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :118 :24) // Not a variable of known type: initialState
%16 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :114 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@initialState",                  DbType = DbType.String,                  Value = initialState,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_GameHistoryAPI.Models.HistoryQuery.BindParams$MySqlConnector.MySqlCommand.string$(none, none) -> () loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :122 :8) {
^entry (%_cmd : none, %_initialState : none):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :122 :32)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :122 :32)
%1 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :122 :50)
cbde.store %_initialState, %1 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :122 :50)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :124 :12) // Not a variable of known type: cmd
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :124 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :124 :31) // new MySqlParameter              {                  ParameterName = "@initialState",                  DbType = DbType.String,                  Value = initialState,              } (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :126 :32) // "@initialState" (StringLiteralExpression)
// Entity from another assembly: DbType
%6 = constant unit loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :127 :25) // DbType.String (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :128 :24) // Not a variable of known type: initialState
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :124 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@initialState",                  DbType = DbType.String,                  Value = initialState,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
