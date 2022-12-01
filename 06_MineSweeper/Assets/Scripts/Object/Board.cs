using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{


    /// <summary>
    /// 생성할 셀의 프리팹
    /// </summary>
    public GameObject cellPrefab;

    /// <summary>
    /// Board가 가지는 가로 셀의 길이(가로 줄의 셀 갯수)
    /// </summary>
    public int width = 16;

    /// <summary>
    /// Board가 가지는 세로 셀의 길이(새로 줄의 셀 갯수)
    /// </summary>
    public int height = 16;

    /// <summary>
    /// 셀 한칸의 길이(셀 한변의 길이) -> 셀은 정사각형
    /// </summary>
    const float distance = 0.65f;

    /// <summary>
    /// 이 보드가 가지는 모든 셀
    /// </summary>
    Cell[] cells;



    private void Start()
    {
        Initialize();

    }

    /// <summary>
    /// 이 보드가 가질 모든 셀의 생성하고 배치하는 함수
    /// </summary>
    void Initialize()
    {
        Vector3 basePos = transform.position; // 기준위치설정(보드의 위치) -> 현제 위치는 원점으로 되있음 피봇의 가운데 위치가!
        
        //보드의 피봇을 중심으로 셀이 생성되게 하기 위해 셀이 생성될 시작점 계산 용도로 구하기
        Vector3 offset = new(-(width - 1) * distance * 0.5f, (height - 1) * distance * 0.5f);
    
        //셀들의 배열 생성
        cells = new Cell[width * height];

        // 셀들을 하나씩 생성하기 위한 이중 for 문 
        for (int y = 0; y < height; y++) 
        {
            for (int x = 0; x < width; x++) 
            {
                GameObject cellObj = Instantiate(cellPrefab, transform); // 이 보드를 부모로 삼고 생성
                Cell cell = cellObj.GetComponent<Cell>();                // 생성한 오브젝트에서 Cell 컴포넌트 찾기
                cell.ID = y * width + x;                                 // ID 설정(ID를 통해서 위치도 확인 가능)
                cellObj.name = $"Cell_{cell.ID}_({x},{y})";              // 오브젝트 이름 지정
                cell.transform.position = basePos + offset + new Vector3(x * distance, -y * distance); // 적절한 위치에 배치
                cells[cell.ID] = cell;                                   // cells 배열에 저장
            }
        
        }
        
        
        
        
        
        
        // 아래 코드는 본인 코드...
        //int startX = width; // 시작점 x 좌표를 왼쪽에서 -> 오른쪽으로 이동시키기 위해서 설정
        //int startY = -height; // 시작점 y 좌표를 위쪽에서 -> 아래쪽으로 이동시키기 위해서 설정 
        //for (int i = 0; i < height; i++)
        //{
        //    for (int j = 0; j < width; j++)
        //    {

        //        Vector3 pos = new Vector3(startX+j, startY + i);
        //        GameObject tmp = Instantiate<GameObject>(cellObj, pos, Quaternion.identity);
        //    }

            // cellObj의 위치를 자동으로 배치 (0,0 이 왼쪽위로 배치 , 왼쪽 -> 오른쪽 +x , 위 -> 아래 +y)
            // 생성된 cell 은 cells 에 모두 저장된다.
            // Board 에 pivot을 중심으로 모든 셀들이 배치되어야 한다.


        }

    }
