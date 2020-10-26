Shader "Tutorial/Outline" {

    Properties{
        _Color("Color", Color) = (1, 1, 1, 1)
        _Glossiness("Smoothness", Range(0, 1)) = 0.5
        _Metallic("Metallic", Range(0, 1)) = 0
         _MainTex("Texture", 2D) = "white"{}
        _OutlineColor("Outline Color", Color) = (0, 0, 0, 1)
        _OutlineWidth("Outline Width", Range(0, 10)) = 0.03

    }

        Subshader{

            Tags {
                "RenderType" = "Opaque"
            }

            CGPROGRAM
            
       
            #pragma surface surf Standard fullforwardshadows
            #pragma target 3.0
            
            sampler2D _MainTex;

        
           struct Input {
               float4 color: COLOR;
               float2 uv_MainTex;

            };

           half4 _Color;
           half _Glossiness;
           half _Metallic;

            void surf(Input IN, inout SufaceOutputStandard o) {
            
                o.Albedo = _Color.rgb * IN.color.rgb;
                o.Smoothness = _Glossiness;
                o.Metallic = _Metallic;
                o.Alpha = _Color.a * IN.color.a;
            }

            ENDCG

            Pass {

                Cull Front

                CGPROGRAM

                #pragma vertex VertexProgram
                #pragma fragment FragmentProgram

                half _OutlineWidth;

            float4 VertexProgram(
                float4 position : POSITION,
                float3 normal : NORMAL) : SV_POSITION{

            float4 clipPosition = UnityObjectToClipPos(position);
            float3 clipNormal = mul((float3x3) UNITY_MATRIX_VP, mul((float3x3) UNITY_MATRIX_M, normal));
          
            float2 offset = normalize(clipNormal.xy) / _ScreenParams.xy * _OutlineWidth * clipPosition.w * 2;
            clipPosition.xy += offset;
            


            return clipPosition;

            }

                half4 _OutlineColor;


                half4 FragmentProgram() : SV_TARGET {
                    return _OutlineColor;
                }


                ENDCG

            }

    }

}