#!/bin/bash

while true;
do
	read line

	if [[ "$line" == "QUIT" ]];
	then
		echo "Finish!"
		echo "QUIT" > pipe
		exit 0
	fi

	if [[ "$line" != "+" && "$line" != "*" && !("$line" =~ ^(-?[0-9]+)$) ]];
	then
		echo "Error command: generator"
		echo "QUIT" > pipe
		exit 1
	fi
	echo "$line" > pipe
done

