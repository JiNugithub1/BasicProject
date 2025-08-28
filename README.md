# 💰 Sparta Bank ATM 프로젝트

Unity로 제작한 ATM 입출금/송금 시스템 프로젝트입니다.  
유저 데이터 저장, 입출금, 송금, 로그인/회원가입까지 구현되었습니다.  

![Animation](https://github.com/user-attachments/assets/a10e450e-1015-456e-9107-4db6cb4d56fe)
---

## 📌 구현 단계

### STEP 1. ATM 화면 구성 (PopupBank)
- 기본 UI (Title, UserInfo, 현금, 입금/출금 버튼) 제작
- `string.Format`으로 금액을 천 단위 콤마(,)로 표시

---

### STEP 2. 유저 데이터 제작
- `UserData` 클래스 작성
- 유저 이름, 현금, 통장 잔액 저장 가능

---

### STEP 3. 게임 매니저 제작
- `GameManager` 싱글톤 패턴 적용
- `UserData` 변수 생성 및 초기화
- 직렬화하여 인스펙터 확인 가능

---

### STEP 4. 데이터와 UI 연동
- `UserInfo.Refresh()` 메서드 작성
- UI가 항상 최신 유저 데이터와 동기화되도록 구성

---

### STEP 5. 입금 UI 제작
- Canvas에 빈 오브젝트로 입금 UI 구성
- 버튼 (10,000 / 30,000 / 50,000 / 직접입력 / 뒤로가기) 제작
- `Vertical Layout`으로 간격 정렬

---

### STEP 6. 출금 UI 제작
- 출금 화면도 동일하게 제작
- 버튼 (10,000 / 30,000 / 50,000 / 직접입력 / 뒤로가기) 구성

---

### STEP 7. 입출금 창 이동
- 입금 버튼 → 입금창, 출금 버튼 → 출금창 이동
- `SetActive(true/false)`로 화면 전환

---

### STEP 8. 입금 기능
- 버튼 클릭 시 해당 금액만큼 현금 → 잔액 이동
- InputField로 직접 금액 입력 가능
- 잔액 부족 시 팝업 띄우기

---

### STEP 9. 출금 기능
- 버튼 클릭 시 해당 금액만큼 잔액 → 현금 이동
- InputField로 직접 금액 입력 가능
- 잔액 부족 시 팝업 띄우기

---

### STEP 10. 저장 및 로드 기능
- JsonUtility를 사용해 저장 및 불러오기 구현
- 입출금 시 자동 저장
- 게임 실행 시 저장된 데이터 불러오기

---

## 🎯 선택 과제 (도전)

### 11. 로그인 창 만들기
- ID, Password 입력 후 로그인 가능
- 회원가입 버튼을 통해 새 유저 추가 가능

### 12. 회원가입 만들기
- ID, Name, Password 입력
- 빈 칸이 있을 경우 에러창 표시
- Json 저장 방식 적용

### 13. 로그인 하기
- 입력한 ID/Password로 데이터 검증
- 성공 시 해당 유저 데이터 불러오기
- 실패 시 에러창 표시

### 14. 송금 하기
- 대상 이름(ID)과 금액 입력 후 송금
- 송금 대상 없거나, 금액 부족 시 에러 표시
- 성공 시 송금자/수신자 데이터 갱신 및 저장

---

## 📸 스크린샷 정리

| STEP | 설명 | 스크린샷 |
|------|------|----------|
| 1    | ATM 기본 화면 | <img width="875" height="489" alt="image" src="https://github.com/user-attachments/assets/534fff8e-3b87-45aa-b77c-203a6db16cf5" />|
| 5    | 입금 UI | <img width="874" height="492" alt="image" src="https://github.com/user-attachments/assets/1e5350f2-0886-4975-b45c-8502e84387b2" />|
| 6    | 출금 UI | <img width="876" height="489" alt="image" src="https://github.com/user-attachments/assets/7bb4a59d-ca29-41cf-ba89-7c29fc60779b" />|
| 8    | 입금 기능 실행 | ![Deposit](https://github.com/user-attachments/assets/c5088b3c-93cd-46f0-8b09-8a122b81401e)|
| 9    | 출금 기능 실행 |![Withdraw](https://github.com/user-attachments/assets/e579e3a7-a46d-4f99-8d97-facc63ee36e8)|
| 10   | 저장/로드 Json |![SaveLoad](https://github.com/user-attachments/assets/b647a8cf-95b3-41cc-af75-fc80a75fa40d)|
| 11   | 로그인 UI |![Login](https://github.com/user-attachments/assets/a7554894-f90f-4468-ab36-4178630464b0)|
| 12   | 회원가입 UI |![SignUp](https://github.com/user-attachments/assets/40e63482-1c90-4ab3-a29e-717779c3cde9)|
| 14   | 송금 UI | ![Sendmoney](https://github.com/user-attachments/assets/1d09a823-bda2-4c24-b268-bc9186f0a817)|

---

## 🚀 실행 방법
1. Unity 프로젝트 실행
2. `PopupLogin` → 로그인 후 ATM 이용 가능
3. 입금/출금/송금 기능 테스트 가능
