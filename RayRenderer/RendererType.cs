using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 渲染类型
    /// </summary>
    public enum RendererType
    {
        /// <summary>
        /// 光线渲染
        /// </summary>
        RayRenderer=0,

        /// <summary>
        /// 光栅渲染
        /// </summary>
        RasterRenderer,

    }

    /// <summary>
    /// 光线渲染类型
    /// </summary>
    public enum RayRendererType
    {
        /// <summary>
        /// 渲染深度
        /// </summary>
        RenderDepth=0,

        /// <summary>
        /// 渲染法向量
        /// </summary>
        RenderNormal,

        /// <summary>
        /// 全局光照
        /// </summary>
        RenderLight,

        /// <summary>
        /// Phong材质
        /// </summary>
        RenderPhong,
    }

    /// <summary>
    /// 光照模式
    /// </summary>
    public enum LightType
    {
        /// <summary>
        /// 平行光照
        /// </summary>
        DirectionalLight=0,
        /// <summary>
        /// 点光源
        /// </summary>
        PointLight,
        /// <summary>
        /// 聚光灯
        /// </summary>
        SpotLight,
    }
}
