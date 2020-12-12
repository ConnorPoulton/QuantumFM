using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Obj_Knob : UI_Object
{
    private float intensity = 0;
    private Vector2 directionVector;

    public Vector2 targetVector;
    public Game_Controller gameController;
    public int knobID;

    void Start()
    {
        directionVector = (transform.rotation * Vector2.up).normalized;
        intensity = Math.Abs(Vector2.Dot(directionVector, targetVector)) / 2;

        gameController.SetStatic();
        targetVector = targetVector.normalized;
    }

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

        directionVector = (transform.rotation * Vector2.up).normalized;
        intensity = Math.Abs(Vector2.Dot(directionVector, targetVector)) / 2;

        gameController.staticIntensity[knobID] = intensity;
        gameController.SetStatic();
    }
}
