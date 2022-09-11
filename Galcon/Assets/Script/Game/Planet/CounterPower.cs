using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CounterPower : MonoBehaviour
{
    [SerializeField]
    private int _shipCounter;
    [SerializeField,Range(0,10)]
    private float _timer;
    [SerializeField]
    private int _addShips;
    // Start is called before the first frame update
    public int ships { get { return _shipCounter; } set { _shipCounter = value; } }
    TMP_Text _fieldText;
    void Start()
    {
        _fieldText = GetComponentInChildren<TMP_Text>();
        _fieldText.text = _shipCounter.ToString();
        if (this.gameObject.tag != "Neutral")
            StartCoroutine(Counter());
    }
    public void DecreseCoutner(int damage)
    {
        _shipCounter -= damage;
        _fieldText.text = _shipCounter.ToString();
        if (_shipCounter <= 0)
        {
            this.GetComponent<Player>().changeSide("Player");
        }
    }
    IEnumerator Counter()
    {
        while(true)
        {
            yield return new WaitForSeconds(_timer);
            _shipCounter += _addShips;
            _fieldText.text = _shipCounter.ToString();
        }
    }
}
