import React, { Component } from 'react';
import { Chart } from './Modules/Chart';
import { MathJS } from './Modules/MathJS';


import { motion } from "framer-motion";

export class Comps extends Component {
  

  render() {
    return (
      <div>
        <h1>Chart</h1>
        <Chart/>
        <h1>Moving Chart</h1>
        <p>https://www.framer.com/motion/examples/</p>
        <motion.div animate={{ x: 500 }} ><Chart/></motion.div>
        <h1>MathJS</h1>
        <MathJS/>
       
       

       
      </div>
    );
  }
}
