﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Obj_Knob : UI_Object
{

    public override void OnMouseOver()
    {
        Cursor.SetCursor(cursorOverIcon, hotSpot, cursorMode);
    }

    public override void WhenMouseDown()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

    }
}
