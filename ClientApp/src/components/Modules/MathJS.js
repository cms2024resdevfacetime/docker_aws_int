import React, { Component } from 'react';
import '../Modules/Module_Style/MathJS_Style.css';
import { create, all } from 'mathjs';


//Math JS Configuration
const config = { }
const math = create(all, config)

//Define 
let a = null;
let b = 100;



export class MathJS extends Component {

  constructor(props) {
    super(props);
    this.state = { currentCount: 0 };

  }

  MathJSFucntion() {
   
    // expressions
    const a = math.evaluate('12 / (2.3 + 0.7)')
    //console.log(a)

    return(
     <div><h1>{a}</h1></div> 
    )

    
  }

  render() {
    return (
    
    <div className='MathImplementation'>
    
    <h3>Current Count:<h1><this.MathJSFucntion/></h1></h3>
    </div>
    );
  }
}
