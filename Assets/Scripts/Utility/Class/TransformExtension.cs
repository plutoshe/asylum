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


    public delegate bool MatchPattern(string origin, string match);

    public static bool ExactMatch(string origin, string match)
    {
        return origin == match;
    }


    public static List<Transform> FindDeepChildren(this Transform aParent, string aName)
    {
        return FindDeepChildren(aParent, aName, ExactMatch);
    }

    public static List<Transform> FindDeepChildren(this Transform aParent, string aName, MatchPattern matchFunction)
    {
        List<Transform> children = new List<Transform>();
        foreach (Transform child in aParent)
        {
            if (matchFunction(aName, child.name))
            {
                children.Add(child);
            }
            List<Transform> result = child.FindDeepChildren(aName, matchFunction);
            children.AddRange(result);
        }
        return children;
    }
}
