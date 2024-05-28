#!/usr/bin/env bash
set -e

SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )
GENERATOR_DIR="${SCRIPT_DIR}/WowMessages.Generator"

jtd-validate ${GENERATOR_DIR}/wow_messages/intermediate_representation_schema.json ${GENERATOR_DIR}/wow_messages/intermediate_representation.json
jtd-codegen --csharp-system-text-out ${GENERATOR_DIR}/src/generated --csharp-system-text-namespace 'WowMessages.Generator.Generated' ${GENERATOR_DIR}/wow_messages/intermediate_representation_schema.json

# Member function can not have same name as object
sed -i 's/public string Value { get; set; }/public string value { get; set; }/' ${GENERATOR_DIR}/src/generated/Value.cs

for i in $(ls ${GENERATOR_DIR}/src/generated/*.cs); do
    sed -i 's/{ get; set; }/{ get; init; }/g' $i
done

dotnet run --project ${GENERATOR_DIR}

