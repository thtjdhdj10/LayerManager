# LayerManager

LayerManager 스크립트에 있는 생성자 이하의 코드들은 레이어를 보다 편리하게 접근하기 위해 존재합니다.

예를들어, LayerSetting.StringToMask("Default") 와 같이 레이어 이름으로 mask 를 구하거나 할 수 있습니다.


실은 GameObject 에 있는 layer 변수를 이용하여 Physics.RayCast 과 같은 함수에 이용할 수 있게 하고 싶었지만,

layer 변수는 비트패턴이 아니라 하나의 레이어만을 가르키는 0~31 사이의 정수값을 받기 때문에 이용할 수 없었습니다.

