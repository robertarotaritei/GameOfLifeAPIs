// Skipping function InsertAsync(none), it contains poisonous unsupported syntaxes

// Skipping function AllAsync(), it contains poisonous unsupported syntaxes

// Skipping function UpdateAsync(i32, none), it contains poisonous unsupported syntaxes

// Skipping function DeleteAsync(i32), it contains poisonous unsupported syntaxes

// Skipping function FindOneAsync(i32), it contains poisonous unsupported syntaxes

// Skipping function ReadAllAsync(none), it contains poisonous unsupported syntaxes

func @_GameHistoryAPI.Models.HistoryQuery.BindId$MySqlConnector.MySqlCommand.int$(none, i32) -> () loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :95 :8) {
^entry (%_cmd : none, %_id : i32):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :95 :28)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :95 :28)
%1 = cbde.alloca i32 loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :95 :46)
cbde.store %_id, %1 : memref<i32> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :95 :46)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :97 :12) // Not a variable of known type: cmd
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :97 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :97 :31) // new MySqlParameter              {                  ParameterName = "@id",                  DbType = DbType.Int32,                  Value = id,              } (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :99 :32) // "@id" (StringLiteralExpression)
// Entity from another assembly: DbType
%6 = constant unit loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :100 :25) // DbType.Int32 (SimpleMemberAccessExpression)
%7 = cbde.load %1 : memref<i32> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :101 :24)
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :97 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@id",                  DbType = DbType.Int32,                  Value = id,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_GameHistoryAPI.Models.HistoryQuery.BindParams$MySqlConnector.MySqlCommand.string.string$(none, none, none) -> () loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :105 :8) {
^entry (%_cmd : none, %_author : none, %_initialState : none):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :105 :32)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :105 :32)
%1 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :105 :50)
cbde.store %_author, %1 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :105 :50)
%2 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :105 :65)
cbde.store %_initialState, %2 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :105 :65)
br ^0

^0: // SimpleBlock
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :107 :12) // Not a variable of known type: cmd
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :107 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :107 :31) // new MySqlParameter              {                  ParameterName = "@author",                  DbType = DbType.String,                  Value = author,              } (ObjectCreationExpression)
%6 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :109 :32) // "@author" (StringLiteralExpression)
// Entity from another assembly: DbType
%7 = constant unit loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :110 :25) // DbType.String (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :111 :24) // Not a variable of known type: author
%9 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :107 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@author",                  DbType = DbType.String,                  Value = author,              }) (InvocationExpression)
%10 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :113 :12) // Not a variable of known type: cmd
%11 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :113 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%12 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :113 :31) // new MySqlParameter              {                  ParameterName = "@initialState",                  DbType = DbType.String,                  Value = initialState,              } (ObjectCreationExpression)
%13 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :115 :32) // "@initialState" (StringLiteralExpression)
// Entity from another assembly: DbType
%14 = constant unit loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :116 :25) // DbType.String (SimpleMemberAccessExpression)
%15 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :117 :24) // Not a variable of known type: initialState
%16 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :113 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@initialState",                  DbType = DbType.String,                  Value = initialState,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_GameHistoryAPI.Models.HistoryQuery.BindParams$MySqlConnector.MySqlCommand.string$(none, none) -> () loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :121 :8) {
^entry (%_cmd : none, %_initialState : none):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :121 :32)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :121 :32)
%1 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :121 :50)
cbde.store %_initialState, %1 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :121 :50)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :123 :12) // Not a variable of known type: cmd
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :123 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :123 :31) // new MySqlParameter              {                  ParameterName = "@initialState",                  DbType = DbType.String,                  Value = initialState,              } (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :125 :32) // "@initialState" (StringLiteralExpression)
// Entity from another assembly: DbType
%6 = constant unit loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :126 :25) // DbType.String (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :127 :24) // Not a variable of known type: initialState
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\GameHistoryAPI\\GameHistoryAPI\\Infrastructure\\HistoryQuery.cs" :123 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@initialState",                  DbType = DbType.String,                  Value = initialState,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
