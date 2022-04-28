import React, { Component } from 'react';
import GreeterClient from '../protos/greet_pb_service'
import HelloRequest from '../protos/greet_pb'

export class Hello extends Component {
  static displayName = Hello.name;

  constructor(props) {
    super(props);
    this.state = { name: 'masuda', message: '' };
    this.clickHello = this.clickHello.bind(this);
    this.onChangeName = this.onChangeName.bind(this);
  }

  onChangeName(e) {
    this.setState({ name: e.target.value})
  }
  
  clickHello() {
    console.log( "call clickHello")

    const url = "https://localhost:7294"
    const client = new GreeterClient(url);

    /*
    const req = new HelloRequest()
    req.setName( this.state.name )
    client.sayHello( req, (err, res) => {
      if ( res ) {
        const message = res.getMessage()
        this.setState({ message: message})
      } else {
        console.log( "error: " + err )
      }
    })
    */
  }

  render() {
    return (
      <div>
        <h1>Hello</h1>
        <input type="text" className="form-control" onChange={this.onChangeName} placeholder="ユーザー名" value={this.state.name} />
        <div>{ this.state.message }</div>
        <button className="btn btn-primary" onClick={this.clickHello}>Hello</button>
      </div>
    );
  }
}
