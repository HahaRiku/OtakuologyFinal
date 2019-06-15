using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*****************************
 * 
 * 進行一次華麗的彈幕(???
 * 
 * *****************************/


public class DanmuDesign : MonoBehaviour {

    public enum Type {
        圓形散開,
        螺旋
    }

    public Type type = Type.圓形散開;
    public Sprite 彈幕的圖;
    public GameObject Danmu_element;
    public float elementSize= 50;
    public float elementSpeed = 1;

    private bool start;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (start && !GlobalVariables.gameOver && !GlobalVariables.win) {
            start = false;
            if (type == Type.圓形散開) {
                for (int i = 0; i < 10; i++) {
                    EachNodeMovingControl obj = Instantiate(Danmu_element, gameObject.transform).GetComponent<EachNodeMovingControl>();
                    obj.Initialize(elementSize, 36 * i, elementSpeed, 彈幕的圖);
                    GlobalVariables.AddDanmuElement(obj.gameObject);
                    obj.Run();
                }
            }
            else if (type == Type.螺旋) {
                for (int i = 0; i < 10; i++) {
                    EachNodeMovingControl obj = Instantiate(Danmu_element, gameObject.transform).GetComponent<EachNodeMovingControl>();
                    obj.Initialize(elementSize, 36 * i, elementSpeed, 彈幕的圖);
                    GlobalVariables.AddDanmuElement(obj.gameObject);
                    StartCoroutine(WaitAndRun(i * 0.2f, obj));
                }
            }
        }
    }

    public void StartDanmu() {
        start = true;
    }

    private IEnumerator WaitAndRun(float seconds, EachNodeMovingControl obj) {
        yield return new WaitForSeconds(seconds);
        obj.Run();
    }
}
