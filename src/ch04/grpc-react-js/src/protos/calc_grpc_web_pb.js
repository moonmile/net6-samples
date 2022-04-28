/**
 * @fileoverview gRPC-Web generated client stub for calc
 * @enhanceable
 * @public
 */

// GENERATED CODE -- DO NOT EDIT!


/* eslint-disable */
// @ts-nocheck



const grpc = {};
grpc.web = require('grpc-web');

const proto = {};
proto.calc = require('./calc_pb.js');

/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?grpc.web.ClientOptions} options
 * @constructor
 * @struct
 * @final
 */
proto.calc.CalcClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options.format = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @param {string} hostname
 * @param {?Object} credentials
 * @param {?grpc.web.ClientOptions} options
 * @constructor
 * @struct
 * @final
 */
proto.calc.CalcPromiseClient =
    function(hostname, credentials, options) {
  if (!options) options = {};
  options.format = 'text';

  /**
   * @private @const {!grpc.web.GrpcWebClientBase} The client
   */
  this.client_ = new grpc.web.GrpcWebClientBase(options);

  /**
   * @private @const {string} The hostname
   */
  this.hostname_ = hostname;

};


/**
 * @const
 * @type {!grpc.web.MethodDescriptor<
 *   !proto.calc.CalcRequest,
 *   !proto.calc.CalcResponse>}
 */
const methodDescriptor_Calc_Add = new grpc.web.MethodDescriptor(
  '/calc.Calc/Add',
  grpc.web.MethodType.UNARY,
  proto.calc.CalcRequest,
  proto.calc.CalcResponse,
  /**
   * @param {!proto.calc.CalcRequest} request
   * @return {!Uint8Array}
   */
  function(request) {
    return request.serializeBinary();
  },
  proto.calc.CalcResponse.deserializeBinary
);


/**
 * @param {!proto.calc.CalcRequest} request The
 *     request proto
 * @param {?Object<string, string>} metadata User defined
 *     call metadata
 * @param {function(?grpc.web.RpcError, ?proto.calc.CalcResponse)}
 *     callback The callback function(error, response)
 * @return {!grpc.web.ClientReadableStream<!proto.calc.CalcResponse>|undefined}
 *     The XHR Node Readable Stream
 */
proto.calc.CalcClient.prototype.add =
    function(request, metadata, callback) {
  return this.client_.rpcCall(this.hostname_ +
      '/calc.Calc/Add',
      request,
      metadata || {},
      methodDescriptor_Calc_Add,
      callback);
};


/**
 * @param {!proto.calc.CalcRequest} request The
 *     request proto
 * @param {?Object<string, string>=} metadata User defined
 *     call metadata
 * @return {!Promise<!proto.calc.CalcResponse>}
 *     Promise that resolves to the response
 */
proto.calc.CalcPromiseClient.prototype.add =
    function(request, metadata) {
  return this.client_.unaryCall(this.hostname_ +
      '/calc.Calc/Add',
      request,
      metadata || {},
      methodDescriptor_Calc_Add);
};


module.exports = proto.calc;

