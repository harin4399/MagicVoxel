using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelMaker : MonoBehaviour
{
    // 복셀 공장
    public GameObject voxelFactory;

    // 오브젝트 풀의 크기
    public int voxelPoolSize = 20;

    // 오브젝트 풀 - 필요한 리소스를 미리 만들어서 관리 / 로딩하는 시간 단축
    // static 선언 : 하나만 선언한다 - 모든 복셀들이 하나의 선언을 받는다
    public static List<GameObject> voxelPool = new List<GameObject>();
    
    float currentTime = 0;
    public float createTime = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = 0;
        // 오브젝트 풀에 비활성화된 복셀을 담고 싶다.
        for (int i = 0; i < voxelPoolSize; i++)
        {
            // 1. 복셀 공장에서 복셀 생성
            GameObject voxel = Instantiate(voxelFactory);

            // + 복셀에 색상 입히기
            //voxel.Render =

            // 2. 복셀 비활성화
            voxel.SetActive(false);

            // 3. 복셀을 오브젝트 풀에 담고 싶다.
            voxelPool.Add(voxel);
        }
    }

    public Transform crosshair;

    // Update is called once per frame
    void Update()
    {
        // crosshair 이미지가 마우스를 따라 움직임
        ARAVRInput.DrawCrosshair(crosshair);

        // 사용자가 마우스를 클릭한 지점에 복셀을 1개 만들고 싶다.
        // 1. 사용자가 마우스를 클릭했다면
        if (ARAVRInput.Get(ARAVRInput.Button.One))
        {
            currentTime += Time.deltaTime;
            if (currentTime > createTime)
            {
                //Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Ray ray = new Ray(ARAVRInput.RHandPosition, ARAVRInput.RHandDirection);
                RaycastHit hitInfo = new RaycastHit();

                // 2. 마우스의 위치가 바닥 위에 위치에 있다면
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (voxelPool.Count > 0)    // 오브젝트 풀 안에 voxel이 있는지 확인
                    {
                        GameObject voxel = voxelPool[0];    // 오브젝트 풀 최상단의 값을 가져옴

                        voxel.SetActive(true);  // 복셀을 활성화

                        voxel.transform.position = hitInfo.point;   // RayCast를 통해 얻은 충돌지점의 위치로 객체를 이동

                        voxelPool.RemoveAt(0);  // 오브젝트 풀에서 복셀을 하나 제거
                    }
                }
            }
        }
    }
}
