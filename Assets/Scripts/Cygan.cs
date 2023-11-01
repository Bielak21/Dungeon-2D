using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Cygan : Collidable
{
    public int stolenPesos = 7;
    public float cooldown = 4.0f;
    private float lastSteal;

    protected override void Start()
    {
        base.Start();
        lastSteal = -cooldown;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if (Time.time - lastSteal > cooldown)
        {
            lastSteal = Time.time;
            GameManager.instance.pesos -= stolenPesos;
            GameManager.instance.ShowText("- " + stolenPesos + " pesos", 20, UnityEngine.Color.red, transform.position, Vector3.up * 30, cooldown);
        }
    }
}
