using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SteeringControl : MonoBehaviour, IDragHandler, IPointerDownHandler
{
    private GameData Data;
    private RectTransform Handle;
    private float Angle = 0f;
    private float LastAngle = 0f;
    private Vector2 center;
    private void Start()
    {
        Data = GameObject.FindGameObjectWithTag("data").GetComponent<GameData>();
        Handle = GetComponent<RectTransform>();
        Angle = 0f;
        LastAngle = 0f;
    }
    void Update()
    {
        Handle.localEulerAngles = new Vector3(0, 0, -Angle);
    }

    public float GetAngle()
    {
        return Angle;
    }
    public void OnPointerDown(PointerEventData data)
    {
        center = Handle.position;
        LastAngle = Vector2.Angle(Vector2.up, data.position - center);//angle between up and resaltant vector touch and handle center
    }
    public void OnDrag(PointerEventData data)
    {
        if (!Data.GamePause)
        {
            float NewAngle = Vector2.Angle(Vector2.up, data.position - center);
            if ((data.position - center).sqrMagnitude >= 400)//distence between handle center and touch position
            {
                if (data.position.x > center.x)
                    Angle += NewAngle - LastAngle;
                else
                    Angle -= NewAngle - LastAngle;
            }
            LastAngle = NewAngle;
        }
    }
    
}