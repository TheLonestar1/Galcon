using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public void changeSide(string tag)
    {
        this.tag = tag;
        if (this.tag == "Enemy")
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 0.3711705f, 0.3254717f);

        if (this.tag == "Player")
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(0.6235294f, 0.7529412f, 1);
    }

}
