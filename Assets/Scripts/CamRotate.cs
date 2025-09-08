using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotate : MonoBehaviour
{
    Vector3 angle;  // Roll Pitch Yaw
    public float sensitivity = 200;
    // Start is called before the first frame update
    void Start()
    {
        // 카메라의 첫 앵글값을 잡아주기
        angle = Camera.main.transform.eulerAngles;
        angle.x = angle.x * -1;  // angle.x *= -1
    }

    // Update is called once per frame
    void Update()
    {
        // 마우스 정보 입력
        // 변수 x,y 생성성
        float x = Input.GetAxis("Mouse Y");
        float y = Input.GetAxis("Mouse X");

        // 방향 확인
        angle.x = angle.x + x * sensitivity * Time.deltaTime;
        angle.y = angle.y + y * sensitivity * Time.deltaTime;

        // 상하 각도 제한
        angle.x = Mathf.Clamp(angle.x, -90, 90);

        // 회전
        // transform.eulerAngles : 트랜스폼의 각도 정보
        transform.eulerAngles = new Vector3(-angle.x, angle.y, angle.z);
    }
}
