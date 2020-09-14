using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyAction : MonoBehaviour {    //키를 입력했을때 키에서 일어나는 애니메이션

    private Animator anmtor;
    public int time;

    void Start()
    {
        anmtor = GetComponent<Animator>();

        time = Play.endtime;
    }

    void Update()
    {
        time = Play.endtime;

        if (time != 4)
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                anmtor.SetTrigger("put");
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                anmtor.SetTrigger("lput");
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                anmtor.SetTrigger("rput");
            }
        }
        else
        {
            enabled = false;
        }
    }
}
