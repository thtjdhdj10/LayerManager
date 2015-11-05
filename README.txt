# LayerManager

( 아래에서 언급하는 layer 는 GameObject 에 있는 기본 layer 가 아닌 LayerSetting 에서 관리하는 layer 를 말합니다. )

LayerSetting 컴포넌트를 유닛에 추가하면 복수의 layer 를 자유롭게 설정할 수 있습니다.

Edit Layer Realtime 을 true 로 설정하면 inspector 에서 설정하는 layer 가 실시간으로 적용됩니다.

즉, 외부에서 layer 에 직접 접근하는 것이 무의미하게 바뀝니다.

이런 동작을 원하지 않는다면 false 로 설정해주세요.
  
  
LayerSetting 스크립트에 있는 생성자 이하의 코드들은 레이어를 보다 편리하게 접근하기 위해 존재합니다.

예를들어, LayerSetting.StringToMask("Default") 와 같이 레이어 이름으로 mask 를 구하거나 할 수 있습니다.

