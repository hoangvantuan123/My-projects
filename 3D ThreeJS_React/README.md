# Thiết lập dự án

## Tạo một dự án React
```script
   npx create-react-ap name-model
```


## Cài đặt [link]@react-three/fiber và [link]@react-three/drei
```script
  npm install three @react-three/fiber @react-three/drei
```
## Chuyển đổi mô hình của bạn thành một thành phần React để có thể tái sử dụng nó:
```script
 npx gltfjsx name.glb
```
################################

## Tạo Background

```script
import React, { Suspense } from 'react';
import { Canvas } from '@react-three/fiber';
import { OrbitControls } from '@react-three/drei';

export default function App() {
   return (
      <Canvas
         camera={{ position: [2, 0, 12.25], fov: 15 }}
         style={{
            backgroundColor: '#111a21',
            width: '100vw',
            height: '100vh',
         }}
      >
         <ambientLight intensity={1.25} />
         <ambientLight intensity={0.1} />
         <directionalLight intensity={0.4} />
         <Suspense fallback={null}>
            // your model here
         </Suspense>
         <OrbitControls />
      </Canvas>
   );
}
```

## Thêm mô hình của bạn vào thành

```script
mport React, { Suspense } from 'react';
import { Canvas } from '@react-three/fiber';
import { OrbitControls } from '@react-three/drei';
import Name from './Name'; /* highlight-line */

export default function App() {
   return (
      <Canvas
         camera={{ position: [2, 0, 12.25], fov: 15 }}
         style={{
            backgroundColor: '#111a21',
            width: '100vw',
            height: '100vh',
         }}
      >
         <ambientLight intensity={1.25} />
         <ambientLight intensity={0.1} />
         <directionalLight intensity={0.4} />
         <Suspense fallback={null}>
            <Name position={[0.025, -0.9, 0]} /> /* highlight-line */
         </Suspense>
         <OrbitControls />
      </Canvas>
   );
}
```


### Bài viết tham khảo :
- [link]https://dev.to/nourdinedev/how-to-use-threejs-and-react-to-render-a-3d-model-of-your-self-4kkf