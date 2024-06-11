# HellChangRun
 </br></br> **프로젝트 소개(Introduction).**
 </br></br> * 3D 러닝 액션게임🏃‍♂️
 </br> * 3조 조원들이 Unity와 C# 을 이용하여 만든 프로젝트입니다.
 </br> * `Unity` 2022.3.17f1 버전을 사용했습니다.
 </br> * `비쥬얼스튜디오`에서 C# 콘솔 .Net 8.0 버전 사용했습니다.</br></br>
* * *
**게임 설명📖:** </br>
1. 게임 시작 시, `Game Start` 버튼과 `Shop`, `Game Setting`버튼이 있고 마우스 클릭으로 선택 가능합니다. 
2. `Game Start` 버튼을 누르면 메인 씬으로 넘어가며, 게임을 플레이 할 수 있습니다.
3. 화살표 ⬅ ➡를 이용해서 좌, 우로 이동이 가능합니다.
4. 『`SpaceBar`』를 입력하여 점프가 가능하며, 공중에서 한 번 던 누를 경우 2단 점프가 가능합니다. 
5. 화살표 ⬇를 입력하면 슬라이드가 가능합니다.
6. 위의 기능을 이용하여 장애물과 뒤에서 쫓아오는 트레이너를 피해 도망치는 게임입니다.
</br></br>
**조작 방법(How to Play🖱)📅**
</br></br>⬅ ➡ : 이동</br>
『`SpaceBar`』 : 점프</br>
⬇ : 슬라이드
</br></br>
**프로젝트 기간(Schedule)📅**
</br></br>2024년 5월 15일 ~ 2024년 5월 23일
</br></br>
* * *
## Run.1
**팀원 소개** (링크 누르면 페이지로 넘어가집니다.)
</br></br>[SA페이지](https://www.notion.so/teamsparta/63418be64c0c4845a27354452987b017)
| 이름  | 직책 | Github | 블로그 | 담당 |
|--------|------|------|------|------|
| 박준서 | 팀장 | <a href="(https://github.com/maple-rain)">![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)  |  [블로그](https://maple-rain.tistory.com/)   |  Enemy 담당  |
| 유승현 | 팀원 | <a href="(https://github.com/SeungD-dev)">![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)  |  [블로그](https://stronger-than-before.tistory.com/)  |  Player 담당  |
| 권용수 | 팀원 | <a href="(https://github.com/Kwonyougsu)">![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)  |  [블로그](https://hopegse.tistory.com/)  |  Inventory 담당  |
| 윤규석 | 팀원 | <a href="(https://github.com/YuunGu)">![GitHub](https://img.shields.io/badge/github-%23121011.svg?style=for-the-badge&logo=github&logoColor=white)   | [블로그](https://yuun124.tistory.com/)  |  Map 담당  |

</br></br></br>
* * *

## Run.2
###### 주요 기능 설명

1.메인 씬 구성
  ![image](https://github.com/maple-rain/HellChangRun/assets/44717239/b32a7ef1-c112-4870-befe-a8a3f22abcfb)
+ 메인씬은 게임시작 , 상점 , 인벤토리, 게임설정으로 구성되어있습니다
  1. 상점 구성
  ![image](https://github.com/maple-rain/HellChangRun/assets/44717239/50a3895f-4d38-46c9-ba02-50ab3ad65e86)
  + 현재 기능은 소모성아이템을 구매할수있습니다
  + 구매한 아이템은 오른쪽위 버튼을 통해 진입가능한 인벤토리에서 확인할수있습니다
  2. 인벤토리 구성
    ![image](https://github.com/maple-rain/HellChangRun/assets/44717239/f78a12cf-f86d-4608-a450-301e0fb002cf)
    + 상점에서 구매한아이템이 인벤토리에 갯수별로 쌓여있는것을확인할수있습니다
    + 인벤토리의 아이템은 장착 , 판매 등의 기능을 사용할수있습니다
      ![image](https://github.com/maple-rain/HellChangRun/assets/44717239/1dfaf07e-a261-4d27-af7f-50bc6e72784e)


2. 게임 시작씬
   ![image](https://github.com/maple-rain/HellChangRun/assets/44717239/3e2343e1-639b-40ac-a013-463aa4b99cff)
   ![image](https://github.com/maple-rain/HellChangRun/assets/44717239/235be944-cac3-4b55-86be-b6897c3fa403)

+ 게임이 시작되면 플레이어는 왼쪽, 가운데, 오른쪽 길을 좌우 방향키를 눌러 이동할 수 있으며 음식을 먹어서 좌측 하단에 있는 몸무게 수치를 적정으로 유지해야합니다.
</br> + 정크푸드를 많이 먹어서 체중이 증가하면 플레이어의 속도가 느려지게 되면 뒤에서 쫓아오는 헬창에게 잡히게됩니다.
</br> + 길에는 장애물들이 스폰되어 충돌되지 않도록 피해야합니다.


  
