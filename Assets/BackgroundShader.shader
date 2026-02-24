Shader "Custom/GLSLBackground"
{
    SubShader
    {
        Pass
        {
            Offset -1 , -1  
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
            uniform vec2 _ScreenParams; 

            

            //need a random function 
           vec2 random(vec2 p) 
            {
                return fract(sin(vec2(dot(p, vec2(127.1, 311.7)),dot(p, vec2(269.5, 183.3)) )) * 43758.5453);
            }
            void main()
            {
                vec2 st = gl_FragCoord.xy / _ScreenParams.xy; 

                st.x *= _ScreenParams.x / _ScreenParams.y; 

                vec3 color =vec3(0.545,0.071,0.071); 

                st *= 3.0; 

                vec2 i_st = floor(st); 
                vec2 f_st = fract(st); 

                float minDistance = 1.0; 

                for(int i  = -1; i <= 1; i++){
                    for(int j = -1; j <= 1; j++){

                        vec2 neighbor = vec2(float(i), float(j)); 
                    
                        vec2 point = random(i_st + neighbor);

                        point = 0.5 + 0.5 * sin(_Time.y + 6.28*point); 

                        vec2 difference = neighbor + point - f_st; 

                       float distance = length(difference); 

                        minDistance = min(minDistance, distance); 
                    }

                }

                color += minDistance; 

                color += 1.-step(.02, minDistance); 

                gl_FragColor = vec4(color, 1.0); 


            }

            #endif

            ENDGLSL
        }
    }

}

