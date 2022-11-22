import './App.css';
import React, { Suspense } from 'react';
import { Canvas } from '@react-three/fiber';
import { OrbitControls, Stars } from '@react-three/drei';

import Model from './Model2';

// Import the functions you need from the SDKs you need
import { initializeApp } from "firebase/app";
import { getAnalytics } from "firebase/analytics";
// TODO: Add SDKs for Firebase products that you want to use
// https://firebase.google.com/docs/web/setup#available-libraries

// Your web app's Firebase configuration
// For Firebase JS SDK v7.20.0 and later, measurementId is optional
const firebaseConfig = {
  apiKey: "AIzaSyC6hXrK6BdApcQUP0uK7gnaSamixphPdRc",
  authDomain: "d-threejs.firebaseapp.com",
  projectId: "d-threejs",
  storageBucket: "d-threejs.appspot.com",
  messagingSenderId: "703912497887",
  appId: "1:703912497887:web:58ddec9467f3eaef1b8f6a",
  measurementId: "G-P8ZEL6158V"
};

// Initialize Firebase
const app = initializeApp(firebaseConfig);
const analytics = getAnalytics(app);

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
