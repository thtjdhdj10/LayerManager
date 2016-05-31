## 개요  

* unity 제공하는 레이어의 수가 제한적이고(32개), 복수의 레이어를 가질 수 없는게 불편해서 만들어봤습니다.

* LayerManager 스크립트를 활용하여 유니티 내부의 레이어가 아닌 임의의 레이어를 관리할 수 있습니다.

* 이 레이어는 유니티의 [Sorting Layer], [RayCast with Layer] 를 사용할 수 없음을 주의해주세요.

---

## 기능

* LayerManager 컴포넌트의 Inpector 창을 통해 유니티에서 지원하는 레이어를 미리 추가할 지 선택할 수 있습니다.

* bool[] 로 최대 (Int max) 개의 레이어를 가질 수 있는 layer mask 를 활용합니다.
 이 최댓값은 임의로 줄일 수 있습니다.

* 임의의 레이어를 추가하거나, layer mask 와 여러 레이어들(string[]) 간에 or/and 계산을 수행할 수 있습니다.

* LayerSetting 컴포넌트를 통해 레이어를 추가/제거 할 수 있습니다( string | int | mask ).

* 

---

## 사용 방법

* 제공되는 기능을 이용하려면 LayerSetting 컴포넌트를 게임오브젝트에 추가해야 합니다.

* 유니티에서 지원하는 레이어를 추가하려면, LayerManager 사용하는 스크립트보다 LayerManager 가 먼저 오도록 Script Execution Order 를 설정해줘야 합니다.

* 

---
