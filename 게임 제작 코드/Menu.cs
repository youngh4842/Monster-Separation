using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour { //씬을 변경할때 쓴다.

    public static int replay = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //첫화면에서 게임화면으로
    public void ChangeGameScene()
    {
        SceneManager.LoadScene("finalmain");
    }

    //첫화면에서 설명화면으로
    public void Changetohow()
    {
        SceneManager.LoadScene("how");
    }


    //첫화면으로
    public void ChangetoMenu()
    {
        SceneManager.LoadScene("first");
    }

    //게임 재 시작
    public void ReStart()
    {
        SceneManager.LoadScene("finalmain");
        replay++;
    }

    //게임 종료
    public void Quit()
    {
        Application.Quit();
    }
}
