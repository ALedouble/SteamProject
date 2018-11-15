// Shader created with Shader Forge v1.38 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.38;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,cgin:,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,imps:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,atcv:False,rfrpo:True,rfrpn:Refraction,coma:15,ufog:True,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,atwp:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False,fsmp:False;n:type:ShaderForge.SFN_Final,id:9361,x:33500,y:32764,varname:node_9361,prsc:2|emission-2751-OUT,custl-5085-OUT,alpha-2055-OUT,clip-2055-OUT,voffset-8329-OUT,tess-4553-OUT;n:type:ShaderForge.SFN_LightAttenuation,id:8068,x:32504,y:34015,varname:node_8068,prsc:2;n:type:ShaderForge.SFN_LightColor,id:3406,x:32518,y:33804,varname:node_3406,prsc:2;n:type:ShaderForge.SFN_LightVector,id:6869,x:31671,y:33415,varname:node_6869,prsc:2;n:type:ShaderForge.SFN_NormalVector,id:9684,x:31671,y:33543,prsc:2,pt:True;n:type:ShaderForge.SFN_HalfVector,id:9471,x:31671,y:33694,varname:node_9471,prsc:2;n:type:ShaderForge.SFN_Dot,id:7782,x:31883,y:33458,cmnt:Lambert,varname:node_7782,prsc:2,dt:1|A-6869-OUT,B-9684-OUT;n:type:ShaderForge.SFN_Dot,id:3269,x:31883,y:33632,cmnt:Blinn-Phong,varname:node_3269,prsc:2,dt:1|A-9684-OUT,B-9471-OUT;n:type:ShaderForge.SFN_Multiply,id:2746,x:32278,y:33627,cmnt:Specular Contribution,varname:node_2746,prsc:2|A-7782-OUT,B-5267-OUT,C-4865-RGB;n:type:ShaderForge.SFN_Tex2d,id:851,x:31351,y:32362,ptovrint:False,ptlb:NoiseDissolve,ptin:_NoiseDissolve,varname:node_851,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:feb32965a3a6b0945b30d7d212c41505,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1941,x:32278,y:33454,cmnt:Diffuse Contribution,varname:node_1941,prsc:2|A-851-RGB,B-7782-OUT;n:type:ShaderForge.SFN_Exp,id:1700,x:31883,y:33815,varname:node_1700,prsc:2,et:1|IN-9978-OUT;n:type:ShaderForge.SFN_Slider,id:5328,x:31342,y:33817,ptovrint:False,ptlb:Gloss,ptin:_Gloss,varname:node_5328,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.5,max:1;n:type:ShaderForge.SFN_Power,id:5267,x:32081,y:33701,varname:node_5267,prsc:2|VAL-3269-OUT,EXP-1700-OUT;n:type:ShaderForge.SFN_Add,id:2159,x:32547,y:33573,cmnt:Combine,varname:node_2159,prsc:2|A-1941-OUT,B-2746-OUT;n:type:ShaderForge.SFN_Multiply,id:5085,x:32936,y:33721,cmnt:Attenuate and Color,varname:node_5085,prsc:2|A-9103-OUT,B-3406-RGB,C-8068-OUT;n:type:ShaderForge.SFN_ConstantLerp,id:9978,x:31671,y:33817,varname:node_9978,prsc:2,a:1,b:11|IN-5328-OUT;n:type:ShaderForge.SFN_Color,id:4865,x:32081,y:33856,ptovrint:False,ptlb:Spec Color,ptin:_SpecColor,varname:node_4865,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_Posterize,id:9103,x:32898,y:34034,varname:node_9103,prsc:2|IN-2159-OUT,STPS-6536-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6536,x:32707,y:34153,ptovrint:False,ptlb:PosterizeValue,ptin:_PosterizeValue,varname:node_6536,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Slider,id:6346,x:31243,y:32621,ptovrint:False,ptlb:DissolveAmount,ptin:_DissolveAmount,varname:node_6346,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:-1.4,cur:-1.4,max:1;n:type:ShaderForge.SFN_Add,id:5697,x:31568,y:32435,varname:node_5697,prsc:2|A-851-RGB,B-6346-OUT;n:type:ShaderForge.SFN_Posterize,id:372,x:31758,y:32435,varname:node_372,prsc:2|IN-5697-OUT,STPS-1989-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1989,x:31590,y:32765,ptovrint:False,ptlb:PosterizeNoiseValue,ptin:_PosterizeNoiseValue,varname:node_1989,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:3;n:type:ShaderForge.SFN_ValueProperty,id:4553,x:33504,y:33420,ptovrint:False,ptlb:TesselationValue,ptin:_TesselationValue,varname:node_4553,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:5;n:type:ShaderForge.SFN_Lerp,id:7966,x:32284,y:32389,varname:node_7966,prsc:2|A-7645-RGB,B-3242-RGB,T-7599-OUT;n:type:ShaderForge.SFN_Color,id:7645,x:31867,y:31982,ptovrint:False,ptlb:Red,ptin:_Red,varname:node_7645,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:0.3931034,c3:0,c4:1;n:type:ShaderForge.SFN_Color,id:3242,x:31899,y:32220,ptovrint:False,ptlb:Black,ptin:_Black,varname:node_3242,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0,c2:0,c3:0,c4:1;n:type:ShaderForge.SFN_RemapRange,id:7599,x:32094,y:32436,varname:node_7599,prsc:2,frmn:-1,frmx:1,tomn:0,tomx:1|IN-3630-OUT;n:type:ShaderForge.SFN_ComponentMask,id:743,x:32457,y:32651,varname:node_743,prsc:2,cc1:0,cc2:-1,cc3:-1,cc4:-1|IN-7966-OUT;n:type:ShaderForge.SFN_Clamp,id:3630,x:31940,y:32436,varname:node_3630,prsc:2|IN-372-OUT,MIN-1715-OUT,MAX-9834-OUT;n:type:ShaderForge.SFN_Vector1,id:1715,x:31758,y:32580,varname:node_1715,prsc:2,v1:-1;n:type:ShaderForge.SFN_Vector1,id:9834,x:31758,y:32642,varname:node_9834,prsc:2,v1:1;n:type:ShaderForge.SFN_Multiply,id:5828,x:32783,y:32857,varname:node_5828,prsc:2|A-743-OUT,B-5160-OUT;n:type:ShaderForge.SFN_Multiply,id:2751,x:32714,y:32285,varname:node_2751,prsc:2|A-7966-OUT,B-408-OUT;n:type:ShaderForge.SFN_ValueProperty,id:408,x:32476,y:32464,ptovrint:False,ptlb:EmissionValue,ptin:_EmissionValue,varname:node_408,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Multiply,id:8329,x:32783,y:32994,varname:node_8329,prsc:2|A-5697-OUT,B-4794-OUT,C-7990-RGB;n:type:ShaderForge.SFN_NormalVector,id:4794,x:32553,y:33030,prsc:2,pt:False;n:type:ShaderForge.SFN_Clamp01,id:2055,x:32978,y:32822,varname:node_2055,prsc:2|IN-2816-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5160,x:32286,y:32950,ptovrint:False,ptlb:OpacityMultiplyerValue,ptin:_OpacityMultiplyerValue,varname:node_5160,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:2;n:type:ShaderForge.SFN_Add,id:2816,x:32733,y:32590,varname:node_2816,prsc:2|A-743-OUT,B-6393-OUT;n:type:ShaderForge.SFN_Vector1,id:6393,x:32562,y:32812,varname:node_6393,prsc:2,v1:0.4;n:type:ShaderForge.SFN_Tex2d,id:7990,x:32581,y:33209,ptovrint:False,ptlb:node_7990,ptin:_node_7990,varname:node_7990,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:3cfec84909983914ba851d25cdb061c0,ntxv:0,isnm:False|UVIN-4238-UVOUT;n:type:ShaderForge.SFN_Panner,id:4238,x:32325,y:33164,varname:node_4238,prsc:2,spu:1,spv:1|UVIN-214-UVOUT,DIST-5752-OUT;n:type:ShaderForge.SFN_TexCoord,id:214,x:32039,y:32961,varname:node_214,prsc:2,uv:0,uaff:False;n:type:ShaderForge.SFN_Time,id:9578,x:31897,y:33160,varname:node_9578,prsc:2;n:type:ShaderForge.SFN_Multiply,id:5752,x:32128,y:33186,varname:node_5752,prsc:2|A-9578-T,B-9452-OUT;n:type:ShaderForge.SFN_ValueProperty,id:9452,x:31918,y:33329,ptovrint:False,ptlb:SpeedPannerNoiseOffset,ptin:_SpeedPannerNoiseOffset,varname:node_9452,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;proporder:851-5328-4865-6536-6346-1989-4553-7645-3242-408-5160-7990-9452;pass:END;sub:END;*/

Shader "Shader Forge/ToonShader" {
    Properties {
        _NoiseDissolve ("NoiseDissolve", 2D) = "white" {}
        _Gloss ("Gloss", Range(0, 1)) = 0.5
        _SpecColor ("Spec Color", Color) = (1,1,1,1)
        _PosterizeValue ("PosterizeValue", Float ) = 0
        _DissolveAmount ("DissolveAmount", Range(-1.4, 1)) = -1.4
        _PosterizeNoiseValue ("PosterizeNoiseValue", Float ) = 3
        _TesselationValue ("TesselationValue", Float ) = 5
        _Red ("Red", Color) = (1,0.3931034,0,1)
        _Black ("Black", Color) = (0,0,0,1)
        _EmissionValue ("EmissionValue", Float ) = 2
        _OpacityMultiplyerValue ("OpacityMultiplyerValue", Float ) = 2
        _node_7990 ("node_7990", 2D) = "white" {}
        _SpeedPannerNoiseOffset ("SpeedPannerNoiseOffset", Float ) = 1
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
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdbase
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform sampler2D _NoiseDissolve; uniform float4 _NoiseDissolve_ST;
            uniform float _Gloss;
            uniform float _PosterizeValue;
            uniform float _DissolveAmount;
            uniform float _PosterizeNoiseValue;
            uniform float _TesselationValue;
            uniform float4 _Red;
            uniform float4 _Black;
            uniform float _EmissionValue;
            uniform sampler2D _node_7990; uniform float4 _node_7990_ST;
            uniform float _SpeedPannerNoiseOffset;
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
                float4 _NoiseDissolve_var = tex2Dlod(_NoiseDissolve,float4(TRANSFORM_TEX(o.uv0, _NoiseDissolve),0.0,0));
                float3 node_5697 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float4 node_9578 = _Time;
                float2 node_4238 = (o.uv0+(node_9578.g*_SpeedPannerNoiseOffset)*float2(1,1));
                float4 _node_7990_var = tex2Dlod(_node_7990,float4(TRANSFORM_TEX(node_4238, _node_7990),0.0,0));
                v.vertex.xyz += (node_5697*v.normal*_node_7990_var.rgb);
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
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _NoiseDissolve_var = tex2D(_NoiseDissolve,TRANSFORM_TEX(i.uv0, _NoiseDissolve));
                float3 node_5697 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float3 node_7966 = lerp(_Red.rgb,_Black.rgb,(clamp(floor(node_5697 * _PosterizeNoiseValue) / (_PosterizeNoiseValue - 1),(-1.0),1.0)*0.5+0.5));
                float node_743 = node_7966.r;
                float node_2055 = saturate((node_743+0.4));
                clip(node_2055 - 0.5);
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = 1;
////// Emissive:
                float3 emissive = (node_7966*_EmissionValue);
                float node_7782 = max(0,dot(lightDirection,normalDirection)); // Lambert
                float3 finalColor = emissive + (floor(((_NoiseDissolve_var.rgb*node_7782)+(node_7782*pow(max(0,dot(normalDirection,halfDirection)),exp2(lerp(1,11,_Gloss)))*_SpecColor.rgb)) * _PosterizeValue) / (_PosterizeValue - 1)*_LightColor0.rgb*attenuation);
                fixed4 finalRGBA = fixed4(finalColor,node_2055);
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
            #include "Lighting.cginc"
            #include "Tessellation.cginc"
            #pragma multi_compile_fwdadd
            #pragma multi_compile_fog
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 5.0
            uniform sampler2D _NoiseDissolve; uniform float4 _NoiseDissolve_ST;
            uniform float _Gloss;
            uniform float _PosterizeValue;
            uniform float _DissolveAmount;
            uniform float _PosterizeNoiseValue;
            uniform float _TesselationValue;
            uniform float4 _Red;
            uniform float4 _Black;
            uniform float _EmissionValue;
            uniform sampler2D _node_7990; uniform float4 _node_7990_ST;
            uniform float _SpeedPannerNoiseOffset;
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
                float4 _NoiseDissolve_var = tex2Dlod(_NoiseDissolve,float4(TRANSFORM_TEX(o.uv0, _NoiseDissolve),0.0,0));
                float3 node_5697 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float4 node_9578 = _Time;
                float2 node_4238 = (o.uv0+(node_9578.g*_SpeedPannerNoiseOffset)*float2(1,1));
                float4 _node_7990_var = tex2Dlod(_node_7990,float4(TRANSFORM_TEX(node_4238, _node_7990),0.0,0));
                v.vertex.xyz += (node_5697*v.normal*_node_7990_var.rgb);
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
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float4 _NoiseDissolve_var = tex2D(_NoiseDissolve,TRANSFORM_TEX(i.uv0, _NoiseDissolve));
                float3 node_5697 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float3 node_7966 = lerp(_Red.rgb,_Black.rgb,(clamp(floor(node_5697 * _PosterizeNoiseValue) / (_PosterizeNoiseValue - 1),(-1.0),1.0)*0.5+0.5));
                float node_743 = node_7966.r;
                float node_2055 = saturate((node_743+0.4));
                clip(node_2055 - 0.5);
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
                float3 halfDirection = normalize(viewDirection+lightDirection);
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float node_7782 = max(0,dot(lightDirection,normalDirection)); // Lambert
                float3 finalColor = (floor(((_NoiseDissolve_var.rgb*node_7782)+(node_7782*pow(max(0,dot(normalDirection,halfDirection)),exp2(lerp(1,11,_Gloss)))*_SpecColor.rgb)) * _PosterizeValue) / (_PosterizeValue - 1)*_LightColor0.rgb*attenuation);
                fixed4 finalRGBA = fixed4(finalColor * node_2055,0);
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
            uniform float _TesselationValue;
            uniform float4 _Red;
            uniform float4 _Black;
            uniform sampler2D _node_7990; uniform float4 _node_7990_ST;
            uniform float _SpeedPannerNoiseOffset;
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
                float4 _NoiseDissolve_var = tex2Dlod(_NoiseDissolve,float4(TRANSFORM_TEX(o.uv0, _NoiseDissolve),0.0,0));
                float3 node_5697 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float4 node_9578 = _Time;
                float2 node_4238 = (o.uv0+(node_9578.g*_SpeedPannerNoiseOffset)*float2(1,1));
                float4 _node_7990_var = tex2Dlod(_node_7990,float4(TRANSFORM_TEX(node_4238, _node_7990),0.0,0));
                v.vertex.xyz += (node_5697*v.normal*_node_7990_var.rgb);
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
                    VertexOutput o = vert(v);
                    return o;
                }
            #endif
            float4 frag(VertexOutput i) : COLOR {
                i.normalDir = normalize(i.normalDir);
                float3 normalDirection = i.normalDir;
                float4 _NoiseDissolve_var = tex2D(_NoiseDissolve,TRANSFORM_TEX(i.uv0, _NoiseDissolve));
                float3 node_5697 = (_NoiseDissolve_var.rgb+_DissolveAmount);
                float3 node_7966 = lerp(_Red.rgb,_Black.rgb,(clamp(floor(node_5697 * _PosterizeNoiseValue) / (_PosterizeNoiseValue - 1),(-1.0),1.0)*0.5+0.5));
                float node_743 = node_7966.r;
                float node_2055 = saturate((node_743+0.4));
                clip(node_2055 - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
