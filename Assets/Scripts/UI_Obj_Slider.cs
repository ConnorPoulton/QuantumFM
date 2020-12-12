using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Obj_Slider : UI_Object
{
    private BoxCollider2D p_collider;
    private Transform trans;
    public int channelID;

    public Game_Controller gameController;

    void Start()
    {
        trans = this.transform;
        trans.position = trans.parent.position;
        p_collider = trans.parent.GetComponent<BoxCollider2D>();
        gameController.ChangeChannelID(channelID);
    }


    public override void OnMouseOver()
    {
        Cursor.SetCursor(cursorOverIcon, hotSpot, cursorMode);
    }

    public override void WhenMouseDown()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (p_collider.bounds.Contains(mousePos))
        {
            trans.position = new Vector3(mousePos.x, trans.position.y, trans.position.z);
            int mousePosX = (int)mousePos.x;
            mousePosX = Math.Abs(mousePosX);
            int mousePosx = (mousePosX % 5);
            if (mousePosX != channelID)
            {
                channelID = mousePosx;
                gameController.ChangeChannelID(channelID);
            }               
        }       
    }
}
