## 개요  

* unity 제공하는 레이어의 수가 제한적이고(32개), 복수의 레이어를 가질 수 없는게 불편해서 만들어봤습니다.

* LayerManager 스크립트를 활용하여 유니티 내부의 레이어가 아닌 임의의 레이어를 관리할 수 있습니다.
 ( 기존의 레이어를 그대로 사용할 수 있는 기능도 있음 )

* 이 레이어는 유니티의 [Sorting Layer], [RayCast with Layer] 를 사용할 수 없음을 주의해주세요.

---

## 기능

* LayerManager 컴포넌트의 Inpector 창을 통해 유니티에서 지원하는 레이어를 미리 추가할 지 선택할 수 있습니다.

* 또한 LayerManager 의 enum CustomLayer 의 정의부분을 수정하여 새로운 이름의 레이어를 미리 추가할 수 있습니다.

* bool[] 로 최대 (Int max) 개의 레이어를 가질 수 있는 layer mask 를 활용합니다.
 이 최댓값은 임의로 줄일 수 있습니다.

* LayerSetting 의 layerMask 는 Inspector 에서 수정할 수 있도록 Editor 로 구현했습니다. LayerManager 를 통해서도 수정할 수 있습니다. 

* layerMask 를 layerMask 와 여러 레이어들( string[] ) 간에 or/and 계산을 수행할 수 있습니다.

* LayerManager 에서는 새로운 이름의 레이어를 실시간으로 추가/제거할 수 있습니다.

---

## 사용 방법

* 제공되는 기능을 이용하려면 LayerSetting 컴포넌트를 게임오브젝트에 추가해야 합니다.

* Hierachy 에는 최소/되도록최대 하나의 LayerManager 컴포넌트가 존재해야 합니다.

* 유니티에서 지원하는 레이어를 추가하려면, LayerManager 를 사용하는 스크립트보다 LayerManager 가 먼저 오도록 Script Execution Order 를 설정해줘야 합니다.

* GameObject 의 LayerSetting 컴포넌트를 선택하고, Inspector 에서 해당하는 레이어를 체크하여 layerMask 를 설정할 수 있습니다.

---
