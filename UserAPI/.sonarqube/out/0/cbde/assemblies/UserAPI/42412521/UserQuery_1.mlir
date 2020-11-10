// Skipping function InsertAsync(none), it contains poisonous unsupported syntaxes

// Skipping function UpdateAsync(i32, none), it contains poisonous unsupported syntaxes

// Skipping function DeleteAsync(i32), it contains poisonous unsupported syntaxes

// Skipping function FindOneAsync(i32), it contains poisonous unsupported syntaxes

// Skipping function VerifyOneAsync(none, none), it contains poisonous unsupported syntaxes

// Skipping function VerifyUsernameAsync(none), it contains poisonous unsupported syntaxes

// Skipping function ReadAllAsync(none), it contains poisonous unsupported syntaxes

func @_UserAPI.Models.UserQuery.BindId$MySqlConnector.MySqlCommand.int$(none, i32) -> () loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :114 :8) {
^entry (%_cmd : none, %_id : i32):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :114 :28)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :114 :28)
%1 = cbde.alloca i32 loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :114 :46)
cbde.store %_id, %1 : memref<i32> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :114 :46)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :116 :12) // Not a variable of known type: cmd
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :116 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :116 :31) // new MySqlParameter              {                  ParameterName = "@id",                  DbType = DbType.Int32,                  Value = id,              } (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :118 :32) // "@id" (StringLiteralExpression)
// Entity from another assembly: DbType
%6 = constant unit loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :119 :25) // DbType.Int32 (SimpleMemberAccessExpression)
%7 = cbde.load %1 : memref<i32> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :120 :24)
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :116 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@id",                  DbType = DbType.Int32,                  Value = id,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_UserAPI.Models.UserQuery.BindParams$MySqlConnector.MySqlCommand.string.string$(none, none, none) -> () loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :124 :8) {
^entry (%_cmd : none, %_username : none, %_password : none):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :124 :32)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :124 :32)
%1 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :124 :50)
cbde.store %_username, %1 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :124 :50)
%2 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :124 :67)
cbde.store %_password, %2 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :124 :67)
br ^0

^0: // SimpleBlock
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :126 :12) // Not a variable of known type: cmd
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :126 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :126 :31) // new MySqlParameter              {                  ParameterName = "@username",                  DbType = DbType.String,                  Value = username,              } (ObjectCreationExpression)
%6 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :128 :32) // "@username" (StringLiteralExpression)
// Entity from another assembly: DbType
%7 = constant unit loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :129 :25) // DbType.String (SimpleMemberAccessExpression)
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :130 :24) // Not a variable of known type: username
%9 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :126 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@username",                  DbType = DbType.String,                  Value = username,              }) (InvocationExpression)
%10 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :132 :12) // Not a variable of known type: cmd
%11 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :132 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%12 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :132 :31) // new MySqlParameter              {                  ParameterName = "@password",                  DbType = DbType.String,                  Value = password,              } (ObjectCreationExpression)
%13 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :134 :32) // "@password" (StringLiteralExpression)
// Entity from another assembly: DbType
%14 = constant unit loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :135 :25) // DbType.String (SimpleMemberAccessExpression)
%15 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :136 :24) // Not a variable of known type: password
%16 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :132 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@password",                  DbType = DbType.String,                  Value = password,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_UserAPI.Models.UserQuery.BindUsername$MySqlConnector.MySqlCommand.string$(none, none) -> () loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :140 :8) {
^entry (%_cmd : none, %_username : none):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :140 :34)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :140 :34)
%1 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :140 :52)
cbde.store %_username, %1 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :140 :52)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :142 :12) // Not a variable of known type: cmd
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :142 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :142 :31) // new MySqlParameter              {                  ParameterName = "@username",                  DbType = DbType.String,                  Value = username,              } (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :144 :32) // "@username" (StringLiteralExpression)
// Entity from another assembly: DbType
%6 = constant unit loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :145 :25) // DbType.String (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :146 :24) // Not a variable of known type: username
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :142 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@username",                  DbType = DbType.String,                  Value = username,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
func @_UserAPI.Models.UserQuery.BindPassword$MySqlConnector.MySqlCommand.string$(none, none) -> () loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :150 :8) {
^entry (%_cmd : none, %_password : none):
%0 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :150 :34)
cbde.store %_cmd, %0 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :150 :34)
%1 = cbde.alloca none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :150 :52)
cbde.store %_password, %1 : memref<none> loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :150 :52)
br ^0

^0: // SimpleBlock
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :152 :12) // Not a variable of known type: cmd
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :152 :12) // cmd.Parameters (SimpleMemberAccessExpression)
%4 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :152 :31) // new MySqlParameter              {                  ParameterName = "@password",                  DbType = DbType.String,                  Value = password,              } (ObjectCreationExpression)
%5 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :154 :32) // "@password" (StringLiteralExpression)
// Entity from another assembly: DbType
%6 = constant unit loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :155 :25) // DbType.String (SimpleMemberAccessExpression)
%7 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :156 :24) // Not a variable of known type: password
%8 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Infrastructure\\UserQuery.cs" :152 :12) // cmd.Parameters.Add(new MySqlParameter              {                  ParameterName = "@password",                  DbType = DbType.String,                  Value = password,              }) (InvocationExpression)
br ^1

^1: // ExitBlock
return

}
