#include <ESP8266WiFi.h>
#include <Firebase_ESP_Client.h>
#include "addons/TokenHelper.h"
#include "addons/RTDBHelper.h"
 
#define DATABASE_URL "https://hilti-4a670-default-rtdb.asia-southeast1.firebasedatabase.app/" // Firebase host
#define API_KEY "AIzaSyBziIaxSz2uuMRvpM-afl1p4iyDuiGVDPo" //Firebase Auth code
#define WIFI_SSID "Home Wifi (Mesh)" //Enter your wifi Name
#define WIFI_PASSWORD "1616kennethng" // Enter your password

// constants won't change
const int BUTTON_PIN = D2; // Arduino pin connected to button's pin
const int LED_PIN = D4; // Arduino pin connected to LED's pin

// variables will change:
int ledState = LOW;     // the current state of LED
int lastButtonState;    // the previous state of button
int currentButtonState; // the current state of button
bool signupOK = false;
int ldrData = 0;
float voltage =0.0;
unsigned long sendDataPrevMillis = 0;

FirebaseData fbdo;
FirebaseAuth auth;
FirebaseConfig config;
 
void setup() {
  Serial.begin(9600);
  pinMode(BUTTON_PIN, INPUT_PULLUP); // set arduino pin to input pull-up mode
  pinMode(LED_PIN, OUTPUT);          // set arduino pin to output mode

  currentButtonState = digitalRead(BUTTON_PIN);
  WiFi.begin(WIFI_SSID, WIFI_PASSWORD);
  Serial.print("Connecting");
  while (WiFi.status() != WL_CONNECTED) {
    Serial.print(".");
    delay(200);
  }
  Serial.println();
  Serial.println("Connected.");
  Serial.println(WiFi.localIP());
  config.api_key = API_KEY;
  config.database_url = DATABASE_URL;
  if (Firebase.signUp(&config, &auth, "", "")) {
    Serial.println("SignUp OK");
    signupOK = true;
  } else {
    Serial.printf("%s\n", config.signer.signupError.message.c_str());
  }
  config.token_status_callback = tokenStatusCallback;
  Firebase.begin(&config, &auth);
  Firebase.reconnectWiFi(true);
  // Firebase.setInt("LED_STATUS", 0);
}
 
void loop() {
  lastButtonState    = currentButtonState;      // save the last state
  currentButtonState = digitalRead(BUTTON_PIN); // read new state

  if(lastButtonState == HIGH && currentButtonState == LOW) {

  // toggle state of LED
    ledState = !ledState;
  // control LED arccoding to the toggled state
    digitalWrite(LED_PIN, ledState); 
    Serial.print(ledState);
  }
  // Serial.print(WiFi.localIP());
  if(Firebase.ready() && signupOK && (millis() - sendDataPrevMillis>200 || sendDataPrevMillis == 0)){
    sendDataPrevMillis = millis();
    
    // ldrData = digitalRead(BUTTON_PIN);
    // Serial.println(ldrData);
    if(Firebase.RTDB.setInt(&fbdo, "Sensor/button", ledState)) {
      Serial.println();
      Serial.print(ledState);
      Serial.print("-Successfully saved to: "+ fbdo.dataPath());
      Serial.println("("+fbdo.dataType()+")");
    } else{
      Serial.println("Failed: "+fbdo.errorReason());
    }
  }
}
