using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Mover
{
    private SpriteRenderer spriteRenderer;
    private bool isAlive = true;
    protected override void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    protected override void RecieveDamage(Damage dmg)
    {
        if (!isAlive)
            return;
        base.RecieveDamage(dmg);
        GameManager.instance.OnHitpointChange();
    }
    protected override void Death()
    {
        isAlive = false;
        GameManager.instance.deathMenuAnim.SetTrigger("Show");
    }
    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if(isAlive)
            UpdateMotor(new Vector3(x, y, 0));
    }

    public void SwapSprite(int skinId)
    {
        spriteRenderer.sprite = GameManager.instance.playerSprites[skinId];
    }

    public void OnLevelUp()
    {
        maxHitpoints++;
        hitpoints = maxHitpoints;
    }

    public void SetLevel(int level)
    {
        for (int i = 0; i < level; i++)
        {
            OnLevelUp();
        }
    }

    public void Heal(int healingAmount, Color kolor)
    {
        string znak = "";

        if (hitpoints == maxHitpoints)
        {
            return;
        }

        hitpoints += healingAmount;

        if(hitpoints > maxHitpoints)
        {
            hitpoints = maxHitpoints;
        }

        if(healingAmount > 0)
        {
            znak = "+";
        }
        else
        {
            znak = string.Empty;
        }
        GameManager.instance.ShowText(znak + healingAmount.ToString() + "hp", 25, kolor, transform.position, Vector3.up * 30, 1.0f);
        GameManager.instance.OnHitpointChange();
    }

    public void Respawn()
    {
        Heal(maxHitpoints, Color.green);
        isAlive = true;
        lastImmune = Time.time;
        pushDirection = Vector3.zero;
    }
}
