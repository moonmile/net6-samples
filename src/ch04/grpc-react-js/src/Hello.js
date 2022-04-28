import React from 'react'
import { GreeterClient } from './protos/greet_grpc_web_pb'
import { HelloRequest}  from './protos/greet_pb'


class Hello extends React.Component {
    constructor(props) {
        super(props)
        this.state = {
            name: 'masuda',
            message: '',
        }
        this.onChangeName = this.onChangeName.bind(this)
        this.onClick = this.onClick.bind(this)

    }
    onChangeName(e) {
        this.setState({ name: e.target.value})
    }
    onClick() {
        console.log('call onClick')
        // gRPC を呼び出す
        const url = "https://localhost:7294"
        const client = new GreeterClient(url)
        const req = new HelloRequest() 
        req.setName( this.state.name )
        client.sayHello(req,(err,res) => {
            if ( res ) {
                const message = res.getMessage();
                this.setState({message: message})
            } else {
                const message = err?.message ?? "error"
                this.setState({message: message})
            }
        })

    }

    render() {
        return(
            <div className="container">
                <h2>Hello gRPC</h2>

                <input type="text" className="form-control" 
                    onChange={this.onChangeName} 
                    placeholder="ユーザー名" 
                    value={this.state.name} />
                <div>{ this.state.message }</div>
                <button type="button" 
                    className="btn btn-primary" onClick={this.onClick}>Hello</button>
            </div>
        )
    }
}


export default Hello;
