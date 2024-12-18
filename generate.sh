#!/usr/bin/env bash
set -e

SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )
GENERATOR_DIR="${SCRIPT_DIR}/Generator"

rm -r "${GENERATOR_DIR}/src/generated"
mkdir -p "${GENERATOR_DIR}/src/generated"

jtd-validate ${GENERATOR_DIR}/wow_messages/intermediate_representation_schema.json ${GENERATOR_DIR}/wow_messages/intermediate_representation.json
jtd-codegen --csharp-system-text-out ${GENERATOR_DIR}/src/generated --csharp-system-text-namespace 'Generator.Generated' ${GENERATOR_DIR}/wow_messages/intermediate_representation_schema.json

# Member function can not have same name as object
sed -i 's/public string Value { get; set; }/public string value { get; set; }/' ${GENERATOR_DIR}/src/generated/Value.cs
sed -i 's/public IDictionary<string, IList<PreparedObject>>/public IDictionary<string, IList<PreparedObject>>?/' ${GENERATOR_DIR}/src/generated/PreparedObject.cs

dotnet run --project ${GENERATOR_DIR}

