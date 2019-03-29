#!/bin/bash
while : ;do export GREP_COLOR='1;33';curl -s  http://10.196.1.10/ \
 |  grep --color=always "v1" ; export GREP_COLOR='1;36';\
 curl -s  http://10.196.1.10/ \
 | grep --color=always "v2" ; sleep 1; done