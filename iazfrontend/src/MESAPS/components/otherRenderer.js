import { GLTFModel, AmbientLight, DirectionLight } from 'react-3d-viewer';

export default function Renderer() {
  return (
    <div>
      <GLTFModel src="Su-57.gltf">
        <AmbientLight color={0xffffff} />
        <DirectionLight color={0xffffff} position={{ x: 100, y: 200, z: 100 }} />
        <DirectionLight color={0xff00ff} position={{ x: -100, y: 200, z: -100 }} />
      </GLTFModel>
    </div>
  );
}
