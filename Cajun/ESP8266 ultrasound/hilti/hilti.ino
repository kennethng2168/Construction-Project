#include <ESP8266WiFi.h>
// #include <Firebase_ESP_Client.h>
// #include "addons/TokenHelper.h"
// #include "addons/RTDBHelper.h"

#define DATABASE_URL "https://hilti-4a670-default-rtdb.asia-southeast1.firebasedatabase.app/" // Firebase host
#define API_KEY "AIzaSyBziIaxSz2uuMRvpM-afl1p4iyDuiGVDPo" //Firebase Auth code

// 2.4GHZ ONLY for ESP8266
#define WIFI_SSID "KJun" //Enter your wifi Name
#define WIFI_PASSWORD "12345678" // Enter your password

// constants won't change
const int BUTTON_PIN = D2; // Toggle button's pin
const int LED_PIN    = D4; // LED's pin
const int LED2_PIN   = D3;
const int trigPin    = D5; // trig pin for ultrasonic Sensor
const int echoPin    = D6; // echo pin for ultrasonic Sensor

// variables will change:
int ledState = LOW, led2State = LOW;     // the current state of LED
int lastButtonState;    // the previous state of button
int currentButtonState; // the current state of button
bool signupOK = false;
int ldrData = 0;
float voltage = 0.0;
unsigned long sendDataPrevMillis = 0;
long duration;
long prevMill = 0, currentMill, prevMill2 = 0;
int distance;

// FirebaseData fbdo;
// FirebaseAuth auth;
// FirebaseConfig config;

void setup() {
  Serial.begin(9600);
  pinMode(BUTTON_PIN, INPUT_PULLUP); // set arduino pin to input pull-up mode
  pinMode(LED_PIN, OUTPUT);          // set arduino pin to output mode
  pinMode(LED2_PIN, OUTPUT);
  pinMode(trigPin, OUTPUT);          // Sets the trigPin as an Output
  pinMode(echoPin, INPUT);           // Sets the echoPin as an Input

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
  // config.api_key = API_KEY;
  // config.database_url = DATABASE_URL;
  // if (Firebase.signUp(&config, &auth, "", "")) {
  //   Serial.println("SignUp OK");
  //   signupOK = true;
  // } else {
  //   Serial.printf("%s\n", config.signer.signupError.message.c_str());
  // }
  // config.token_status_callback = tokenStatusCallback;
  // Firebase.begin(&config, &auth);
  //  Firebase.reconnectWiFi(true);
  // Firebase.setInt("LED_STATUS", 0);
}

void loop() {
  //  NOTE: Response is slowed down if object is too close or too far (2000+cm)
  lastButtonState    = currentButtonState;      // save the last state
  currentButtonState = digitalRead(BUTTON_PIN); // read new state
  if (lastButtonState == HIGH && currentButtonState == LOW) {
    ledState = !ledState;
    digitalWrite(LED_PIN, ledState);
  }

  currentMill = millis();
  if (currentMill - prevMill >= 300) {
    prevMill = currentMill;
    // Clears the trigPin
    digitalWrite(trigPin, LOW);
    delayMicroseconds(2);

    // Sets the trigPin on HIGH state for 10 micro seconds
    digitalWrite(trigPin, HIGH);
    delayMicroseconds(10);
    digitalWrite(trigPin, LOW);

    // Reads the echoPin, returns the sound wave travel time in microseconds
    duration = pulseIn(echoPin, HIGH);

    // Calculates distance & prints it out
    distance = duration * 0.034 / 2;
    Serial.println((String)"Distance: " + distance + "cm");
  }

  if (millis() - prevMill2 >= 1000) {
    prevMill2 = millis();
    led2State = !led2State;
    digitalWrite(LED2_PIN, led2State);
  }


  // // Serial.print(WiFi.localIP());
  // if(Firebase.ready() && signupOK && (millis() - sendDataPrevMillis>200 || sendDataPrevMillis == 0)){
  //   sendDataPrevMillis = millis();

  //   // ldrData = digitalRead(BUTTON_PIN);
  //   // Serial.println(ldrData);
  //   if(Firebase.RTDB.setInt(&fbdo, "Sensor/button", ledState)) {
  //     Serial.println();
  //     Serial.print(ledState);
  //     Serial.print("-Successfully saved to: "+ fbdo.dataPath());
  //     Serial.println("("+fbdo.dataType()+")");
  //   } else{
  //     Serial.println("Failed: "+fbdo.errorReason());
  //   }
}
