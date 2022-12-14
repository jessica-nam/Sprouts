using UnityEngine;
using UnityEngine.UI;
 
public class Blink : MonoBehaviour
{
    public Color startColor = Color.green;
    public Color endColor = Color.white;
    [Range(0,10)]
    public float speed = 1;
    private double alpha;
 
    Image imgComp;
 
    void Awake()
    {
        imgComp = GetComponent<Image>();

    }
 
    void Update()
    {
        imgComp.color = Color.Lerp(startColor, endColor, Mathf.PingPong(Time.time * speed, 1));
        // if(endColor =)

        
    }
}
