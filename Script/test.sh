#!/bin/sh
# Runs tests
SCRIPT_DIR=$(cd $(dirname $0); pwd)
TEST_PROJECT_DIR=${SCRIPT_DIR}/../Src/Qamur.Chatwork.Client.Test
BIN_DIR = ${TEST_PROJECT_DIR}/bin
OBJ_DIR = ${TEST_PROJECT_DIR}/obj
${SCRIPT_DIR}/clean.sh
rm -Rf $BIN_DIR $OBJ_DIR
dotnet test $TEST_PROJECT_DIR
