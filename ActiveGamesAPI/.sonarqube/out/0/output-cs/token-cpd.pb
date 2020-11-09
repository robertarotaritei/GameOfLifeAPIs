�
[D:\School\GameOfLifeAPIs\ActiveGamesAPI\ActiveGamesAPI\Controllers\ActiveGamesController.cs
	namespace 	
ActiveGamesAPI
 
. 
Controllers $
{ 
[ 

] 
[		 
Route		 

(		
 
$str		 
)		  
]		  !
public

 

class

 !
ActiveGamesController

 &
{ 
private 
readonly $
IGameProgressBroadcaster 1$
_gameProgressBroadcaster2 J
;J K
public !
ActiveGamesController $
($ %$
IGameProgressBroadcaster% =#
gameProgressBroadcaster> U
)U V
{ 	$
_gameProgressBroadcaster $
=% &#
gameProgressBroadcaster' >
;> ?
} 	
[ 	
HttpPost	 
] 
[ 	
Route	 
( 
$str 
) 
] 
public 
async 
Task 
< 

>' (

UpdateGame) 3
(3 4
	GameState4 =
	nextState> G
)G H
{ 	
var 
result 
= 
await $
_gameProgressBroadcaster 7
.7 8
UpdateGameAsync8 G
(G H
	nextStateH Q
)Q R
;R S
if 
( 
result 
is 
null 
) 
return 
new 
NotFoundResult )
() *
)* +
;+ ,
return 
new 
OkObjectResult %
(% &
result& ,
), -
;- .
} 	
[ 	
HttpPost	 
] 
public   
async   
Task   
<   

>  ' (
RunGame  ) 0
(  0 1
	GameState  1 :
initialState  ; G
)  G H
{!! 	
var"" 
result"" 
="" 
await"" $
_gameProgressBroadcaster"" 7
.""7 8
RunGameAsync""8 D
(""D E
initialState""E Q
)""Q R
;""R S
if$$ 
($$ 
result$$ 
is$$ 
null$$ 
)$$ 
return%% 
new%% 
NotFoundResult%% )
(%%) *
)%%* +
;%%+ ,
return'' 
new'' 
OkObjectResult'' %
(''% &
initialState''& 2
)''2 3
;''3 4
}(( 	
})) 
}** �
ND:\School\GameOfLifeAPIs\ActiveGamesAPI\ActiveGamesAPI\Hubs\GameProgressHub.cs
	namespace 	
ActiveGamesAPI
 
. 
Hubs 
{ 
public 

class 
GameProgressHub  
:  !
Hub" %
{ 
public		 
async		 
Task		 
UpdateGameAsync		 )
(		) *
	GameState		* 3
currentState		4 @
)		@ A
{

 	
currentState 
. 
RunnerConnectionId +
=, -
Context. 5
.5 6
ConnectionId6 B
;B C
await 
Clients 
. 
Clients !
(! "
currentState" .
.. /
ReactConnectionId/ @
)@ A
.A B
	SendAsyncB K
(K L
$strL \
,\ ]
currentState^ j
)j k
;k l
}
public 
async 
Task 
RunGameAsync &
(& '
	GameState' 0
initialState1 =
)= >
{ 	
await 
Clients 
. 
	AllExcept #
(# $
initialState$ 0
.0 1
ReactConnectionId1 B
)B C
.C D
	SendAsyncD M
(M N
$strN ]
,] ^
initialState_ k
)k l
;l m
} 	
public 
string 
GetConnectionId %
(% &
)& '
=>( *
Context+ 2
.2 3
ConnectionId3 ?
;? @
} 
} �
aD:\School\GameOfLifeAPIs\ActiveGamesAPI\ActiveGamesAPI\Infrastructure\IGameProgressBroadcaster.cs
	namespace 	
ActiveGamesAPI
 
. 
Infrastructure '
{ 
public 

	interface $
IGameProgressBroadcaster -
{ 
Task 
< 
	GameState
> 
UpdateGameAsync '
(' (
	GameState( 1
currentState2 >
)> ?
;? @
Task

 
<

 
	GameState


>

 
RunGameAsync

 $
(

$ %
	GameState

% .
intialState

/ :
)

: ;
;

; <
} 
} �
gD:\School\GameOfLifeAPIs\ActiveGamesAPI\ActiveGamesAPI\Infrastructure\SignalRGameProgressBroadcaster.cs
	namespace 	
ActiveGamesAPI
 
. 
Infrastructure '
{ 
public 

class *
SignalRGameProgressBroadcaster /
:0 1$
IGameProgressBroadcaster2 J
{		 
private

 
async

 
Task

 
<

 


 (
>

( )
OpenConnectionAsync

* =
(

= >
)

> ?
{ 	
var 

connection 
= 
new   
HubConnectionBuilder! 5
(5 6
)6 7
.7 8
WithUrl8 ?
(? @
$str@ `
)` a
.a b
Buildb g
(g h
)h i
;i j
await

connection
.

StartAsync
(
)
;
return 

connection 
; 
} 	
public 
async 
Task 
< 
	GameState #
># $
UpdateGameAsync% 4
(4 5
	GameState5 >
currentState? K
)K L
{ 	
await 
using 
var 

connection &
=' (
await) .
OpenConnectionAsync/ B
(B C
)C D
;D E
await 

connection 
. 
InvokeAsync (
(( )
nameof) /
(/ 0
GameProgressHub0 ?
.? @
UpdateGameAsync@ O
)O P
,P Q
currentStateR ^
)^ _
;_ `
return 
currentState 
;  
} 	
public 
async 
Task 
< 
	GameState #
># $
RunGameAsync% 1
(1 2
	GameState2 ;
initialState< H
)H I
{ 	
await 
using 
var 

connection &
=' (
await) .
OpenConnectionAsync/ B
(B C
)C D
;D E
await 

connection 
. 
InvokeAsync (
(( )
nameof) /
(/ 0
GameProgressHub0 ?
.? @
RunGameAsync@ L
)L M
,M N
initialStateO [
)[ \
;\ ]
return 
initialState 
;  
}   	
}!! 
}"" �
JD:\School\GameOfLifeAPIs\ActiveGamesAPI\ActiveGamesAPI\Models\GameState.cs
	namespace 	
ActiveGamesAPI
 
. 
Models 
{ 
public 

class 
	GameState 
{		 
public

 
bool

 
[

 
]

 
[

 
]

 

Generation

 "
{

# $
get

% (
;

( )
set

* -
;

- .
}

/ 0
public 
string 
ReactConnectionId '
{( )
get* -
;- .
set/ 2
;2 3
}4 5
public 
string 
RunnerConnectionId (
{) *
get+ .
;. /
set0 3
;3 4
}5 6
public 
	GameState 
( 
) 
{ 	
} 	
} 
} �

AD:\School\GameOfLifeAPIs\ActiveGamesAPI\ActiveGamesAPI\Program.cs
	namespace

 	
ActiveGamesAPI


 
{ 
public 

class 
Program 
{
public 
static 
void 
Main 
(  
string  &
[& '
]' (
args) -
)- .
{ 	
CreateHostBuilder 
( 
args "
)" #
.# $
Build$ )
() *
)* +
.+ ,
Run, /
(/ 0
)0 1
;1 2
} 	
public 
static 
IHostBuilder "
CreateHostBuilder# 4
(4 5
string5 ;
[; <
]< =
args> B
)B C
=>D F
Host 
.  
CreateDefaultBuilder %
(% &
args& *
)* +
. $
ConfigureWebHostDefaults )
() *

webBuilder* 4
=>5 7
{ 

webBuilder 
. 

UseStartup )
<) *
Startup* 1
>1 2
(2 3
)3 4
;4 5
} 
) 
; 
} 
} �
AD:\School\GameOfLifeAPIs\ActiveGamesAPI\ActiveGamesAPI\Startup.cs
	namespace 	
ActiveGamesAPI
 
{ 
public 

class 
Startup 
{ 
public 
Startup 
( 
IConfiguration %

)3 4
{ 	

= 

;) *
} 	
public 
IConfiguration 

{, -
get. 1
;1 2
}3 4
public 
void 
ConfigureServices %
(% &
IServiceCollection& 8
services9 A
)A B
{ 	
services 
. 

AddSignalR 
(  
)  !
;! "
services 
. 
AddControllers #
(# $
)$ %
;% &
services   
.   
AddTransient   !
<  ! "$
IGameProgressBroadcaster  " :
,  : ;*
SignalRGameProgressBroadcaster  < Z
>  Z [
(  [ \
)  \ ]
;  ] ^
}!! 	
public$$ 
void$$ 
	Configure$$ 
($$ 
IApplicationBuilder$$ 1
app$$2 5
,$$5 6
IWebHostEnvironment$$7 J
env$$K N
)$$N O
{%% 	
if&& 
(&& 
env&& 
.&& 

(&&! "
)&&" #
)&&# $
{'' 
app(( 
.(( %
UseDeveloperExceptionPage(( -
(((- .
)((. /
;((/ 0
})) 
app++ 
.++ 
UseHttpsRedirection++ #
(++# $
)++$ %
;++% &
app-- 
.-- 
UseCors-- 
(-- 
builder-- 
=>--  "
{.. 
builder// 
.00 
AllowAnyHeader00 #
(00# $
)00$ %
.11 
AllowAnyMethod11 #
(11# $
)11$ %
.22 
SetIsOriginAllowed22 '
(22' (
(22( )
host22) -
)22- .
=>22/ 1
true222 6
)226 7
.33 
AllowCredentials33 %
(33% &
)33& '
;33' (
}44 
)44
;44 
app66 
.66 

UseRouting66 
(66 
)66 
;66 
app88 
.88 
UseAuthorization88  
(88  !
)88! "
;88" #
app:: 
.:: 
UseEndpoints:: 
(:: 
	endpoints:: &
=>::' )
{;; 
	endpoints<< 
.<< 
MapControllers<< (
(<<( )
)<<) *
;<<* +
	endpoints== 
.== 
MapHub==  
<==  !
GameProgressHub==! 0
>==0 1
(==1 2
$str==2 =
)=== >
;==> ?
}>> 
)>>
;>> 
}?? 	
}@@ 
}AA 