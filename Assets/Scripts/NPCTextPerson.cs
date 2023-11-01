using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTextPerson : Collidable
{
    public string[] message;
    public Color color = Color.white;
    private int rand;

    public float cooldown = 4.0f;
    private float lastShout;

    protected override void Start()
    {
        base.Start();
        lastShout = -cooldown;
    }
    
    public string RandomMessage()
    {
        rand = Random.Range(0, message.Length);
        string randomMessage = message[rand];
        return randomMessage;
    }

    protected override void OnCollide(Collider2D coll)
    {
        if(Time.time - lastShout > cooldown && coll.name=="Player")
        {
            lastShout = Time.time;
            GameManager.instance.ShowText(RandomMessage(), 20, color, transform.position + new Vector3(0, 0.16f, 0), Vector3.zero, cooldown);
        }
        
    }
}
