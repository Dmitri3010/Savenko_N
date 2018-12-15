using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScript : MonoBehaviour {

    public GameObject Door, Button, Lamp;
    public bool IsWork = false;
    public bool IsHot = false;
    public TextMesh  R1text, R2text, tempriger;
    int time = 1;
    float U = 0f;
    float U2 = 0f;
    float temprige = 0f;

    IEnumerator Example()
    {
        yield return new WaitForSeconds(1.5f);
        time = 1;
    }

    private void UpdateTextValues()
    {
        GameObject _R1Value = GameObject.Find("uvalue");
        GameObject _R2Value = GameObject.Find("uvalue2");
        GameObject _t1Value = GameObject.Find("t1");

        R1text = _R1Value.GetComponent<TextMesh>();
        R2text = _R2Value.GetComponent<TextMesh>();
        tempriger = _t1Value.GetComponent<TextMesh>();

        if (time == 1)
        {

            StartCoroutine(Example());
            if (U < 300)
            {
                U += 2.3f;
                U2 += 3.1f;
            }

            StartCoroutine(Example());
            if (temprige < 150)
                temprige = temprige + Random.Range(1f, 3f);

            R1text.text = U.ToString();
            R2text.text = U2.ToString();
            tempriger.text = temprige.ToString();
            time = 0;

        }
    }


    void Update () {
        GameObject go = GameObject.Find("Button");
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (IsWork == false)
            {

                var temp = go.transform.position;
                temp.x -= 0.030f;
                Color YelowColor = new Color(1, 0, 0);
                Lamp.gameObject.GetComponent<Renderer>().material.color = YelowColor;
                Door.transform.Rotate(0, 0, 36f);
                Button.transform.position = temp;
                IsWork = true;
            }
            else
            {

                var temp = go.transform.position;
                temp.x += 0.030f;
                Door.transform.Rotate(0, 0, -36f);
                Button.transform.position = temp;
                Color WhiteColor = new Color(255, 255, 255);
                Lamp.gameObject.GetComponent<Renderer>().material.color = WhiteColor;
                IsWork = false;
                temprige = 0;
                U = 0;
                U2 = 0;


            }
        }
        if (IsWork == true)
        {
            UpdateTextValues();

        }
    }
}
