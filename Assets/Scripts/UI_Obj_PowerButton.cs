﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Obj_PowerButton : UI_Object
{
    public Sprite img_unpressed;
    public Sprite img_pressed;
    SpriteRenderer spriteRend;
    public Game_Controller gameController;

    void Start()
    {
        spriteRend = this.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        spriteRend.sprite = img_unpressed;
    }

    public override void OnMouseOver()
    {
        Cursor.SetCursor(cursorOverIcon, hotSpot, cursorMode);
    }

    public override void OnMouseClick()
    {
        spriteRend.sprite = img_pressed;
        gameController.TogglePower();
    }

    public override void OnMouseUp()
    {
        spriteRend.sprite = img_unpressed;
    }
}
