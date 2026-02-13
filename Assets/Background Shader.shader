Shader "Custom/GLSLBackground"
{
    SubShader
    {
        Pass
        {
            GLSLPROGRAM

            #ifdef VERTEX
            // vertex shader
            varying vec2 uv;

            void main()
            {
                
                gl_Position = gl_ModelViewProjectionMatrix * gl_Vertex;
                uv = gl_MultiTexCoord0.xy;
            }
            #endif

            #ifdef FRAGMENT
            // fragemnt shader 
            varying vec2 uv;
            uniform vec4 _Time;

            void main()
            {
                
                float t = _Time.y;
                vec3 color = vec3(cos(t) +0.5, 0.0,0.0);
            
                gl_FragColor = vec4(color, 1.0);
            }
            #endif

            ENDGLSL
        }
    }
}
