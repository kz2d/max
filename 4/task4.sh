#!/bin/bash

sh loop.sh&pid0=$!
sh loop.sh&pid1=$!
sh loop.sh&pid2=$!

echo "$pid1 $pid2 $pid3"

curnice=10
while true
do
    cpu=$(ps -p "$pid1" -o %cpu | tail -1 | awk '{printf "%.0f", $0}')
    if [ "$cpu" -ge 10 ]
    then
        curnice=$((curnice + 1))
        renice "+$curnice" -p "$pid1"
    fi
done &