// Skipping function GetOne(i32), it contains poisonous unsupported syntaxes

// Skipping function VerifyOne(none, none), it contains poisonous unsupported syntaxes

func @_UserAPI.Controllers.UserController.Test$$() -> none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Controllers\\UserController.cs" :43 :8) {
^entry :
br ^0

^0: // JumpBlock
%0 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Controllers\\UserController.cs" :47 :26) // "test" (StringLiteralExpression)
%2 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Controllers\\UserController.cs" :49 :38) // Not a variable of known type: test
%3 = cbde.unknown : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Controllers\\UserController.cs" :49 :19) // new OkObjectResult(test) (ObjectCreationExpression)
return %3 : none loc("D:\\School\\GameOfLifeAPIs\\UserAPI\\UserAPI\\Controllers\\UserController.cs" :49 :12)

^1: // ExitBlock
cbde.unreachable

}
// Skipping function VerifyUsername(none), it contains poisonous unsupported syntaxes

// Skipping function Post(none), it contains poisonous unsupported syntaxes

// Skipping function PutOne(i32, none), it contains poisonous unsupported syntaxes

// Skipping function DeleteOne(i32), it contains poisonous unsupported syntaxes

