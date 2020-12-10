using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Obj_Slider : UI_Object
{
    public Texture2D cursorDragIcon;
    private BoxCollider2D p_collider;

    private Transform trans;

    void Start()
    {
        trans = this.transform;
        trans.position = trans.parent.position;
        p_collider = trans.parent.GetComponent<BoxCollider2D>();
    }


    public override void OnMouseOver()
    {
        Cursor.SetCursor(cursorOverIcon, hotSpot, cursorMode);
    }

    public override void WhenMouseDown()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Cursor.SetCursor(cursorDragIcon, hotSpot, cursorMode);

        if (p_collider.bounds.Contains(mousePos))
        {
            Debug.Log("In bounds");
            trans.position = new Vector3(mousePos.x, trans.position.y, trans.position.z);
        }       
    }
}
