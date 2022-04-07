using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Code was from the tutorial series: https://www.youtube.com/watch?v=9B7ahj1kaYs
//and: https://www.youtube.com/watch?v=jWbAaBEQpvE&t=318s
//and: https://www.youtube.com/watch?v=2m7pnTC0seo

public class ScrollBarLoop : MonoBehaviour
{

    public RectTransform panel;
    public Button[] bttn;
    public RectTransform center;



    public float[] distance;
    public float[] distReposition;
    private bool dragging = false;
    private int bttnDistance;
    private int minButtonNum;
    private int bttnLength;

    // Start is called before the first frame update
    void Start()
    {
        bttnLength = bttn.Length;
        distance = new float[bttnLength];
        distReposition = new float[bttnLength];

        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < bttn.Length; i++)
        {
            distReposition[i] = center.GetComponent<RectTransform>().position.x - bttn[i].GetComponent<RectTransform>().position.x;
            distance[i] = Mathf.Abs(distReposition[i]);

            if (distReposition[i] > 200)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

                Vector2 newAnchorPos = new Vector2 (curX + (bttnLength * bttnDistance), curY);
                bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchorPos;
            }

            if (distReposition[i] < -200)
            {
                float curX = bttn[i].GetComponent<RectTransform>().anchoredPosition.x;
                float curY = bttn[i].GetComponent<RectTransform>().anchoredPosition.y;

               Vector2 newAnchorPos = new Vector2(curX - (bttnLength * bttnDistance), curY);
               bttn[i].GetComponent<RectTransform>().anchoredPosition = newAnchorPos;
            }
        }
        float minDistance = Mathf.Min(distance);
        for (int a = 0; a < bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;
            }
        }
        if (!dragging)
        {
            LerpToBttn (bttn[minButtonNum].GetComponent<RectTransform>().anchoredPosition.x);
        }
    }

    void LerpToBttn (float position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 0f);
        Vector2 newPosition = new Vector2 (newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag()
    {
        dragging=false;
    }
}

