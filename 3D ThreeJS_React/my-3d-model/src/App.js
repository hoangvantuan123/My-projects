import './App.css';
import React, { Suspense } from 'react';
import { Canvas } from '@react-three/fiber';
import { OrbitControls, Stars } from '@react-three/drei';

import Model from './Model2';
/* function Box(){
  return(
    <mesh>
      <boxBufferGeometry attach="geometry" />
      <meshLambertMaterial attach="material" color="#000000" />
    </mesh>

  )
} */

function App() {
  return (
      <Canvas camera={{ position: [2, 0, 12.25], fov: 18 }}
	  style={{
		 backgroundColor: '#111a21',
		 width: '100vw',
		 height: '100vh',
	  }}>
		  <ambientLight intensity={1.25} />
		  <Stars />
		  <OrbitControls></OrbitControls>
		  <Suspense fallback={null}>
            <Model position={[0.025, -0.9, 0]}/>
         </Suspense>
		  {/* <Box></Box> */}
	  </Canvas>
  );
}

export default App;
