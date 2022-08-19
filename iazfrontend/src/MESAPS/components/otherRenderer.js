import { GLTFModel, AmbientLight, DirectionLight } from 'react-3d-viewer';
import {OBJModel} from 'react-3d-viewer'
import {Card} from 'antd'

export default function Renderer() {
  return (
    // <div>
      // <GLTFModel src="Su-57.gltf">
        // <AmbientLight color={0xffffff} />
        // <DirectionLight color={0xffffff} position={{ x: 100, y: 200, z: 100 }} />
        // <DirectionLight color={0xff00ff} position={{ x: -100, y: 200, z: -100 }} />
      // </GLTFModel>
    // </div>
	<Card>
      <div>
        <OBJModel 
          width="1200" height="600" 
          position={{x:0,y:-100,z:0}} 
          src="Airplane_v1_L1.123c4a6fedec-1680-4a36-a228-b0d440a4f280\11803_Airplane_v1_l1.obj"
          onLoad={()=>{
            //...
          }}
          onProgress={xhr=>{
            //...
          }}
        />
      </div>
  	</Card>
  );
}
