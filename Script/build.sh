#!/bin/sh
# Builds project.
SCRIPT_DIR=$(cd $(dirname $0); pwd)
PROJECT_DIR=${SCRIPT_DIR}/../Src/Qamur.Chatwork
${SCRIPT_DIR}/clean.sh
dotnet build $PROJECT_DIR --configuration Release
