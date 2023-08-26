using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    private Animator anim;

    public GameObject vfx;

    public float attackRate = 0.5f;

    private float attack;

    private void Awake()
    {
        anim = GetComponent<Animator>();

        attack = attackRate;
    }

    private void Update()
    {
        if (attack > 0)
        {
            attack -= Time.deltaTime;
        } 
        else
        {
            attack = 0;
        }

        if (Input.GetMouseButton(0))
        {
            if (attack == 0)
            {
                Vector3 currentMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                currentMousePosition.z = 0f;

                attack = attackRate;
                anim.SetTrigger("Punch");

                GameObject vfxAttack = Instantiate(vfx, currentMousePosition, Quaternion.identity);
                Destroy(vfxAttack, 0.75f);

                GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].GetComponent<SpriteRenderer>().color -= new Color(0, 0, 0, 0.2f);
            }
           
        }
    }


}
