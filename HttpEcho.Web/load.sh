#!/bin/bash
while : 
do
    curl -s  http://10.196.1.11/ | GREP_COLOR='01;36' egrep --color=always 'v1' | GREP_COLOR='01;31' egrep -i --color=always 'v2' 
    sleep 1 
done

