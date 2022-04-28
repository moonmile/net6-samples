// package: calc
// file: calc.proto

var calc_pb = require("./calc_pb");
var grpc = require("@improbable-eng/grpc-web").grpc;

var Calc = (function () {
  function Calc() {}
  Calc.serviceName = "calc.Calc";
  return Calc;
}());

Calc.Add = {
  methodName: "Add",
  service: Calc,
  requestStream: false,
  responseStream: false,
  requestType: calc_pb.CalcRequest,
  responseType: calc_pb.CalcResponse
};

exports.Calc = Calc;

function CalcClient(serviceHost, options) {
  this.serviceHost = serviceHost;
  this.options = options || {};
}

CalcClient.prototype.add = function add(requestMessage, metadata, callback) {
  if (arguments.length === 2) {
    callback = arguments[1];
  }
  var client = grpc.unary(Calc.Add, {
    request: requestMessage,
    host: this.serviceHost,
    metadata: metadata,
    transport: this.options.transport,
    debug: this.options.debug,
    onEnd: function (response) {
      if (callback) {
        if (response.status !== grpc.Code.OK) {
          var err = new Error(response.statusMessage);
          err.code = response.status;
          err.metadata = response.trailers;
          callback(err, null);
        } else {
          callback(null, response.message);
        }
      }
    }
  });
  return {
    cancel: function () {
      callback = null;
      client.close();
    }
  };
};

exports.CalcClient = CalcClient;

