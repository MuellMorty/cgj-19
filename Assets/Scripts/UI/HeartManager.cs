using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    public Destroyable target;
    public GameObject heart;

    public Sprite empty;
    public Sprite half;
    public Sprite full;

    private Image[] hearts;
    
    void Start()
    {
        hearts = new Image[(target.maxHP+1)/2];
        
        for (int i = 0; i < (target.maxHP+1)/2; i++)
        {
            var h = Instantiate<GameObject>(heart, transform);
            h.transform.Translate(0.55f*i,0,0);
            hearts[i] = h.gameObject.GetComponent<Image>();
        }
    }

    void Update()
    {
        for (int i = 0; i < (target.maxHP + 1) / 2; i++)
        {
            if (target.currHP  / 2 > i)
            {
                hearts[i].sprite = full;
                continue;
            }
            if (target.currHP % 2 == 1 && i*2 < target.currHP)
            {
                hearts[i].sprite = half;
                continue;
            }
            
            hearts[i].sprite = empty;
        }
    }
}
