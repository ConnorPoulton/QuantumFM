using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Obj_ProgressBulb : UI_Object
{
    public Sprite img_unlit;
    public Sprite img_lit;
    SpriteRenderer spriteRend;

    void Start()
    {
        spriteRend = this.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteRend.sprite = img_unlit;
    }

    public void LightUp()
    {
        spriteRend.sprite = img_lit;
    }
}
