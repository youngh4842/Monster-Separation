using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaAction : MonoBehaviour {    //키를 눌렀을때 캐릭터들의 애니메이션

    private Animator anmtor;

    public int count = 8;
    public int time = 0;

    void Start()
    {
        anmtor = GetComponent<Animator>();

        //Play스크랩트에서 변수값을 가져온다.
        count = Play.animotion; //animotion = 어떤 캐릭터가 애니메이션을 일으키나
        time = Play.endtime;    //endtime = 4이면 게임은 종료되었다.       

    }

    void Update()
    {
        count = Play.animotion;
        time = Play.endtime;  

        if (time != 4)  //종료가 되지 않았다.
        {
            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                Check();
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                Check();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Check();
            }
        }
        else
        {
            enabled = false;
        }


    }

    void Check()
    {

        if (count == 0)
        {
            anmtor.SetTrigger("redhurt");

        }
        else if (count == 1)
        {
            anmtor.SetTrigger("greenhurt");

        }
        else if (count == 2)
        {
            anmtor.SetTrigger("whitehurt");

        }
        else if (count == 3)
        {
            anmtor.SetTrigger("bluehurt");

        }
        else if (count == 4)
        {
            anmtor.SetTrigger("orangehurt");

        }
        else if (count == 5)
        {
            anmtor.SetTrigger("yellowhurt");

        }
        else if (count == 6)
        {
            anmtor.SetTrigger("lobedhurt");

        }
    }

    
    
}
