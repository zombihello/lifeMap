#version 130

//--------------------------------------------

in vec3 Position;

//--------------------------------------------

uniform mat4 PVTMatrix;

//--------------------------------------------

void main()
{
	gl_Position = PVTMatrix * vec4( Position, 1.0f );
}

//--------------------------------------------