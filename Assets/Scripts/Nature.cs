using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nature : Collidable
{
    protected override void OnCollide(Collider2D coll)
    {
        GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.7f);
    }
}
