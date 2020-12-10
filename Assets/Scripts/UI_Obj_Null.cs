using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Obj_Null : UI_Object
{

    public override void OnMouseClick()
    {
        return;
    }

    public override void OnMouseOver()
    {
        Cursor.SetCursor(cursorOverIcon, hotSpot, cursorMode);
    }

    public override void WhenMouseDown()
    {
        return;
    }
}
