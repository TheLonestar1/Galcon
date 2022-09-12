using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Player : MonoBehaviour
{

    static public UnityEvent<GameObject> OnPlusEnemyPlanet = new UnityEvent<GameObject>();
    static public UnityEvent<GameObject> OnMinusEnemyPlanet = new UnityEvent<GameObject>();
    
    public void changeSide(string tag)
    {
        if(this.tag == "Enemy" && tag == "Player")
        {
            OnMinusEnemyPlanet.Invoke(gameObject);
        }
        this.tag = tag;
        if (this.tag == "Enemy")
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.3711705f, 0.3254717f);
            OnPlusEnemyPlanet.Invoke(gameObject);

        }
        if (this.tag == "Player")
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6235294f, 0.7529412f, 1);
    }

}
