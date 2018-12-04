// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:4013,x:32719,y:32712,varname:node_4013,prsc:2|diff-5218-OUT,alpha-5561-OUT,clip-5561-OUT,disp-8931-OUT,tess-4323-OUT;n:type:ShaderForge.SFN_Tex2d,id:1672,x:30646,y:32278,ptovrint:False,ptlb:NoiseDissolve,ptin:_NoiseDissolve,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:feb32965a3a6b0945b30d7d212c41505,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Slider,id:2552,x:30174,y:32548,ptovrint:False,ptlb:DissolveAmount,ptin:_DissolveAmount,varname:node_6346,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1.4,cur:-1.4,max:1;n:type:ShaderForge.SFN_Add,id:367,x:30863,y:32351,varname:node_367,prsc:2|A-1672-RGB,B-2552-OUT;n:type:ShaderForge.SFN_Posterize,id:8292,x:31053,y:32351,varname:node_8292,prsc:2|IN-367-OUT,STPS-3731-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3731,x:30885,y:32681,ptovrint:False,ptlb:PosterizeNoiseValue,ptin:_PosterizeNoiseValue,varname:node_1989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_Lerp,id:8692,x:31579,y:32305,varname:node_8692,prsc:2|A-8604-RGB,B-2968-RGB,T-2130-OUT;n:type:ShaderForge.SFN_Color,id:8604,x:31162,y:31898,ptovrint:False,ptlb:Red,ptin:_Red,varname:node_7645,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.3931034,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:2968,x:31194,y:32136,ptovrint:False,ptlb:Black,ptin:_Black,varname:node_3242,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_RemapRange,id:2130,x:31389,y:32352,varname:node_2130,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-866-OUT;n:type:ShaderForge.SFN_ComponentMask,id:4160,x:31752,y:32567,varname:node_4160,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-8692-OUT;n:type:ShaderForge.SFN_Clamp,id:866,x:31235,y:32352,varname:node_866,prsc:2|IN-8292-OUT,MIN-6134-OUT,MAX-3314-OUT;n:type:ShaderForge.SFN_Vector1,id:6134,x:31053,y:32496,varname:node_6134,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:3314,x:31053,y:32558,varname:node_3314,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:3671,x:32078,y:32773,varname:node_3671,prsc:2|A-4160-OUT,B-9330-OUT;n:type:ShaderForge.SFN_Multiply,id:5218,x:32454,y:32192,varname:node_5218,prsc:2|A-8692-OUT,B-8242-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9351,x:31791,y:32418,ptovrint:False,ptlb:EmissionValue,ptin:_EmissionValue,varname:node_408,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:8931,x:32078,y:32910,varname:node_8931,prsc:2|A-367-OUT,B-8149-OUT,C-8121-RGB;n:type:ShaderForge.SFN_NormalVector,id:8149,x:31848,y:32946,prsc:2,pt:False;n:type:ShaderForge.SFN_Clamp01,id:5561,x:32273,y:32738,varname:node_5561,prsc:2|IN-7704-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9330,x:31581,y:32866,ptovrint:False,ptlb:OpacityMultiplyerValue,ptin:_OpacityMultiplyerValue,varname:node_5160,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Add,id:7704,x:32028,y:32506,varname:node_7704,prsc:2|A-4160-OUT,B-2384-OUT;n:type:ShaderForge.SFN_Vector1,id:2384,x:31857,y:32728,varname:node_2384,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Tex2d,id:8121,x:31876,y:33125,ptovrint:False,ptlb:node_7990,ptin:_node_7990,varname:node_7990,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3cfec84909983914ba851d25cdb061c0,ntxv:0,isnm:False|UVIN-7988-UVOUT;n:type:ShaderForge.SFN_Panner,id:7988,x:31620,y:33080,varname:node_7988,prsc:2,spu:1,spv:1|UVIN-9498-UVOUT;n:type:ShaderForge.SFN_TexCoord,id:9498,x:31334,y:32877,varname:node_9498,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:4695,x:31192,y:33076,varname:node_4695,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5138,x:31423,y:33102,varname:node_5138,prsc:2|A-4695-T,B-7058-OUT;n:type:ShaderForge.SFN_ValueProperty,id:7058,x:31213,y:33245,ptovrint:False,ptlb:SpeedPannerNoiseOffset,ptin:_SpeedPannerNoiseOffset,varname:node_9452,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_ValueProperty,id:4323,x:32422,y:33211,ptovrint:False,ptlb:TesselationValue,ptin:_TesselationValue,varname:node_4323,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:3806,x:30483,y:32625,varname:node_3806,prsc:2|A-2552-OUT,B-9925-OUT;n:type:ShaderForge.SFN_Vector1,id:9925,x:30280,y:32715,varname:node_9925,prsc:2,v1:-1;n:type:ShaderForge.SFN_RemapRange,id:3126,x:30650,y:32625,varname:node_3126,prsc:2,frmn:-1.4,frmx:1.4,tomn:0,tomx:1|IN-3806-OUT;n:type:ShaderForge.SFN_Multiply,id:4519,x:32018,y:32322,varname:node_4519,prsc:2|A-9351-OUT,B-3126-OUT;n:type:ShaderForge.SFN_Add,id:8242,x:32309,y:32333,varname:node_8242,prsc:2|A-4519-OUT,B-6958-OUT;n:type:ShaderForge.SFN_Vector1,id:6958,x:32158,y:32400,varname:node_6958,prsc:2,v1:1;proporder:1672-2552-3731-8604-2968-9351-8121-4323;pass:END;sub:END;*/

Shader "Shader Forge/NewShader" {
    Properties {
        _NoiseDissolve ("NoiseDissolve", 2D) = "white" {}
        _DissolveAmount ("DissolveAmount", Range(-1.4, 1)) = -1.4
        _PosterizeNoiseValue ("PosterizeNoiseValue", Float ) = 3
        _Red ("Red", Color) = (1,0.3931034,0,1)
        _Black ("Black", Color) = (0,0,0,1)
        _EmissionValue ("EmissionValue", Float ) = 2
        _node_7990 ("node_7990", 2D) = "white" {}
        _TesselationValue ("TesselationValue", Float ) = 2
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float4 _LightColor0;
            uniform sampler2D _NoiseDissolve; uniform float4 _NoiseDissolve_ST;
            uniform float _DissolveAmount;
            uniform float _PosterizeNoiseValue;
            uniform float4 _Red;
            uniform float4 _Black;
            uniform float _EmissionValue;
            uniform sampler2D _node_7990; uniform float4 _node_7990_ST;
            uniform float _TesselationValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                UNITY_FOG_COORDS(3)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 _NoiseDissolve_var = tex2Dlod(_NoiseDissolve,float4(TRANSFORM_TEX(v.texcoord0, _NoiseDissolve),0.0,0));
                    float3 node_367 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                    float4 node_2695 = _Time;
                    float2 node_7988 = (v.texcoord0+node_2695.g*float2(1,1));
                    float4 _node_7990_var = tex2Dlod(_node_7990,float4(TRANSFORM_TEX(node_7988, _node_7990),0.0,0));
                    v.vertex.xyz += (node_367*v.normal*_node_7990_var.rgb);
                }
                float Tessellation(TessVertex v){
                    return _TesselationValue;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _NoiseDissolve_var = tex2D(_NoiseDissolve,TRANSFORM_TEX(i.uv0, _NoiseDissolve));
                float3 node_367 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float3 node_8692 = lerp(_Red.rgb,_Black.rgb,(clamp(floor(node_367 * _PosterizeNoiseValue) / (_PosterizeNoiseValue - 1),(-1.0),1.0)*0.5+0.5));
                float node_4160 = node_8692.r;
                float node_5561 = saturate((node_4160+0.4));
                clip(node_5561 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float3 diffuseColor = (node_8692*((_EmissionValue*((_DissolveAmount*(-1.0))*0.3571429+0.5))+1.0));
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor,node_5561);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            ZWrite Off
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform float4 _LightColor0;
            uniform sampler2D _NoiseDissolve; uniform float4 _NoiseDissolve_ST;
            uniform float _DissolveAmount;
            uniform float _PosterizeNoiseValue;
            uniform float4 _Red;
            uniform float4 _Black;
            uniform float _EmissionValue;
            uniform sampler2D _node_7990; uniform float4 _node_7990_ST;
            uniform float _TesselationValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                LIGHTING_COORDS(3,4)
                UNITY_FOG_COORDS(5)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = UnityObjectToClipPos( v.vertex );
                UNITY_TRANSFER_FOG(o,o.pos);
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 _NoiseDissolve_var = tex2Dlod(_NoiseDissolve,float4(TRANSFORM_TEX(v.texcoord0, _NoiseDissolve),0.0,0));
                    float3 node_367 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                    float4 node_547 = _Time;
                    float2 node_7988 = (v.texcoord0+node_547.g*float2(1,1));
                    float4 _node_7990_var = tex2Dlod(_node_7990,float4(TRANSFORM_TEX(node_7988, _node_7990),0.0,0));
                    v.vertex.xyz += (node_367*v.normal*_node_7990_var.rgb);
                }
                float Tessellation(TessVertex v){
                    return _TesselationValue;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _NoiseDissolve_var = tex2D(_NoiseDissolve,TRANSFORM_TEX(i.uv0, _NoiseDissolve));
                float3 node_367 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float3 node_8692 = lerp(_Red.rgb,_Black.rgb,(clamp(floor(node_367 * _PosterizeNoiseValue) / (_PosterizeNoiseValue - 1),(-1.0),1.0)*0.5+0.5));
                float node_4160 = node_8692.r;
                float node_5561 = saturate((node_4160+0.4));
                clip(node_5561 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 diffuseColor = (node_8692*((_EmissionValue*((_DissolveAmount*(-1.0))*0.3571429+0.5))+1.0));
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                fixed4 finalRGBA = fixed4(finalColor * node_5561,0);
                UNITY_APPLY_FOG(i.fogCoord, finalRGBA);
                return finalRGBA;
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            Cull Back
            
            CGPROGRAM
            #pragma hull hull
            #pragma domain domain
            #pragma vertex tessvert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform sampler2D _NoiseDissolve; uniform float4 _NoiseDissolve_ST;
            uniform float _DissolveAmount;
            uniform float _PosterizeNoiseValue;
            uniform float4 _Red;
            uniform float4 _Black;
            uniform sampler2D _node_7990; uniform float4 _node_7990_ST;
            uniform float _TesselationValue;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 tangent : TANGENT;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.pos = UnityObjectToClipPos( v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            #ifdef UNITY_CAN_COMPILE_TESSELLATION
                struct TessVertex {
                    float4 vertex : INTERNALTESSPOS;
                    float3 normal : NORMAL;
                    float4 tangent : TANGENT;
                    float2 texcoord0 : TEXCOORD0;
                };
                struct OutputPatchConstant {
                    float edge[3]         : SV_TessFactor;
                    float inside          : SV_InsideTessFactor;
                    float3 vTangent[4]    : TANGENT;
                    float2 vUV[4]         : TEXCOORD;
                    float3 vTanUCorner[4] : TANUCORNER;
                    float3 vTanVCorner[4] : TANVCORNER;
                    float4 vCWts          : TANWEIGHTS;
                };
                TessVertex tessvert (VertexInput v) {
                    TessVertex o;
                    o.vertex = v.vertex;
                    o.normal = v.normal;
                    o.tangent = v.tangent;
                    o.texcoord0 = v.texcoord0;
                    return o;
                }
                void displacement (inout VertexInput v){
                    float4 _NoiseDissolve_var = tex2Dlod(_NoiseDissolve,float4(TRANSFORM_TEX(v.texcoord0, _NoiseDissolve),0.0,0));
                    float3 node_367 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                    float4 node_2089 = _Time;
                    float2 node_7988 = (v.texcoord0+node_2089.g*float2(1,1));
                    float4 _node_7990_var = tex2Dlod(_node_7990,float4(TRANSFORM_TEX(node_7988, _node_7990),0.0,0));
                    v.vertex.xyz += (node_367*v.normal*_node_7990_var.rgb);
                }
                float Tessellation(TessVertex v){
                    return _TesselationValue;
                }
                float4 Tessellation(TessVertex v, TessVertex v1, TessVertex v2){
                    float tv = Tessellation(v);
                    float tv1 = Tessellation(v1);
                    float tv2 = Tessellation(v2);
                    return float4( tv1+tv2, tv2+tv, tv+tv1, tv+tv1+tv2 ) / float4(2,2,2,3);
                }
                OutputPatchConstant hullconst (InputPatch<TessVertex,3> v) {
                    OutputPatchConstant o = (OutputPatchConstant)0;
                    float4 ts = Tessellation( v[0], v[1], v[2] );
                    o.edge[0] = ts.x;
                    o.edge[1] = ts.y;
                    o.edge[2] = ts.z;
                    o.inside = ts.w;
                    return o;
                }
                [domain("tri")]
                [partitioning("fractional_odd")]
                [outputtopology("triangle_cw")]
                [patchconstantfunc("hullconst")]
                [outputcontrolpoints(3)]
                TessVertex hull (InputPatch<TessVertex,3> v, uint id : SV_OutputControlPointID) {
                    return v[id];
                }
                [domain("tri")]
                VertexOutput domain (OutputPatchConstant tessFactors, const OutputPatch<TessVertex,3> vi, float3 bary : SV_DomainLocation) {
                    VertexInput v = (VertexInput)0;
                    v.vertex = vi[0].vertex*bary.x + vi[1].vertex*bary.y + vi[2].vertex*bary.z;
                    v.normal = vi[0].normal*bary.x + vi[1].normal*bary.y + vi[2].normal*bary.z;
                    v.tangent = vi[0].tangent*bary.x + vi[1].tangent*bary.y + vi[2].tangent*bary.z;
                    v.texcoord0 = vi[0].texcoord0*bary.x + vi[1].texcoord0*bary.y + vi[2].texcoord0*bary.z;
                    displacement(v);
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _NoiseDissolve_var = tex2D(_NoiseDissolve,TRANSFORM_TEX(i.uv0, _NoiseDissolve));
                float3 node_367 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float3 node_8692 = lerp(_Red.rgb,_Black.rgb,(clamp(floor(node_367 * _PosterizeNoiseValue) / (_PosterizeNoiseValue - 1),(-1.0),1.0)*0.5+0.5));
                float node_4160 = node_8692.r;
                float node_5561 = saturate((node_4160+0.4));
                clip(node_5561 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
