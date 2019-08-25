using System.Collections.Generic;
using UnityEngine;

public static class TransformDeepChildExtension
{
    public static Transform FindDeepChild(this Transform aParent, string aName, bool isBFS = true)
    {
        if (isBFS)
        {
            //Breadth-first search
            Queue<Transform> queue = new Queue<Transform>();
            queue.Enqueue(aParent);
            while (queue.Count > 0)
            {
                var c = queue.Dequeue();
                if (c.name == aName)
                    return c;
                foreach (Transform t in c)
                    queue.Enqueue(t);
            }
            return null;
        }
        else
        {
            //Depth-first search
            foreach (Transform child in aParent)
            {
                if (child.name == aName)
                    return child;
                var result = child.FindDeepChild(aName, false);
                if (result != null)
                    return result;
            }
            return null;
        }
    }
}
