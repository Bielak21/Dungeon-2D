using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadow : MonoBehaviour
{
    public float alphaLevel = 0.5f;
    public void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaLevel);
    }

}
