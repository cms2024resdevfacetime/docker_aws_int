import React, { Component } from 'react';
import { motion } from "framer-motion";
import { Area_Chart_1_Module } from './Modules/Area_Chart_1';


export class Area_Chart_Page_Component extends Component {

  render() {
    return (
      <div>
        <h1>Area_Chart_Page_Component Page !!!</h1>
      
        <h2>Implementation of Area Chart Module</h2>
        <Area_Chart_1_Module/>
       
      </div>
    );
  }
}
