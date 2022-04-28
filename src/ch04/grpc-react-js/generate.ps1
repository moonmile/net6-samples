# Path to this plugin
$PROTOC_GEN_TS_PATH="./node_modules/.bin/protoc-gen-ts"
# Directory to write generated code to (.js and .d.ts files)
$OUT_DIR="./src/protos"
$PROTO_SRC="./proto"

protoc `
    --js_out="import_style=commonjs,binary:$OUT_DIR" `
    --grpc-web_out="import_style=commonjs,mode=grpcwebtext:$OUT_DIR" `
    -I ${PROTO_SRC} `
    greet.proto calc.proto



