import React, { Component } from 'react';
import { Radar, RadarChart, PolarGrid, 
  PolarAngleAxis, PolarRadiusAxis } from 'recharts';

    // Sample data
    const data = [
      { name: 'A', x: 21 },
      { name: 'B', x: 22 },
      { name: 'C', x: -32 },
      { name: 'D', x: -14 },
      { name: 'E', x: -51 },
      { name: 'F', x: 16 },
      { name: 'G', x: 7 },
      { name: 'H', x: -8 },
      { name: 'I', x: 9 },
  ];

export class Area_Chart_1_Module extends Component {
  
  render() {
    return (
      
        <RadarChart height={500} width={500} 
            outerRadius="80%" data={data}>
            <PolarGrid />
            <PolarAngleAxis dataKey="name" />
            <PolarRadiusAxis />
            <Radar dataKey="x" stroke="green" 
                fill="green" fillOpacity={0.5} />
        </RadarChart>
    
    );
  }
}
