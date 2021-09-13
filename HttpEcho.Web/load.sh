#!/bin/bash
while : 
do
    curl -s  $SERVICE_URL | GREP_COLOR='01;34' egrep --color=always 'v1' | GREP_COLOR='01;32' egrep -i --color=always 'v2' 
    sleep 1 
done

