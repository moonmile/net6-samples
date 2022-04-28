import React from 'react'
import { CalcClient } from './protos/calc_pb_service'
import { CalcRequest }  from './protos/calc_pb'
import { reduceEachTrailingCommentRange } from 'typescript'
import internal from 'stream'

interface IState {
    x: number;
    y: number;
    ans: number ;
}

class Calc extends React.Component<{}, IState> {
    constructor(props: {}) {
        super(props)
        this.state = {
            x: 10,
            y: 20,
            ans: 0,
        }
        this.onChangeX = this.onChangeX.bind(this)
        this.onChangeY = this.onChangeY.bind(this)
        this.onCalcClick = this.onCalcClick.bind(this)
    }
    onChangeX(e: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ x: Number( e.target.value )})
    }
    onChangeY(e: React.ChangeEvent<HTMLInputElement>) {
        this.setState({ y: Number( e.target.value )})
    }
    onCalcClick() {
        console.log('call onCalcClick')
        // gRPC を呼び出す
        const url = "https://localhost:7294"
        const client = new CalcClient(url)
        const req = new CalcRequest() 
        req.setX( this.state.x );
        req.setY( this.state.y );
        client.add(req,(err,res) => {
            if ( res ) {
                const ans = res.getAns();
                this.setState({ans: ans})
            } else {
                const message = err?.message ?? "error"
                console.log( message )
            }
        })
    }

    render(): React.ReactNode {
        return(
            <div className="container">
                <h2>Calc by gRPC</h2>

                <input type="text" className="form-control" 
                    onChange={this.onChangeX} 
                    placeholder="X" 
                    value={this.state.x} />
                <input type="text" className="form-control" 
                    onChange={this.onChangeY} 
                    placeholder="Y" 
                    value={this.state.y} />
                <div>answer is { this.state.ans }</div>
                <button type="button" 
                    className="btn btn-primary" onClick={this.onCalcClick}>Calc</button>
            </div>
        )
    }
}


export default Calc;
