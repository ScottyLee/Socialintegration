%% @author Mochi Media <dev@mochimedia.com>
%% @copyright 2010 Mochi Media <dev@mochimedia.com>

%% @doc test_srv.

-module(test_srv).
-author("Mochi Media <dev@mochimedia.com>").
-export([start/0, stop/0]).

ensure_started(App) ->
    case application:start(App) of
        ok ->
            ok;
        {error, {already_started, App}} ->
            ok
    end.


%% @spec start() -> ok
%% @doc Start the test_srv server.
start() ->
    test_srv_deps:ensure(),
    ensure_started(crypto),
    application:start(test_srv).


%% @spec stop() -> ok
%% @doc Stop the test_srv server.
stop() ->
    application:stop(test_srv).
