using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public Transform target;

    private Vector3 mousePos;


    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(transform.tag))
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag(transform.tag))
        {
            target = null;
        }
    }

    private void OnMouseUp()
    {
        if (target != null)
        {
            transform.position = target.position;
            target.GetComponent<BoxCollider>().enabled = false;
            GameManager.Instance.GetCurLevel().RemoveObject(gameObject);
        }
    }

    Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }
    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        var pos =Camera.main.ScreenToWorldPoint(Input.mousePosition-this.mousePos);
        pos.y = 1;
        transform.position = pos;
    }
}
