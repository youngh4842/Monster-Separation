using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  //신 변환
using UnityEngine.UI;

public class Play : MonoBehaviour {

    //시간 & 점수 & 콤보 변수 선언
    private float time ;    //화면에 출력되는 시간 
    private float timer;    //실제 흘러가는 시간을 의미할 것이다.
    public Text timeText;
    public Text lowText;    //틀릴때마다 1s씩 감소한다.
    public static int endtime =0;  //다른 스크립트에서 종료를 알려준다.

    private int score;
    public Text scoreText;

    private int combo ;
    public Text comboText;
    public Text comClearText;   //콤보 20 달성시 콤보텍스트 클리어 표시

    public Text finalText;
    public Image image;

    public int replay;

    //character
    private int rancount;
    public GameObject[] member; //램덤으로 캐릭터들 생성
    private GameObject realmem; //실제보여지는 캐릭터
    private int count;  //시간경과할 때마다 출력되는 캐릭터의 수가 다르다

    //화면에 방향을 뜻하기 위해 보여지는 캐릭터들
    public GameObject[] wheremem;

    //animation 작용
    public static int animotion = 8;    //다른스크립트에 가지고 간다.
    private Animation anim;

    //효과음
    public AudioClip getPoint;
    public AudioClip getCombo;
    public AudioClip getLose;
    public AudioClip gameclose;


    void Start () {

        timer = Time.timeSinceLevelLoad;    //씬이 실행될 때마다 시간이 흘러간다.
        time = 60 - timer;

        score = 0;
        combo = 0;

        replay = Menu.replay;
        if (replay > 0)
            ReSet();

        realmem = new GameObject();
        count = 3;  //처음에는 3개가 랜덤으로 출력된다.(
        Setup();

        lowText.text = "";
        comClearText.text = "";
        finalText.text = "";
        image.enabled = false;


    }
 
	
	void Update () {

        Timer();
        InputKey();

        replay = Menu.replay;
        if (replay>0)
            ReSet();
    }

    //캐릭터가 랜덤으로 생성된다.
    void Setup()
    {
        rancount = Random.Range(0, count);
        realmem = member[rancount];
        realmem.SetActive(true);
        realmem = Instantiate(realmem, new Vector2(0, (float)-0.33), Quaternion.identity);

        Debug.Log("c" + count);
        //count에 따라 화면에 알려줄 캐릭터 수 다름
        for (int i=0; i < count; i++)
        {
           wheremem[i].SetActive(true);
       
        }


    }

    //타이머 - 시간이 지나면 캐릭터 증가
    //0s일때는 3개, 8s경과시 4개, 12s경과시 5개의, 19s경과시 6개, 24s경과시 7개의 캐릭터가 나온다.
    void Timer()
    {
        if (time != 0)
        {
            time = time - Time.deltaTime;
            if (time <= 0)
            {
                time = 0;
            }

            //시간이 얼마나 경과됐는지를 보여준다.
            timer = Time.timeSinceLevelLoad;

            if ((int)timer == 8)
            {
                count = 4;
            }
            else if ((int)timer == 12)
            {
                count = 5;
            }
            else if ((int)timer == 19)
            {
                count = 6;
            }
            else if ((int)timer == 24)
            {
                count = 7;
            }


        }
        else //시간이 0이므로 종료된다.
        {
            endtime = 4;
            enabled = false;
            SoundM.instance.playSingle(gameclose);
            image.enabled = true;
            finalText.text = "    -the end-\n" + "your score " + score;
            
        }

        //float형으로 계산되는 시간을 int형으로 바꿔준다.
        int t = (int)time;
        timeText.text = t.ToString();

    }

    //키보드로 입력해서 캐릭터가 어느방향키를 눌러야 할지를 정해준다.
    //맞으면 combo와 score이 올라갈것이고 틀리면 시간이 1s 깍일 것이다.
    void InputKey()
    {
       
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            comClearText.text = "";
            if (realmem == GameObject.FindWithTag("White"))
            {
                colloect();
            }

            else
            {
                wrong();
            }

            Debug.Log(animotion + "animo");

        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            comClearText.text = "";
            if (realmem == GameObject.FindWithTag("Green"))
            {
                colloect();

            }
            else if (realmem == GameObject.FindWithTag("Orange"))
            {
                colloect();
            }
            else if (realmem == GameObject.FindWithTag("Lobed"))
            {
                colloect();
            }
            else 
            {
                wrong();
            }
            Debug.Log(animotion + "animo");
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            comClearText.text = "";
            if (realmem == GameObject.FindWithTag("Red"))
            {
                colloect();
            }
            else if (realmem == GameObject.FindWithTag("Blue"))
            {
                colloect();
            }
            else if (realmem == GameObject.FindWithTag("Yellow"))
            {
                colloect();
            }
            else
            {
                wrong();
            }
            Debug.Log(animotion + "animo");
        }
        
        scoreText.text = score.ToString();
        comboText.text = combo.ToString() + " Combo";
        setcombo();

    }

    //각 태그마다 animotion의 값을 주어져 ChaAction스크립트에서 애니메이션을 작동하게한다.
    void ColorCompare()
    {
        if (realmem == GameObject.FindWithTag("Red"))
        {
            animotion = 0;
        }
        else if(realmem == GameObject.FindWithTag("Green"))
        {
            animotion = 1;
        }
        else if (realmem == GameObject.FindWithTag("White"))
        {
            animotion = 2;
        }
        else if (realmem == GameObject.FindWithTag("Blue"))
        {
            animotion = 3;
        }
        else if (realmem == GameObject.FindWithTag("Orange"))
        {
            animotion = 4;
        }
        else if (realmem == GameObject.FindWithTag("Yellow"))
        {
            animotion = 5;
        }
        else if (realmem == GameObject.FindWithTag("Lobed"))
        {
            animotion = 6;
        }

    }

    //20콤보를 달성시 5s의 시간을 더준다.
    void setcombo()
    {
        if (combo == 20)
        {
            SoundM.instance.playSingle(getCombo);
            time += 5;
            combo = 0;
            comClearText.text = "get bonus time";
        }
        
    }

    //옳게 입력시
    void colloect()
    {
        combo++;
        score += 100;
        SoundM.instance.playSingle(getPoint);
        realmem.SetActive(false);
        Setup();
        lowText.text = "";
    }

    //잘못 입력시
    void wrong()
    {
        combo = 0;
        time--;
        SoundM.instance.playSingle(getLose);
        lowText.text = "1s low";
        ColorCompare();
    }

    //다시 시작
    void ReSet()
    {
        count = 3;
    }

}
