// package: calc
// file: calc.proto

import * as calc_pb from "./calc_pb";
import {grpc} from "@improbable-eng/grpc-web";

type CalcAdd = {
  readonly methodName: string;
  readonly service: typeof Calc;
  readonly requestStream: false;
  readonly responseStream: false;
  readonly requestType: typeof calc_pb.CalcRequest;
  readonly responseType: typeof calc_pb.CalcResponse;
};

export class Calc {
  static readonly serviceName: string;
  static readonly Add: CalcAdd;
}

export type ServiceError = { message: string, code: number; metadata: grpc.Metadata }
export type Status = { details: string, code: number; metadata: grpc.Metadata }

interface UnaryResponse {
  cancel(): void;
}
interface ResponseStream<T> {
  cancel(): void;
  on(type: 'data', handler: (message: T) => void): ResponseStream<T>;
  on(type: 'end', handler: (status?: Status) => void): ResponseStream<T>;
  on(type: 'status', handler: (status: Status) => void): ResponseStream<T>;
}
interface RequestStream<T> {
  write(message: T): RequestStream<T>;
  end(): void;
  cancel(): void;
  on(type: 'end', handler: (status?: Status) => void): RequestStream<T>;
  on(type: 'status', handler: (status: Status) => void): RequestStream<T>;
}
interface BidirectionalStream<ReqT, ResT> {
  write(message: ReqT): BidirectionalStream<ReqT, ResT>;
  end(): void;
  cancel(): void;
  on(type: 'data', handler: (message: ResT) => void): BidirectionalStream<ReqT, ResT>;
  on(type: 'end', handler: (status?: Status) => void): BidirectionalStream<ReqT, ResT>;
  on(type: 'status', handler: (status: Status) => void): BidirectionalStream<ReqT, ResT>;
}

export class CalcClient {
  readonly serviceHost: string;

  constructor(serviceHost: string, options?: grpc.RpcOptions);
  add(
    requestMessage: calc_pb.CalcRequest,
    metadata: grpc.Metadata,
    callback: (error: ServiceError|null, responseMessage: calc_pb.CalcResponse|null) => void
  ): UnaryResponse;
  add(
    requestMessage: calc_pb.CalcRequest,
    callback: (error: ServiceError|null, responseMessage: calc_pb.CalcResponse|null) => void
  ): UnaryResponse;
}

