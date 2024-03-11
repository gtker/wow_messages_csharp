#/usr/bin/env bash
set -e

SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )

jtd-validate ${SCRIPT_DIR}/wow_messages/intermediate_representation_schema.json ${SCRIPT_DIR}/wow_messages/intermediate_representation.json
jtd-codegen --csharp-system-text-out ${SCRIPT_DIR}/src/generated --csharp-system-text-namespace 'Gtker.WowMessages.Generator.Generated' ${SCRIPT_DIR}/wow_messages/intermediate_representation_schema.json

# Member function can not have same name as object
sed -i 's/public string Value { get; set; }/public string value { get; set; }/' ${SCRIPT_DIR}/src/generated/Value.cs

for i in $(ls ${SCRIPT_DIR}/src/generated/*.cs); do
    sed -i 's/{ get; set; }/{ get; init; }/g' $i
done

dotnet run

