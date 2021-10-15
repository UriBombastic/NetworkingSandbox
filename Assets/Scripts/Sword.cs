using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public SlashBro exception;
    public float growFactor = 0.1f;

    public void OnCollisionEnter(Collision collision)
    {
        SlashBro target = collision.gameObject.GetComponent<SlashBro>();
        Debug.Log(target.name);

        if(target != null)
        {
            if(target != exception)
                target.Die();
        }
    }

    public void Grow()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.z += growFactor;
        gameObject.transform.localScale = currentScale;
        gameObject.transform.Translate(0, 0, growFactor / 2);
    }
}
