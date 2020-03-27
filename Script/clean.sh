#!/bin/sh
# Cleans projects.
SCRIPT_DIR=$(cd $(dirname $0); pwd)
PROJECT_DIR=${SCRIPT_DIR}/../Src/Qamur.Chatwork
BIN_DIR=${PROJECT_DIR}/bin
OBJ_DIR=${PROJECT_DIR}/obj
rm -Rf $BIN_DIR $OBJ_DIR
