Shader "Custom/X_Diffuse" {
	
	Properties { 
      _MainTex ("Texture", 2D) = "white" {}
       _ColorMy ("Main Color", Color) = (1,0.5,0.5,0.1)
    }
    
    
    
    SubShader {
      Cull off 
      Tags { "RenderType" = "TransparentCutout" }
      //Tags { "Queue" = "Transparent+1" }
      //Tags { "Queue" = "AlphaTest" }
     
      CGPROGRAM
      #pragma surface surf Lambert
      float4 _ColorMy;
      struct Input {
          float2 uv_MainTex;
      };
      sampler2D _MainTex;
      void surf (Input IN, inout SurfaceOutput o) {
          o.Albedo = tex2D (_MainTex, IN.uv_MainTex).rgb*_ColorMy;
      }
      ENDCG
    }
	
	FallBack "Diffuse"
}
