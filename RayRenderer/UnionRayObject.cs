using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayRenderer
{
    /// <summary>
    /// 并集光线物体
    /// </summary>
    public class UnionRayObject
    {
        /// <summary>
        /// 需要并集的物体
        /// </summary>
        private List<RayGameObject> listObject = new List<RayGameObject>();

  

        public UnionRayObject()
        {
        }

        /// <summary>
        /// 添加物体
        /// </summary>
        /// <param name="mObject"></param>
        public void Add(RayGameObject mObject)
        {
            if (!listObject.Contains(mObject))
            {
                listObject.Add(mObject);
            }
        }

        /// <summary>
        /// 移除物体
        /// </summary>
        /// <param name="mObject"></param>
        /// <returns></returns>
        public bool Remove(RayGameObject mObject)
        {
            return listObject.Remove(mObject);
        }

        /// <summary>
        /// 移除指定索引的物体
        /// </summary>
        /// <param name="mIndex"></param>
        /// <returns></returns>
        public RayGameObject RemoveAt(int mIndex)
        {
            RayGameObject obj = listObject[mIndex];
            listObject.RemoveAt(mIndex);
            return obj;
        }

        /// <summary>
        /// 并集与射线交叉
        /// </summary>
        /// <param name="ray"></param>
        /// <returns></returns>
        public RaycastHit Intersect(Ray3 ray)
        {
            float minDistance = int.MaxValue;
            RaycastHit hit = new RaycastHit();
            RaycastHit tempHit;
            foreach(RayGameObject item in this.listObject)
            {
                tempHit = item.Intersect(ray);
                if (tempHit.GameObject != null && tempHit.Distance < minDistance)
                {
                    minDistance = tempHit.Distance;
                    hit = tempHit;
                }
            }
            return hit;
        }

    }
}
