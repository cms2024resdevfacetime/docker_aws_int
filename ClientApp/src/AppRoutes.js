import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Comps } from "./components/Comps";
import { Area_Chart_Page_Component } from "./components/Area_Chart_1_Page";
import { SpacialChart } from "./components/SpacialChart";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  },
  
  {
    path: '/Comps',
    element: <Comps />
  },

  {
    path: '/Area_Chart_1_Page',
    element: <Area_Chart_Page_Component />
  },
  {
    path: '/SpacialChart',
    element: <SpacialChart />
  }
];

export default AppRoutes;
