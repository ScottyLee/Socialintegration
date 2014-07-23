#!/bin/sh
exec erl \
    -pa ebin deps/*/ebin \
    -boot start_sasl \
    -sname test_srv_dev \
    -s test_srv \
    -s reloader
