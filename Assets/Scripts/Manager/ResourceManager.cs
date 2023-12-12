using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Instantiate(string name)
    {
        GameObject go = Resources.Load<GameObject>(name);
        return Instantiate(go);
    }

    public void Destroy(GameObject go)
    {
        if (go == null) return;

        Object.Destroy(go);
    }
}
