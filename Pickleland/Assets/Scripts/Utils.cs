using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // This function will iteratively climb up the transform.parent tree
    // until it either finds a parent with a tag != "Untagged" or no parent
    public static GameObject FindTaggedParent(GameObject go)
    {
        // If this gameObject has a tag
        if (go.tag != "Untagged")
        {
            // then return this gameObject
            return (go);
        }
        // If there is no parent of this Transform
        if (go.transform.parent == null)
        {
            // We've reached the top of the hierarchy with no interesting tag
            // So return null
            return (null);
        }
        // Otherwise, recursively climb up the tree
        return (FindTaggedParent(go.transform.parent.gameObject));
    }

    // This version of the function handles things if a Transform is passed in
    public static GameObject FindTaggedParent(Transform t)
    {
        return (FindTaggedParent(t.gameObject));
    }
}
