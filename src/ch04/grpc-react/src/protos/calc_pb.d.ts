// package: calc
// file: calc.proto

import * as jspb from "google-protobuf";

export class CalcRequest extends jspb.Message {
  getX(): number;
  setX(value: number): void;

  getY(): number;
  setY(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): CalcRequest.AsObject;
  static toObject(includeInstance: boolean, msg: CalcRequest): CalcRequest.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: CalcRequest, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): CalcRequest;
  static deserializeBinaryFromReader(message: CalcRequest, reader: jspb.BinaryReader): CalcRequest;
}

export namespace CalcRequest {
  export type AsObject = {
    x: number,
    y: number,
  }
}

export class CalcResponse extends jspb.Message {
  getAns(): number;
  setAns(value: number): void;

  serializeBinary(): Uint8Array;
  toObject(includeInstance?: boolean): CalcResponse.AsObject;
  static toObject(includeInstance: boolean, msg: CalcResponse): CalcResponse.AsObject;
  static extensions: {[key: number]: jspb.ExtensionFieldInfo<jspb.Message>};
  static extensionsBinary: {[key: number]: jspb.ExtensionFieldBinaryInfo<jspb.Message>};
  static serializeBinaryToWriter(message: CalcResponse, writer: jspb.BinaryWriter): void;
  static deserializeBinary(bytes: Uint8Array): CalcResponse;
  static deserializeBinaryFromReader(message: CalcResponse, reader: jspb.BinaryReader): CalcResponse;
}

export namespace CalcResponse {
  export type AsObject = {
    ans: number,
  }
}

