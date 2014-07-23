%% @author Mochi Media <dev@mochimedia.com>
%% @copyright test_srv Mochi Media <dev@mochimedia.com>

%% @doc Callbacks for the test_srv application.

-module(test_srv_app).
-author("Mochi Media <dev@mochimedia.com>").

-behaviour(application).
-export([start/2,stop/1]).


%% @spec start(_Type, _StartArgs) -> ServerRet
%% @doc application start callback for test_srv.
start(_Type, _StartArgs) ->
    test_srv_deps:ensure(),
    test_srv_sup:start_link().

%% @spec stop(_State) -> ServerRet
%% @doc application stop callback for test_srv.
stop(_State) ->
    ok.
